using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace ClientConvertisseurV1.Views
{
    public sealed partial class ConvertisseurEuroPage : Page
    {
        public ObservableCollection<Devise> LesDevises { get; set; }
        public double MontantEnEuros { get; set; }
        public double MontantEnDevises { get; set; }

        public ConvertisseurEuroPage()
        {
            InitializeComponent();
            DataContext = this;
            GetDataOnLoadAsync();
        }

        private async void GetDataOnLoadAsync()
        {
            IService service = new WSService("https://localhost:4561/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result is null)
                MessageAsync("API non disponible !", "Erreur");
            else
                LesDevises = new ObservableCollection<Devise>(result);
        }

        private async void MessageAsync(string content, string title)
        {
            var messageDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"
            };

            messageDialog.XamlRoot = Content.XamlRoot;
            await messageDialog.ShowAsync();
        }
    }
}
