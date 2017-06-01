using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            PromptDialog.Choice(context, HandleUserChoice, new [] { "Buy", "Sell", "Inquiry" }, "What are you up to today?!",string.Empty);
        }

        private async Task HandleUserChoice(IDialogContext context, IAwaitable<string> result)
        {
            //result.GetAwaiter().GetResult()
            //TODO: Switch on the result, and forward the activity to the appropriate dialog
            await context.PostAsync($"You said: {result.GetAwaiter().GetResult()}");
        }
    }
}