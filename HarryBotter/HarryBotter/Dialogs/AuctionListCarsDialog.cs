using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarryBotter.DataService;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class AuctionListCarsDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            //context.PostAsync("Here is a list of auctions");
            var auctions =
                new AuctionsDataService().ListActions();

            var reply = context.MakeMessage();

            reply.AttachmentLayout = AttachmentLayoutTypes.List;
            reply.Attachments =
                auctions.Select(c => GetHeroCard(
                    c.Name,
                    c.State,
                    string.Empty, null,
                    new CardAction(ActionTypes.PostBack, c.Name, value: c.Id)
                )).ToList();
            await context.PostAsync(reply);
            context.Wait<string>(HandleAuctions);
        }

        private static Attachment GetHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {

            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
            };

            return heroCard.ToAttachment();
        }
        private async Task HandleAuctions(IDialogContext context, IAwaitable<string> result)
        {
            context.Done(await result);
        }
    }
}