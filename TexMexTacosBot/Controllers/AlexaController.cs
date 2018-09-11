using Alexa.NET.Request;
using Alexa.NET.Response;
using System.Web.Http;
using TexMexTacosBot.Helpers;

namespace TexMexTacosBot.Controllers
{
    public class AlexaController : ApiController
    {
        public SkillResponse Post(SkillRequest skillRequest)
        {
            var commonModel = CommonModelMapper.AlexaToCommonModel(skillRequest);
            if (commonModel == null)
                return null;

            if (commonModel.Request.State == null || commonModel.Request.State == "COMPLETED")
            commonModel = IntentRouter.Process(commonModel);

            return CommonModelMapper.CommonModelToAlexa(commonModel);
        }

        public string Get()
        {
            return "Hello Alexa!";
        }
    }
}
