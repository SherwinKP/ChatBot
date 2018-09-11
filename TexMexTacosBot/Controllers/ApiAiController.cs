using ApiAiSDK.Model;
using System.Web.Http;
using TexMexTacosBot.Helpers;

namespace TexMexTacosBot.Controllers
{
    public class ApiAiController : ApiController
    {
        public dynamic Post(AIResponse aiResponse)
        {
            var commonModel = CommonModelMapper.ApiAiToCommonModel(aiResponse);
            if (commonModel == null)
                return null;

            commonModel = IntentRouter.Process(commonModel);

            return CommonModelMapper.CommonModelToApiAi(commonModel);
        }

        public string Get()
        {
            return "Hello API.AI!";
        }
    }
}
