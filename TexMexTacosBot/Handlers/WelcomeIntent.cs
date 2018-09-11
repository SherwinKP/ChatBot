using TexMexTacosBot.Models.Common;

namespace TexMexTacosBot.Handlers
{
    public class WelcomeIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            if (commonModel.Request.Channel == "alexa")
            {
                commonModel.Response.Text = "Hi there, I can help you book a table at our restaurant Tex Mex Tacos, if you would like to reserve a table, simply say \"book a table\".";
                commonModel.Response.Prompt = "To book a table, say, \"book a table\".";
            }
            else
            {
                commonModel.Response.Text = "Hi there, would you like to book a table?";
                commonModel.Response.Prompt = "Would you like to book a table? Yes or no?";
            }

            commonModel.Session.EndSession = false;

            return commonModel;
        }
    }
}