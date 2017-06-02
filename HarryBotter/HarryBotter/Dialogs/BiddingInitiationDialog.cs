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
            context.Wait(this.MessageReceivedAsync);
        }
       
        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var reply = context.MakeMessage();
            if (message.Value != null)
            {
                Vehicle vehicle = JsonConvert.DeserializeObject<Vehicle>(message.Value.ToString());
                reply.Attachments.Add(GetHeroCard(
                            $"{vehicle.Make} - {vehicle.Model} - {vehicle.Body_Tyep}",
                            $"{vehicle.Model_Year} - {vehicle.Transmission_Type} - {vehicle.Colour}",
                            $"{vehicle.Fuel_Type} - {vehicle.Variant} - {vehicle.Series} - {vehicle.Region} - {vehicle.Description}",
                            new CardImage(url: "https://www.pickles.com.au/getPublicStockImage?id=652327460"),
                            //new CardAction(ActionTypes.OpenUrl, "Show Condition Report", value: "https://www.pickles.com.au/cars/item/-/details/conditionreport/info/103454348")
                            new CardAction(ActionTypes.PostBack, "Show Condition Report", value: "ConditionReport")
                            ));
            }
            else if (message.Text == "ConditionReport")
            {


                reply.Attachments.Add(GetConditionRepoertImage());
               
               
            }
            else
            {
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                reply.Attachments = GetCardsAttachments();


            }

            await context.PostAsync(reply);

            context.Wait(this.MessageReceivedAsync);
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

            return new AuctionsDataService().ListVehicles(_auctionName, _make,_model)
                    .ToList()
                    .Select(c => GetHeroCard(
                            string.Format("{0} {1} {2}", c.Model_Year, c.Make, c.Body_Tyep),
                            string.Format("{0} {1} {2}", c.Auction_Sale_Type, c.Colour, c.Fuel_Type),
                            c.Description,
                            new CardImage(url: string.Format("https://www.pickles.com.au/getPublicStockImage?id=652327{0}", c.Id.Substring(0,3))),
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

        private static Attachment GetThumbnailCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new ThumbnailCard
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