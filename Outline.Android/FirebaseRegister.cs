using Firebase.Auth;
using Outline.Droid;
using Outline.Helper;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseRegister))]
namespace Outline.Droid
{

        public class FirebaseRegister : IFirebaseRegister
        {
            public async Task<string> RegisterWithEmailAndPassword(string email, string password)
            {
                try
                {
                    var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                    return user.User.Uid;
                }
                catch (FirebaseAuthWeakPasswordException)
                {
                    return "not";
                }
                catch (FirebaseAuthUserCollisionException)
                {
                    return "exsisting";
                }
                catch (Exception)
                {
                    return "";
                }

            }
        
        }
}