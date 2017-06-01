using System;
using System.Linq;
using System.Threading.Tasks;
using HarryBotter.DataService;
using Microsoft.Bot.Builder.Dialogs;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class BiddingInitiationDialog : IDialog<string>
    {
        private readonly string _auctionName;
        private readonly string _make;

        public BiddingInitiationDialog(string auctionName, string make)
        {
            _auctionName = auctionName;
            _make = make;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var vehicles =
                new AuctionsDataService().ListVehicles(_auctionName, _make)
                    .ToList()
                    .Select(c => $"{c.Colour} {c.Make} made in {c.Model_Year}: {c.Description}");

            PromptDialog.Choice(context, HandleVehcile, vehicles,
                $"We have {vehicles.Count()} vehicles available. Choose one to start bidding");

        }

        private async Task HandleVehcile(IDialogContext context, IAwaitable<string> result)
        {
            context.Done(await result);
        }
    }
}