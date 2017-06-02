using System;
using System.Linq;
using System.Threading.Tasks;
using HarryBotter.DataService;
using Microsoft.Bot.Builder.Dialogs;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class CarModelDialog : IDialog<object>
    {
        private readonly string _make;

        public CarModelDialog(string make)
        {
            _make = make;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var carModels = new CarDataService().ListModels(_make);
            if(carModels.Count() == 1)
                PromptDialog.Choice(context, HandleCarModel, carModels, $"Awesome! .. We have only one model of {_make}");
                else
            PromptDialog.Choice(context, HandleCarModel, carModels, $"Classy! .. and what kind of {_make} are you after?");
        }

        private async Task HandleCarModel(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            context.Done(message);
        }
    }
}