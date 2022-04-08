using Microsoft.AspNetCore.Mvc;
using Mvc101.Models;
using Mvc101.Services.SmsService;
using System.Diagnostics;
using Mvc101.Services.EmailService;

namespace Mvc101.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmsService _smsService;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IServiceProvider _serviceProvider;

        public HomeController(ISmsService smsService, IEmailService emailService, IWebHostEnvironment appEnvironment, IServiceProvider serviceProvider)
        {
            _smsService = smsService;
            _emailService = emailService;
            _appEnvironment = appEnvironment;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index(int id)
        {
            var result = _smsService.Send(new SmsModel()
            {
                TelefonNo = "12345",
                Mesaj = "home/index çalıştı"
            });

            var wissenSms = (WissenSmsService)_smsService;
            Debug.WriteLine(wissenSms.EndPoint);

            #region Factory Design Pattern Uygulaması

            IEmailService emailService;
            if(id % 2 == 0)
            {
                emailService = _serviceProvider.GetService<SendGridEmailService>();
            }
            else
            {
                emailService = _serviceProvider.GetService<OutlookEmailService>();
            }
            #endregion

            //var fileStream = new FileStream(@$"{_appEnvironment.WebRootPath}\files\traplord.jpg", FileMode.Open);

            _emailService.SendMailAsync(new MailModel()
            {
                To = new List<EmailModel>()
                {
                    new EmailModel()
                    {
                        Name = "Wissen",
                        Adress = "yagizhandemircii@gmail.com"
                    }
                },
                Subject = "Index Açıldı",
                Body = "Bu emailin body kısmıdır",
                //Attachs = new List<Stream>()
                //{
                //    fileStream
                //}
            });

            //fileStream.Close();
            return View();
        }

        public IActionResult Privacy()
        {
            var result = _smsService.Send(new SmsModel()
            {
                TelefonNo = "12345",
                Mesaj = "home/index çalıştı"
            });

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}