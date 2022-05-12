using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace WebviewDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Browser.Source = "https://webapp.staging.carscan.ai/2417/ClientTEST123/081056788/RJ47A912/chander@carscan.co.za/%3F_id%3D626118bec080a1118923b2da";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RunTimePermission();
        }

        public async void RunTimePermission()
        {
            var status = PermissionStatus.Unknown;


            status = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();

            if (status != PermissionStatus.Granted)
            {

                status = await Utils.CheckPermissions(Permission.Camera);
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //var url = "https://" + UrlEntry.Text;
            //Browser.Source = url;
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            RunTimePermission();
        }



    }
}
