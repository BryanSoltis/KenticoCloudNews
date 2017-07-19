using System.Linq;

namespace XamFormsSample
{
    public partial class Article
    {
        public string ImageUrl => TeaserImage.FirstOrDefault().Url;
    }
}
