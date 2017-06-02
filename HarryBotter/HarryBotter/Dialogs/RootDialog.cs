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
                context.Call(new VehicleTypeDialog(), AfterVehicleTypeDialog);
                return;
            }
            await context.PostAsync("I'm terribly sorry, I cannot do Selling or Inquiry at the moment :(");
        }

        private async Task AfterVehicleTypeDialog(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            if (message.IndexOf("car", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                await context.PostAsync("You can rely on us on providing high-quality, as well as cost efficient, cars .. ");
                context.Call(new CarMakeDialog(), AfterCarMakeDialog);
                return;
            }
            context.PostAsync("Sorry, I only do cars!");
            context.PostAsync("Call us on 1300 Pickles Auctions!");
        }

        private async Task AfterCarMakeDialog(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;
            _make = message.ToString();
            await context.PostAsync($"One of my friends has a {_make}, and he's really enjoying it!");
            context.Call(new CarModelDialog(_make), AfterCarModelDialog);
        }

        private async Task AfterCarModelDialog(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result;
            _model = message.ToString();
            await context.PostAsync($"The good news is, we sell heaps of {_make} {_model}s.");
            context.Call(new AuctionListCarsDialog(), AfterAuctionsListDialog);
        }

        private async Task AfterAuctionsListDialog(IDialogContext context, IAwaitable<string> result)
        {
            var auction = await result;
            context.Call(new BiddingInitiationDialog(auction, _make, _model), AfterBiddingInitiationDialog);
        }

        private async Task AfterBiddingInitiationDialog(IDialogContext context, IAwaitable<string> result)
        {
            var vehicle = await result;
            context.Call(new BiddingDialog(vehicle), AfterBiddingDialog);
        }

        private async Task AfterBiddingDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.PostAsync("Thank you!");
        }
    }
}