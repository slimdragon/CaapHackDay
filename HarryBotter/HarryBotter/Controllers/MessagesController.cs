using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Linq;
using System;
using System.Web;
using System.Collections.Generic;

namespace HarryBotter
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await ProcessingActivity(activity);
            }
            else
            {
                await this.HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private static async Task ProcessingActivity(Activity activity)
        {
            await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
        }

        private async Task<Activity> HandleSystemMessage(Activity activity)
        {
            switch (activity.Type)
            {
                case ActivityTypes.DeleteUserData:
                    // Implement user deletion here
                    // If we handle user deletion, return a real message
                    break;
                case ActivityTypes.ConversationUpdate:
                    // Greet the user the first time the bot is added to a conversation.
                    if (activity.MembersAdded.Any(m => m.Id == activity.Recipient.Id))
                    {
                        var connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                        var response = activity.CreateReply();
                        var attachment = GetWelcomeHeroCard();
                        response.Attachments.Add(attachment);
                        await connector.Conversations.ReplyToActivityAsync(response);
                        await ProcessingActivity(activity);
                    }

                    break;
                case ActivityTypes.ContactRelationUpdate:
                    // Handle add/remove from contact lists
                    break;
                case ActivityTypes.Typing:
                    // Handle knowing that the user is typing
                    break;
                case ActivityTypes.Ping:
                    break;
                default:
                    break;
            };
            return null;
        }

        private static Attachment GetWelcomeHeroCard()
        {
            var imagePath = HttpContext.Current.Server.MapPath("~/images/pickles.png");
            var heroCard = new HeroCard
            {
                Title = "Welcome to Pickles Auctions",
                Subtitle = "",
                Text = "My name is Harry Botter, and I'm here to assist you.",
                Images = new List<CardImage> { new CardImage(imagePath) },
                //Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") }
            };

            return heroCard.ToAttachment();
        }
    }
}