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
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            context.PostAsync("Hi there. Welcome to Pickles Auctions.");
            await context.PostAsync("My name is Harry Botter, and I'm here to assist you.");
            context.Call(new InitialOptionsDialog(), AfterInitialOptionsDialog);
        }

        private async Task AfterInitialOptionsDialog(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            if (message.Equals("buy", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.PostAsync("Great! Let's get started.");
                context.Call(new VehicleTypeDialog(), AfterVehicleTypeDialog);
                return;
            }
            await context.PostAsync("I'm terribly sorry, I cannot do Selling or Inquiry at the moment :(");
        }

        private async Task AfterVehicleTypeDialog(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;

            if(message == "Car")
            {
                context.Call(new CarMakeDialog(), AfterCarMakeDialog);

            }
        }

        private async Task AfterCarMakeDialog(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;

            

        }
    }
}