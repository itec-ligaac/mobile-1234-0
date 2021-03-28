using Outline.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Outline.Views.Forms
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleSignUpPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleSignUpPage" /> class.
        /// </summary>
         IFirebaseRegister auth;
        readonly FirebasePointHelper firebaseClient = new FirebasePointHelper();
        public SimpleSignUpPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IFirebaseRegister>();
        }

        private void SfButton_Clicked(object sender, System.EventArgs e)
        {

        }

        private async void SfButton_Clicked_1(object sender, System.EventArgs e)
        {
            string Token = "";
            bool connection = true;
            try
            {
                Token = await auth.RegisterWithEmailAndPassword(EmailEntry.Text,PasswordEntry.Text);
            }
            catch
            {
                connection = false;
            }
            if(connection)
            {
               await firebaseClient.AddNgo(App.UserUID,Address.Text);
                await Navigation.PushAsync(new SimpleLoginPage());
            }
        }
        
    }
}