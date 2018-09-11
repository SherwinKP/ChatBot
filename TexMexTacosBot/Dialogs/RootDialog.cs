using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using ApiAiSDK;
using TexMexTacosBot.Helpers;

namespace TexMexTacosBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private const string clientAccessToken = "< ADD YOUR DIALOGFLOW/API.AI ACCESS TOKEN HERE >";
        private static AIConfiguration config = new AIConfiguration(clientAccessToken, SupportedLanguage.English);
        private static ApiAi apiAi = new ApiAi(config);

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            var aiResponse = apiAi.TextRequest(string.IsNullOrWhiteSpace(activity.Text) ? "hello" : activity.Text);
            
            await context.PostAsync(aiResponse.Result.Fulfillment.Speech);

            context.Wait(MessageReceivedAsync);
        }
    }
}