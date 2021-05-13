using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = crawler.urlsDownloaded;
            UrlTextBox.Text = crawler.StartUrl;
            SimpleCrawler.DownloadMsg += Crawler_PageDownloaded;
        }
        public SimpleCrawler crawler = new SimpleCrawler();
        
        private void Crawler_PageDownloaded(SimpleCrawler crawler, string url, string info)
        {
            var pageInfo = new { Index = bindingSource1.Count + 1, URL = url, Status = info };
            Action action = () => { bindingSource1.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            int Number = 0;
            int.TryParse(NumberTextBox.Text, out Number); 
            bindingSource1.DataSource = crawler.urlsDownloaded;
            new Thread(crawler.crawl).Start();      
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            crawler.Stopped = true;
        }
    }
}
