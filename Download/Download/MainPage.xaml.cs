using Download.Droid;
using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;

namespace Download
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        Button btn = null;
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (url_box.Text != null && destiny_box.Text != null && System.IO.Directory.Exists(new System.IO.FileInfo(destiny_box.Text).DirectoryName))
            {
                AndroidDownloader dl = DependencyService.Get<AndroidDownloader>();
                dl.OnFileDownloaded += Dl_OnFileDownloaded;
                if (!Directory.Exists(destiny_box.Text))
                    Directory.CreateDirectory(destiny_box.Text);
                destiny_box.Text = Xamarin.Essentials.FileSystem.CacheDirectory;
                dl.DownloadFile(url_box.Text, Path.Combine(destiny_box.Text, "update.dat"));
                btn = (Button)sender;
            }
        }

        private void Dl_OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (btn != null)
                btn.Text = "OK";
        }
    }
}
