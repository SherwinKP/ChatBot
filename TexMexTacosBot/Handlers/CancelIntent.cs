using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexMexTacosBot.Models.Common;

namespace TexMexTacosBot.Handlers
{
    public class CancelIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            commonModel.Response.Text = "OK, all cancelled, have a wonderful day!";

            commonModel.Session.EndSession = true;

            return commonModel;
        }
    }
}