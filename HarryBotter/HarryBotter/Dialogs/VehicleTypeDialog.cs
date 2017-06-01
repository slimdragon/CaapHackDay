using System;
using System.Threading.Tasks;
using HarryBotter.DataService;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class VehicleTypeDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var vehicleTypes = new VehicleTypesDataService().ListVehicleTypes();
            PromptDialog.Choice(context, HandleVehicleType, vehicleTypes,"What vehicle type?");
        }

        private async Task HandleVehicleType(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;

            await context.PostAsync("Thanks!");
            context.Done(result.GetAwaiter().GetResult());

            
      
            
        }
    }
}