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
using ClientConvertisseurV2;
using ClientConvertisseurV2.Views;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel : ConvertisseurViewModel
    {
        public override void ChangerDePageConvertisseur()
        {
            App.Current.RootFrame.Navigate(typeof(ConvertisseurDiversPage));
        }

        public override void ActionConvertir()
        {
            MontantEnDevises = MontantEnEuros * DeviseSelectionnee.Taux;
        }
    }
}
