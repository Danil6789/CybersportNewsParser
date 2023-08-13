using CybersportParser.News;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CybersportParser
{
    public partial class Form1 : Form
    {
        NewsFeedCybersportDota2 newsFeedCybersportDota2 = new NewsFeedCybersportDota2();
        List<NewsItem> articles;
        //public IConfiguration config = Configuration.Default.WithDefaultLoader();
        //public IBrowsingContext context = BrowsingContext.New(config);
        //string url = @"https://www.cybersport.ru/tags/dota-2";x
        //IDocument doc = await context.OpenAsync(url);
        //string title = doc.Title;
        //IHtmlCollection<IElement> items = doc.QuerySelectorAll("h3");
        NewsItem newsItem;
        public Form1()
        {
            InitializeComponent();
            var open = newsFeedCybersportDota2.document;
            articles = newsFeedCybersportDota2.GetNewsAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newsItem = newsFeedCybersportDota2.GetFirstNews();
            label1.Text = newsItem.Title;
            textBox1.Text = newsItem.Description;
            pictureBox1.ImageLocation = newsItem.ImageUrl;
            textBox1.Select(0, 0);
        }

        int i = 0;
        int index = 0;
        private void button1_Click(object sender, EventArgs e)
        {

            //label2.Text = i.ToString();
            //label3.Text = index.ToString();
            i++;
            index = newsItem.Id + 1;
            if (index >= 25)
            {
                index = 0;
                i = 0;
            }
            NewsItem newsItemCurrent = newsFeedCybersportDota2.GetNews(index);
            label1.Text = newsItemCurrent.Title;
            textBox1.Text = newsItemCurrent.Description;
            pictureBox1.ImageLocation = newsItemCurrent.ImageUrl;
            newsItem = newsItemCurrent;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //label2.Text =  i.ToString();
            //label3.Text = index.ToString();

            i--;
            index--;
            if (index < 0)
            {
                index = articles.Count - 1;
            }

            NewsItem newsItemCurrent = newsFeedCybersportDota2.GetNews(index);
            label1.Text = newsItemCurrent.Title;
            textBox1.Text = newsItemCurrent.Description;
            pictureBox1.ImageLocation = newsItemCurrent.ImageUrl;
            newsItem = newsItemCurrent;

        }

    }
}
