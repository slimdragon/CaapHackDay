using System;
using System.Threading.Tasks;
using HarryBotter.DataService;
using Microsoft.Bot.Builder.Dialogs;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private string _make;
        private string _model;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            context.Call(new InitialOptionsDialog(), AfterInitialOptionsDialog);
        }

        private async Task AfterInitialOptionsDialog(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            if (message.IndexOf("buy", StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                await context.PostAsync("Great! Let's get started.");
                context.Call(new CarMakeDialog(), AfterCarMakeDialog);
                return;
            }
            await context.PostAsync("I'm terribly sorry, I can only help you buy a car at the moment :(");
        }

        private async Task AfterCarMakeDialog(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;
            _make = message.ToString();
            //await context.PostAsync($"One of my friends has a {_make}, and he's really enjoying it!");
            context.Call(new CarModelDialog(_make), AfterCarModelDialog);
        }

        private async Task AfterCarModelDialog(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;
            _model = message.ToString();
            await context.PostAsync($"The good news is, we sell heaps of {_make} {_model}s.");
            context.Call(new BiddingInitiationDialog(string.Empty,_make,_model), AfterBiddingInitiationDialog);
        }

        private async Task AfterBiddingInitiationDialog(IDialogContext context, IAwaitable<string> result)
        {
            var vehicle = await result;
            context.Call(new BiddingDialog(vehicle), AfterBiddingDialog);
        }

        private async Task AfterBiddingDialog(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;
            string text = (string)message;
            if (text == "StillBidding")
            {
                context.Call(new BiddingDialog(text), AfterBiddingDialog);
            }
            else if (text == "ShowCarousel")
            {
                //context.Call(new CarModelDialog(_make), AfterCarModelDialog);
                context.Call(new CarMakeDialog(), AfterCarMakeDialog);
            }
            else
            {
                await context.PostAsync("This is the end of the 2-days version of Harry Botter.");
                context.Call(new InitialOptionsDialog(), AfterInitialOptionsDialog);
            }
        }
    }
}