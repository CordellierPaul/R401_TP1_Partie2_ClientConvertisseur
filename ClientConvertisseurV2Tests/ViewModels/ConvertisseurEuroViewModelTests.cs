using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurEuroVMTestConstructeur()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }

        [TestMethod()]
        public void ChangerDePageConvertisseurEurosTest()
        {
            ConvertisseurEuroViewModel convertisseur = new ConvertisseurEuroViewModel();

            convertisseur.MontantEnEuros = 5;
            convertisseur.DeviseSelectionnee = new Devise(5, "devise test", 2);
            convertisseur.ActionConvertir();

            Assert.AreEqual(5 * 2, convertisseur.MontantEnDevises, "Erreur avec MontantEnDevises");
            Assert.AreEqual(5, convertisseur.MontantEnEuros, "Erreur avec MontantEnEuros");
            Assert.AreEqual(2, convertisseur.DeviseSelectionnee.Taux, "Erreur avec DeviseSelectionnee.Taux");
        }

        [TestMethod()]
        public void ActionConvertirTest()
        {

        }
    }
}