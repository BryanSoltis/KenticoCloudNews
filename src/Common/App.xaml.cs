﻿using Common.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace KenticoCloudNews
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new NavigationPage(new BlogPostsPage())
            {
                BackgroundColor = (Color)Current.Resources["colorPrimaryAppBackground"]
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
