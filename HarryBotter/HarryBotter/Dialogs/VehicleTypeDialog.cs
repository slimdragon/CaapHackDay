using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronic;
using HarryBotter.DataService;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class VehicleTypeDialog : IDialog<string>
    {
        private readonly List<string> _vehicleTypes;

        public VehicleTypeDialog()
        {
            _vehicleTypes = new VehicleTypesDataService().ListVehicleTypes().ToList();

        }
        public async Task StartAsync(IDialogContext context)
        {
            ShowMessage(context);
        }

        private async Task HandleVehicleType(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            if (_vehicleTypes.Any(a => message.IndexOf(a) >= 0))
            {
                await context.PostAsync("Thanks!");
                context.Done(await result);
            }
            else
            {
                ShowMessage(context);
            }
        }

        private void ShowMessage(IDialogContext context)
        {
            PromptDialog.Text(context,HandleVehicleType, $"We sell {string.Join(", ", _vehicleTypes)}, what are you after?","What's that?!");
        }
    }
}