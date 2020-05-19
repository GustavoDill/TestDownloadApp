using Android.App;
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
        public static Activity AppContext { get; set; }
        Button btn = null;
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (url_box.Text != null && destiny_box.Text != null && System.IO.Directory.Exists(destiny_box.Text))
            {
                if (btn == null)
                    btn = (Button)sender;
                var flag = false;
                try { File.Move(url_box.Text, destiny_box.Text); flag = true; } catch { }
                var t = flag ? Android.Widget.Toast.MakeText(AppContext, "File moved", Android.Widget.ToastLength.Short) : Android.Widget.Toast.MakeText(AppContext, "Cannot move file", Android.Widget.ToastLength.Short);
                t.Show();
            }
        }
        private void Dl_OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (btn != null)
                btn.Text = "OK";
        }
    }
}
