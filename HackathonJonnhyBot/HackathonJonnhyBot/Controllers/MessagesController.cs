using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;

namespace HackathonJonnhyBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {

                var mbld = new Dialogs.MeBotLuisDialog();

                StateClient stateClient = activity.GetStateClient();
                BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                mbld.rating = userData.GetProperty<int>("rating");
                mbld.flagGreetingDone = userData.GetProperty<int>("flagGreetingDone");
                mbld.flagCityInformed = userData.GetProperty<int>("flagCityInformed");
                mbld.flagAgeInformed = userData.GetProperty<int>("flagAgeInformed");
                mbld.flagStateInformed = userData.GetProperty<int>("flagStateInformed");
                mbld.flagCityObtained = userData.GetProperty<int>("flagCityObtained");
                mbld.flagAgeObtained = userData.GetProperty<int>("flagAgeObtained");
                mbld.flagStateObtained = userData.GetProperty<int>("flagStateObtained");
                mbld.flagSexualLevel = userData.GetProperty<int>("flagSexualLevel");
                mbld.flagInformalLevel = userData.GetProperty<int>("flagInformalLevel");
                mbld.flagMispellingLevel = userData.GetProperty<int>("flagMispellingLevel");
                mbld.flagEmotionalLevel = userData.GetProperty<int>("flagEmotionalLevel");
                
                await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);

                await Conversation.SendAsync(activity, () => mbld);


                stateClient = activity.GetStateClient();
                userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                userData.SetProperty<int>("flagGreetingDone", mbld.flagGreetingDone);
                userData.SetProperty<int>("flagCityInformed", mbld.flagCityInformed);
                userData.SetProperty<int>("flagAgeInformed", mbld.flagAgeInformed);
                userData.SetProperty<int>("flagStateInformed", mbld.flagStateInformed);
                userData.SetProperty<int>("flagCityObtained", mbld.flagCityObtained);
                userData.SetProperty<int>("flagAgeObtained", mbld.flagAgeObtained);
                userData.SetProperty<int>("flagStateObtained", mbld.flagStateObtained);
                userData.SetProperty<int>("flagSexualLevel", mbld.flagSexualLevel);
                userData.SetProperty<int>("flagInformalLevel", mbld.flagInformalLevel);
                userData.SetProperty<int>("flagMispellingLevel", mbld.flagMispellingLevel);
                userData.SetProperty<int>("flagEmotionalLevel", mbld.flagMispellingLevel);
                
                await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);

            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}