using Android.App;
using Download.Droid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Objs = new List<CustomItem>();
            Objs.Add("Hello");
            Objs.Add("World");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            Objs.Add("Message");
            BindingContext = this;
        }
        public IList<CustomItem> Objs { get; private set; }
        public static Activity AppContext { get; set; }
        Button btn = null;
        private void Button_Clicked(object sender, EventArgs e)
        {
        }
        private void Dl_OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (btn != null)
                btn.Text = "OK";
        }

        private void ListView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            destiny_box.Text = e.Item.ToString();
        }
    }
    public class CustomItem
    {
        public CustomItem(string content)
        {
            Content = content;
        }
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
        }

        public static implicit operator CustomItem(string v)
        {
            return new CustomItem(v);
        }
    }
}
