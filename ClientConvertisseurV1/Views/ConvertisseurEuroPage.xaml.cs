using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
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
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace ClientConvertisseurV2.Views
{
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<Devise> _lesDevises;
        public ObservableCollection<Devise> LesDevises
        {
            get => _lesDevises;
            set
            {
                _lesDevises = value;
                OnPropertyChanged(nameof(LesDevises));
            }
        }

        public Devise DeviseSelectionnee { get; set; }
        public double MontantEnEuros { get; set; }
        private double _montantEnDevises;

        public double MontantEnDevises
        {
            get => _montantEnDevises;
            set
            {
                _montantEnDevises = value;
                OnPropertyChanged(nameof(MontantEnDevises));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }

        public ConvertisseurEuroPage()
        {
            InitializeComponent();
            DataContext = this;

            GetDataOnLoadAsync();
        }

        private async void GetDataOnLoadAsync()
        {
            IService service = new WSService("http://localhost:5272/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result is null)
                MessageAsync("API non disponible !", "Erreur"); // Utiliser le code de R401 sur Github pour que ça marche
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

        public void btConvertir_Click(object sender, RoutedEventArgs e)
        {
            MontantEnDevises = MontantEnEuros * DeviseSelectionnee.Taux;
        }
    }
}
