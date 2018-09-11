using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexMexTacosBot.Models.Common;

namespace TexMexTacosBot.Handlers
{
    public class YesIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            commonModel.Response.Event = "RESERVATIONS";

            return commonModel;
        }
    }
}