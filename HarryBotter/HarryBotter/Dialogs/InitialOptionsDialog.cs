using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class InitialOptionsDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Choice(context, HandleUserChoice, new[] { "Buy", "Sell", "Inquiry" },
               $"What are you up to today?!", "Please try again, and choose an option.");
        }

        private async Task HandleUserChoice(IDialogContext context, IAwaitable<string> result)
        {
            //result.GetAwaiter().GetResult()
            //TODO: Switch on the result, and forward the activity to the appropriate dialog
            //await context.PostAsync($"You said: {result.GetAwaiter().GetResult()}");
            context.Done(result.GetAwaiter().GetResult());
        }

        //private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        //{
        //    var message = await result;
        //    context.Done(message.Text);
        //}
    }
}