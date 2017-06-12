using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class BiddingDialog : IDialog<object>
    {
        private string currentBid;

        public BiddingDialog(string vehicle)
        {
            
        }
        public async Task StartAsync(IDialogContext context)
        {
            context.ConversationData.TryGetValue<string>("CurrentBid", out currentBid);
            if (string.IsNullOrEmpty(currentBid))
            {
                currentBid = "5000";
                context.ConversationData.SetValue<string>("CurrentBid", currentBid);
            }

            PromptDialog.Choice(context, this.AfterSelectOption,
                new string[] { "Bid Now", "Select another car", "Stop Bidding?" },
                $"Current bid is ${currentBid}. Raise Bid?");
        }

        private async Task AfterSelectOption(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            if (message == "Bid Now")
            {
                context.ConversationData.TryGetValue<string>("CurrentBid", out currentBid);
                int currentBidInt = int.Parse(currentBid);
                currentBidInt += 500;
                currentBid = currentBidInt.ToString();
                await context.PostAsync($"Great, your bid of {currentBid} is the highest now!");
                context.ConversationData.SetValue<string>("CurrentBid", currentBid);
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
                context.Done("finished"); //Finish this dialog
            }
        }
    }
}