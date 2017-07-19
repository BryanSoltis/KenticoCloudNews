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
        public const string BodyCodename = "body";
        public const string HeaderImageCodename = "header_image";
        public const string HeaderImage2xCodename = "header_image_2x";
        public const string HeaderImageTextCodename = "header_image_text";
        public const string TopicCodename = "topic";
        public const string AttachmentsCodename = "attachments";
        public const string MetadataTitleCodename = "metadata___title";
        public const string MetadataDescriptionCodename = "metadata___description";
        public const string UrlSlugCodename = "url_slug";
        public const string CanonicalLinksCodename = "canonical_links";
        public const string ImageBehaviorCodename = "image_behavior";
        public const string ModularBodyCodename = "modular_body";
        public const string YoutubeVideoIdCodename = "youtube_video_id";
        public const string SlideshareKeyCodename = "slideshare_key";

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
