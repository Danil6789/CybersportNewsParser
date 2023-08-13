using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportParser.News
{
    interface INewsFeed
    {
        NewsItem GetNews(int id);
        NewsItem GetFirstNews();
        List<NewsItem> GetNewsAll();
    }
}
