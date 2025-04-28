using Domain.Otps;

namespace Application.Reposirories.Presistence
{
    public interface IOtpRepository
    {
        void Add(Otp otp);
        void Update(Otp otp);
    }
}