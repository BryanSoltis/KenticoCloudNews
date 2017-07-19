using KenticoCloud.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public partial class BlogPost
    {
        public const string Codename = "blog_post";
        public const string TitleCodename = "title";
        public const string PerexCodename = "perex";
        public const string DateCodename = "date";
        public const string AuthorCodename = "author";
        public const string HeaderImageCodename = "header_image";
        public const string TopicCodename = "topic";
        public const string UrlSlugCodename = "url_slug";

        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public IEnumerable<Author> Author { get; set; }
        public IEnumerable<Asset> HeaderImage { get; set; }
        public string UrlSlug { get; set; }
        public ContentItemSystemAttributes System { get; set; }
        public IEnumerable<MultipleChoiceOption> Topic { get; set; }
        public string Perex { get; set; }
    }
}
