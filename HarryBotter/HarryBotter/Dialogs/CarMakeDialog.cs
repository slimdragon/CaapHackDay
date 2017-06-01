using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using HarryBotter.DataService;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class CarMakeDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            await context.PostAsync("Hey there! You said: " + message.Text);
            context.Wait(MessageReceivedAsync);
        }

        private async Task AfterMakeAsync(IDialogContext context, IAwaitable<string> result)
        {
            var text = await result;

            await context.PostAsync("inside AfterResetAsync");

            context.Wait(MessageReceivedAsync);
        }
    }
}