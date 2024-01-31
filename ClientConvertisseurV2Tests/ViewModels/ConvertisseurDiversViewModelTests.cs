using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurDiversViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurDiversVMTestConstructeur()
        {
            ConvertisseurDiversViewModel convertisseur = new ConvertisseurDiversViewModel();
            Assert.IsNotNull(convertisseur);
        }

        [TestMethod()]
        public void ChangerDePageConvertisseurDiversTest()
        {
            ConvertisseurDiversViewModel convertisseur = new ConvertisseurDiversViewModel();

            convertisseur.MontantEnDevises = 10;
            convertisseur.DeviseSelectionnee = new Devise(5, "devise test", 2);
            convertisseur.ActionConvertir();

            Assert.AreEqual(10 / 2, convertisseur.MontantEnEuros, "Erreur avec MontantEnEuros");
            Assert.AreEqual(10, convertisseur.MontantEnDevises, "Erreur avec MontantEnDevises");
        }

        [TestMethod()]
        public void ActionConvertirTest()
        {

        }
    }
}