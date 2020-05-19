using System;
using System.ComponentModel;
using System.Net;

namespace Download.Droid
{
    public class DownloadEventArgs : EventArgs
    {
        public bool FileSaved = false;
        public DownloadEventArgs(bool fileSaved)
        {
            FileSaved = fileSaved;
        }
    }
    public class AndroidDownloader
    {
        public event EventHandler<DownloadEventArgs> OnFileDownloaded;
        public delegate string MyDelegate(string a);
        public void DownloadFile(string url, string destiny)
        {

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadFileAsync(new Uri(url), destiny);
            }
            catch
            {
                OnFileDownloaded?.Invoke(this, new DownloadEventArgs(false));
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            OnFileDownloaded?.Invoke(this, new DownloadEventArgs(e.Error == null));
        }
    }
}