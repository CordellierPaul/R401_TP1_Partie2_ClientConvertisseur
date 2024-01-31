using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurViewModelTests
    {
        [TestMethod()]
        public async Task GetDataOnLoadAsyncTest()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Act
            await convertisseurEuro.GetDataOnLoadAsync();
            //Assert
            Assert.IsNotNull(convertisseurEuro.LesDevises);
        }
    }
}