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
            var carMakes = new CarDataService().ListMakes();
            PromptDialog.Choice(context, HandleCarMake, carMakes, "choose a car make please?");
        }

        private async Task HandleCarMake(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            context.Done(message);
        }

        //private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        //{
        //    var message = await result;
        //    await context.PostAsync("Hey there! You said: " + message.Text);
        //    context.Wait(MessageReceivedAsync);
        //}

       
    }
}