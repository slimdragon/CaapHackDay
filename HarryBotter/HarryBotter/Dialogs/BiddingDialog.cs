using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class BiddingDialog : IDialog<object>
    {
        public BiddingDialog(string vehicle)
        {
            
        }
        public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Choice(context, this.AfterSelectOption, 
                new string[] { "Bid Now", "Select another car", "Stop Bidding?" },
                "Current bid is A$ 5000. Raise Bid?");
        }

        private async Task AfterSelectOption(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            if (message == "Bid Now")
            {
                await context.PostAsync("Great, Bid Now selected");
                context.Done("StillBidding"); //Finish this dialog
            }
            else if (message == "Select another car")
                {

                await context.PostAsync("Great, I'll show you more cars");
                context.Done("ShowCarousel"); //Finish this dialog
            }
            else
            {
                await context.PostAsync("Ok sure");
                context.Done("ShowCarousel"); //Finish this dialog
            }
        }
    }
}