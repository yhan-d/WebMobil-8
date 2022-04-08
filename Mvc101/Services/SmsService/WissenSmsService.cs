using System.Diagnostics;
using Mvc101.Models;

namespace Mvc101.Services.SmsService
{
    public class WissenSmsService : ISmsService
    {
        public string EndPoint { get; set; } = "https://wissenakademie.com";
        public SmsStates Send(SmsModel model)
        {
            Debug.WriteLine($"Wissen: {model.TelefonNo} - {model.Mesaj}");
            return SmsStates.Sent;
        }
    }
}