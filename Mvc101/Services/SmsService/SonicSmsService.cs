using System.Diagnostics;
using Mvc101.Models;

namespace Mvc101.Services.SmsService
{
    public class SonicSmsService : ISmsService
    {
        public SmsStates Send(SmsModel model)
        {
            Debug.WriteLine($"Sonic: {model.TelefonNo} - {model.Mesaj}");
            return SmsStates.Sent;
        }
    }
}