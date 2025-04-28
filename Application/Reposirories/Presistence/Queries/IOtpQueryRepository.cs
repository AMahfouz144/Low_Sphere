using Domain.Otps;
using System;
using System.Threading.Tasks;

namespace Application.Reposirories.Presistence
{
    public interface IOtpQueryRepository
    {
        Task<Otp> GetLastAvailableOtp(string contact, Guid? userId);
    }
}