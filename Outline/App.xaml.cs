using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Outline
{
    public partial class App : Application
    {   
        public static string UserUID { get; set; }
        public static Outline_Configuration conf;
        public App()
        {
            //LoadJson();
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDE3OTE2QDMxMzgyZTM0MmUzMEZCektLN2tROW41NVVBMGhaREY1K0lLTFY0b2FBa1ovNUJyMmNRT3JqZzA9");
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }
       /** void LoadJson()
        {
            Assembly asm = Assembly.GetAssembly(typeof(Outline_Configuration));
            Stream stream = asm.GetManifestResourceStream("Outline.config.json");
            using (var reader = new StreamReader(stream))
            {

                var json = reader.ReadToEnd();
                conf = JsonConvert.DeserializeObject<Outline_Configuration>(json);
            }
        }*/
        protected override void OnResume()
        {
        }
    }
}
