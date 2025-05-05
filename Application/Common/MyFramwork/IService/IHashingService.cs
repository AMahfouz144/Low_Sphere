using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.MyFramwork
{
    public interface IHashingService
    {
        string CreateSalt();
        string Create(string value, string salt);
        bool Validate(string value, string salt, string hash);
    }
}
