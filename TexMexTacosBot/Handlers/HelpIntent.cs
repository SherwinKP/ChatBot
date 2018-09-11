using TexMexTacosBot.Models.Common;

namespace TexMexTacosBot.Handlers
{
    public class HelpIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            commonModel.Response.Text = "Hola and welcome to Tex Mex Tacos. I can help you book a table to our restaurant, to do so, say \"book a table\"?";
            commonModel.Response.Prompt = "If you want to book a table, say, \"book a table\".";

            commonModel.Session.EndSession = false;

            return commonModel;
        }
    }
}