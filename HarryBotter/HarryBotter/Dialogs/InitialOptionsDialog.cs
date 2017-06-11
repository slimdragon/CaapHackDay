using System;
using System.Threading.Tasks;
using HarryBotter.DataService;
using Microsoft.Bot.Builder.Dialogs;

namespace HarryBotter.Dialogs
{
    [Serializable]
    public class InitialOptionsDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            PromptDialog.Text(context,HandleUserChoice,"What are you up to today?!");
        }

        private async Task HandleUserChoice(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            var score = new LuisService().Score(message);
            if (score.Succeeded)
            {
                await context.PostAsync($"I understand your intent is to {score.LuisResult.TopScoringIntent?.Intent}");
                context.Done(
                    score.LuisResult.TopScoringIntent?.Intent.IndexOf("buy a car",
                        StringComparison.InvariantCultureIgnoreCase) >= 0
                        ? "buy"
                        : "other");
            }
            else
                context.Done(message.IndexOf("buy", StringComparison.InvariantCultureIgnoreCase) >= 0 ? "buy" : "other");
        }
    }
}