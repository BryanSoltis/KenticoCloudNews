using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Models
{
    public partial class BlogPost
    {
        public string ImageUrl => HeaderImage.FirstOrDefault().Url;
        public string AuthorName => Author.FirstOrDefault().System.Name;
        public string AuthorInternalName => Author.FirstOrDefault().System.Codename;
        public string PerexText => Regex.Replace(Perex.ToString().Replace("&nbsp;",""), "<.*?>", String.Empty);
        public string TopicName => Topic.FirstOrDefault()?.Name ?? "General";
    }
}
