using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Outline.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleLoginPage
    {
        IFirebaseAuthentication auth;
        public SimpleLoginPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IFirebaseAuthentication>();

        }

        private async void SfButton_Clicked(object sender, System.EventArgs e)
        {
            App.UserUID = await auth.LoginWithEmailAndPassword(EmailEntry.Text,PasswordEntry.Text);
            if(!string.IsNullOrEmpty(App.UserUID) && !string.IsNullOrWhiteSpace(App.UserUID))
            {
                await Navigation.PushAsync(new NGOMainPage());
            }
        }

        private async void SfButton_Clicked_1(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SimpleSignUpPage());
        }
    }
}