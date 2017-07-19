using Common.Helpers;
using Common.Models;
using Common.Services;
using Common.ViewModels;
using Common.Views;
using System;
using Xamarin.Forms;

namespace XamarinDelivery
{
    public partial class MainPage : ContentPage
    {
        private string strStandardMessage = "What the? Hmm...something didn't go right.\n\nMaybe wait a little bit and try again.";
        private readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            _viewModel = new MainPageViewModel(new KenticoCloudService());
            InitializeComponent();
            RefreshBlogPosts(0);
        }

        public async void RefreshBlogPosts(int intDelay = 0)
        {
            // Show the refreshing message
            slLoading.IsVisible = true;
            try
            {
                await General.Sleep(intDelay);
                var blogposts = await _viewModel.GetBlogPosts();
                LVBlogPosts.ItemsSource = blogposts;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            slLoading.IsVisible = false;
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            RefreshBlogPosts(1000);
        }

        private void MessageButton_Clicked(object sender, EventArgs e)
        {
            slMessage.IsVisible = false;
        }

        async System.Threading.Tasks.Task OnSelectionAsync(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            try
            {
                BlogPost blog = (BlogPost)e.SelectedItem;

                Device.OpenUri(new Uri("https://kenticocloud.com/blog/" + blog.UrlSlug.ToString()));
                ((ListView)sender).SelectedItem = null;

                await Navigation.PushAsync(new BlogPostDetailPage(new BlogPostDetailViewModel(blog)));

                // Manually deselect item
                LVBlogPosts.SelectedItem = null;

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
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
