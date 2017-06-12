using System;
using System.Linq;
using System.Threading.Tasks;
using HarryBotter.DataService;
using Microsoft.Bot.Builder.Dialogs;

using Microsoft.Bot.Connector;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class BiddingInitiationDialog : IDialog<string>
    {
        private readonly string _auctionName;
        private readonly string _make;
        private readonly string _model;

        public BiddingInitiationDialog(string auctionName, string make, string model)
        {
            _auctionName = auctionName;
            _make = make;
            _model = model;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var reply = context.MakeMessage();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            reply.Attachments = GetCardsAttachments();
                await context.PostAsync(reply);
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var reply = context.MakeMessage();
            if (message.Value != null)
            {
                Vehicle vehicle = JsonConvert.DeserializeObject<Vehicle>(message.Value.ToString());
                reply.Attachments.Add(GetHeroCard(
                    $"{vehicle.Make} - {vehicle.Model}",
                    $"{vehicle.Description}",
                    $"{vehicle.Id} - {vehicle.ItemId} - {vehicle.Odometer} - {vehicle.Year} - {vehicle.PriceGuide} - {vehicle.Rego}",
                    new CardImage(url: vehicle.ImageUrl),
                    new CardAction(ActionTypes.PostBack, "Show Condition Report", value: "ConditionReport")
                ));
            }
            else if (message.Text == "ConditionReport")
            {
                //context.UserData.SetValue("Vehicle",);
                reply.Attachments.Add(GetConditionRepoertImage());
                PromptDialog.Text(context, HandleBidDecision, "Would you like to place a bid on this car?");
            }

            await context.PostAsync(reply);
            //context.Done(JsonConvert.DeserializeObject<Vehicle>(message.Value.ToString()));
        }

        private async Task HandleBidDecision(IDialogContext context, IAwaitable<string> result)
        {
            var score = new LuisService().Score(await result);
            if (score.Succeeded &&
                score.LuisResult.TopScoringIntent.Intent.IndexOf("Yes", StringComparison.InvariantCultureIgnoreCase) > 0)
                context.Done("Yes");
            else
                context.Done("No");
        }

        private static Attachment GetConditionRepoertImage()
        {
            var imagePath = HttpContext.Current.Server.MapPath("~/images/condition_report_sample.png");
            var heroCard = new HeroCard
            {
                Title = "",
                Subtitle = "",
                Text = "",
                Images = new List<CardImage> { new CardImage(imagePath) },
            };
       
            return heroCard.ToAttachment();
        }

        private IList<Attachment> GetCardsAttachments()
        {
            Task<IEnumerable<Vehicle>> cars = new AuctionsDataService().ListVehiclesAsync(_auctionName, _make, _model);
            
            return cars.Result.ToList()
                .Select(c => GetHeroCard(
                            $"{c.Model} - {c.Make}",
                            c.Description,
                            $"{c.Year} - {c.Odometer} - {c.PriceGuide}",
                            new CardImage(url: c.ImageUrl),
                            new CardAction(ActionTypes.PostBack, "Select", value: c)
                            )).ToList();

        }

        private static Attachment GetHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage>() { cardImage },
                Buttons = new List<CardAction>() { cardAction },
            };

            return heroCard.ToAttachment();
        }

        private async Task HandleVehcile(IDialogContext context, IAwaitable<string> result)
        {
            context.Done(await result);
        }
    }
}