using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace ClientConvertisseurV1.ViewModels
{
    public class ConvertisseurEuroViewModel : ObservableObject
    {
        private ObservableCollection<Devise> _lesDevises;
        public ObservableCollection<Devise> LesDevises
        {
            get => _lesDevises;
            set
            {
                _lesDevises = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        public IRelayCommand BtnConvertir { get; }

        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();

            BtnConvertir = new RelayCommand(ActionConvertir);
        }

        private void ActionConvertir()
        {
            MontantEnDevises = MontantEnEuros * DeviseSelectionnee.Taux;
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

            //messageDialog.XamlRoot = Content.XamlRoot;
            await messageDialog.ShowAsync();
        }
    }
}
