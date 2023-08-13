using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CybersportParser.News
{
    class NewsFeedCybersportDota2 : INewsFeed
    {
        private  string _url = @"https://www.cybersport.ru/tags/dota-2";
        private List<NewsItem> newsItemAll = new List<NewsItem>();
        private static IConfiguration config = Configuration.Default.WithDefaultLoader();
        private IBrowsingContext context = BrowsingContext.New(NewsFeedCybersportDota2.config);
        public string Url
        {
            get { return _url; }
        }
        public  IDocument document;

        public NewsFeedCybersportDota2()
        {
            Start().Wait();
            newsItemAll = GetNewsAll2().Result;
        }

        private async Task Start()
        {
            config = Configuration.Default.WithDefaultLoader();
            context = BrowsingContext.New(config);
            document = await context.OpenAsync(_url);
            //MessageBox.Show("Document is ready");

        }
        private void Method(string link)
        {
            string response = "";
            using (WebClient wc = new WebClient())
            {
                response = wc.DownloadString(link);
            }
            var rates = Regex.Matches(response, @"<div class=""header_Tg4Yz""><div><h3 class=""title_nSS03"">(.*?)</h3>");

        }
        private async Task<IDocument> Run(string link)
        {
            config = Configuration.Default.WithDefaultLoader();
            context = BrowsingContext.New(config);
            IDocument descriptionDocument = await context.OpenAsync(link);
            return descriptionDocument;
        }

        private async Task<List<NewsItem>> GetNewsAll2() 
        {
            int id = 0;
            //List<NewsItem> newsItemAll = new List<NewsItem>();
            IHtmlCollection<IElement> articles = document.QuerySelectorAll("article");
            foreach (IElement article in articles)
            {
                
                string title = article.QuerySelector("h3").TextContent ?? "";

                string description = "";
                string link = article.BaseUrl.Origin + article.QuerySelector("a").GetAttribute("href");
                IDocument descriptionDocument = await Run(link);



                IHtmlCollection<IElement> descriptions = descriptionDocument.QuerySelectorAll("div p");
                foreach (IElement des in descriptions)
                {
                    string text = des.TextContent;
                    description += $"\n\n{text}";
                }


                var imageUrl = article.QuerySelector("img")?.GetAttribute("src");
                
               //var imageUrlElse = imageUrl.GetAttribute("src") ?? " ";
                newsItemAll.Add(new NewsItem(title, link, description, imageUrl, id));
                id++;
            }
            return newsItemAll;
        }

        public List<NewsItem> GetNewsAll()
        {
            return newsItemAll;
        }

        public NewsItem GetFirstNews()
        {
            NewsItem newsFirstItem = newsItemAll[0];
            return newsFirstItem;
        }

        public NewsItem GetNews(int id)
        {
            return newsItemAll[id];
        }

        
    }
}
