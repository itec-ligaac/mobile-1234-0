using System;
using System.Threading.Tasks;

namespace Outline.Helper
{
    public interface IFirebaseRegister
    {
        Task<String> RegisterWithEmailAndPassword(string email, string password);
    }
}
