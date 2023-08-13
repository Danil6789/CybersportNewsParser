using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersportParser.News
{
    class NewsItem
    {
        private  string _title;
        private string _link;
        private string _description;
        private string _imageUrl;
        private int _id;
        public NewsItem(string title, string link, string description, string imageUrl, int id)
        {
            _id = id;
            _title = title;
            _link = link;
            _description = description;
            _imageUrl = imageUrl;
        }
        #region Properties
        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
        }
        public string Link
        {
            get
            {
                return _link;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
        }
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
        }
        #endregion
    }
}
