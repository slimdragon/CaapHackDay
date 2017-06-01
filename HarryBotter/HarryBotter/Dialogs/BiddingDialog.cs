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
        public Task StartAsync(IDialogContext context)
        {
            throw new NotImplementedException();
            //Start the bidding timer!
        }
    }
}