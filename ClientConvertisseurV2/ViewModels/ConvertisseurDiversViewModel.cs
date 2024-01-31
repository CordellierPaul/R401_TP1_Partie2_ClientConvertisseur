using ClientConvertisseurV2;
using ClientConvertisseurV2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDiversViewModel : ConvertisseurViewModel
    {
        public override void ChangerDePageConvertisseur()
        {
            App.Current.RootFrame.Navigate(typeof(ConvertisseurEuroPage));
        }

        public override void ActionConvertir()
        {
            MontantEnEuros = MontantEnDevises / DeviseSelectionnee.Taux;
        }
    }
}
