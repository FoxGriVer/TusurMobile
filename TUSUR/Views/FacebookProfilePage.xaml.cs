using System;
using System.Collections.Generic;
using TUSUR.ViewModels;
using Xamarin.Forms;
using TUSUR.Services;
using System.Threading.Tasks;
using TUSUR.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace TUSUR.Views
{
    public partial class FacebookProfilePage : ContentPage
    {
        private string ClientId = "211929996183121";

        public FacebookProfilePage()
        {
            InitializeComponent();

            var apiRequest =
                "https://www.facebook.com/v3.0/dialog/oauth?%20client_id=211929996183121%20&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html%20&state={%22{st=state123abc,ds=123456789}%22}";
            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;

            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {

            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                accessToken = "EAADAv8wjxlEBADdhNRhVw4ogH0VvPIV6kwGOq7JZC6zZBQKBWGk5r4ntMrTrkRgrWfIor6e4UWwal2mZA4ZAOngBhIJA3ZAinG3VMo4kkoEve2CZC8bgqYs82pLppjbe5l95niNXDx0fePbMJ66m1aA9ji66NX9ydD9bXFUcNQ5JrlxRmeYtID";
                //var vm = BindingContext as FacebookViewModel;
                var facebookViewModel = new FacebookViewModel();
                await facebookViewModel.SetFacebookUserProfileAsync(accessToken);
                BindingContext = facebookViewModel.FacebookProfile;
                Content = MainStackLayout;

                //await vm.SetFacebookUserProfileAsync(accessToken);

                //Content = MainStackLayout;
            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            //ДОДЕЛАТЬ ОБРЕЗАНИЕ ТОКЕНА !!! ОБЯЗАТЕЛЬНО !!!!!!!!!
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (Xamarin.Forms.Device.OS == TargetPlatform.WinPhone || Xamarin.Forms.Device.OS == TargetPlatform.Windows)
                {
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in="));

                return accessToken;
            }

            return string.Empty;
        }

    }
}
