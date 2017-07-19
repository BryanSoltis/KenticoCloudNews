using Common.Models;
using Common.ViewModels;
using System;
using Xamarin.Forms;

namespace Common.Views
{
    public partial class BlogPostDetailPage : ContentPage
    {
        BlogPostDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public BlogPostDetailPage()
        {
            InitializeComponent();
        }

        public BlogPostDetailPage(BlogPostDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAuthorBlogPosts(viewModel.BlogPost.AuthorInternalName);
        }
        
        private void ViewArticleClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;            
            Device.OpenUri(new Uri("https://kenticocloud.com/blog/" + btn.CommandParameter));
        }

        private async void BackClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BlogPostsPage());
        }


        public async void GetAuthorBlogPosts(string strAuthor)
        {
            // Get author blogs            
            Services.KenticoCloudService service = new Services.KenticoCloudService();
            var authorblogposts = await service.GetAuthorBlogPosts(strAuthor);
            lvAuthorBlogPosts.ItemsSource = authorblogposts;
        }
        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            try
            {
                BlogPost blog = (BlogPost)e.SelectedItem;
                await Navigation.PushAsync(new BlogPostDetailPage(new BlogPostDetailViewModel(blog)));
                
                // Manually deselect item
                lvAuthorBlogPosts.SelectedItem = null;

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void MessageButton_Clicked(object sender, EventArgs e)
        {
            slMessage.IsVisible = false;
        }
        protected void HandleException(Exception ex)
        {
#if DEBUG
            ShowMessage(ex.Message);
#else
                ShowMessage(strStandardMessage);
#endif
        }

        protected void ShowMessage(string strMessageText)
        {
            if (strMessageText != "")
            {
                lblMessage.Text = strMessageText;
                slMessage.IsVisible = true;
            }
            else
            {
                slMessage.IsVisible = false;
            }
        }

    }
}