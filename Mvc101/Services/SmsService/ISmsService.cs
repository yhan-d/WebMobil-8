using Mvc101.Models;

namespace Mvc101.Services.SmsService
{
    public interface ISmsService
    {
        SmsStates Send(SmsModel model);
    }
}
