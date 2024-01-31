using ClientConvertisseurV2;
using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public abstract class ConvertisseurViewModel : ObservableObject
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

        private double _montantEnEuros;
        public double MontantEnEuros
        {
            get => _montantEnEuros;
            set
            {
                _montantEnEuros = value;
                OnPropertyChanged();
            }
        }

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
        public IRelayCommand BtnChangerPage { get; }

        public ConvertisseurViewModel()
        {
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
            GetDataOnLoadAsync();
#pragma warning restore CS4014

            BtnConvertir = new RelayCommand(VerificationChampsAvantConversion);
            BtnChangerPage = new RelayCommand(ChangerDePageConvertisseur);
        }

        public void VerificationChampsAvantConversion()
        {
            if (DeviseSelectionnee == null)
            {
                MessageAsync("Quelle devise voulez-vous sélectionner ?", "Erreur");
                return;
            }

            ActionConvertir();
        }

        public abstract void ActionConvertir();

        public abstract void ChangerDePageConvertisseur();

        public async Task GetDataOnLoadAsync()
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

            messageDialog.XamlRoot = App.MainRoot.XamlRoot;
            await messageDialog.ShowAsync();
        }
    }
}