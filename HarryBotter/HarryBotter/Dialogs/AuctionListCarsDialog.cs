using System;
using System.Linq;
using System.Threading.Tasks;
using HarryBotter.DataService;
using Microsoft.Bot.Builder.Dialogs;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class AuctionListCarsDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var auctions = new AuctionsDataService().ListActions().Select(a => $"{a.Name} - {a.State}");
            PromptDialog.Choice(context, HandleAuctions, auctions, "We have these auctions available.");
        }

        private async Task HandleAuctions(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            context.Done(message);
        }
    }
}