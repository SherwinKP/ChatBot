using System;
using System.Linq;
using TexMexTacosBot.Models.Common;

namespace TexMexTacosBot.Handlers
{
    public class ReservationsIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            var time = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "time");
            var date = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "date");
            var number = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "number");

            var code = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();

            short.TryParse(number.Value, out short guests);

            using (var data = new TexMexTacosBot.Data.TexMexTacosDataEntities())
            {
                data.Reservations.Add(new Data.Reservation
                {
                    Code = code,
                    Guests = guests,
                    Date = date.Value,
                    Time = time.Value,
                    DateRequested = DateTime.UtcNow
                });

                data.SaveChanges();
            }
            
            commonModel.Response.Ssml = $"Perfect, your table for {number.Value} is reserved for {time.Value}. " +
                $"When you arrive, give them the confirmation code, <say-as interpret-as=\"spell-out\">{code}</say-as>. " +
                $"Buen provecho!";

            commonModel.Response.Text = $"Perfect, your table for {number.Value} is reserved for {time.Value}. " +
                $"When you arrive, give them the confirmation code, {code}. Buen provecho!";

            commonModel.Response.Card = new Card
            {
                Title = "Tex Mex Tacos Reservations",
                Text = $"Your table for {number.Value} is reserved for {time.Value} on {date.Value}. Your confirmation code is {code}. Buen provecho!"
            };

            commonModel.Session.EndSession = true;

            return commonModel;
        }
    }
}