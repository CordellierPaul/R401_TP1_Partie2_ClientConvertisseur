using ClientConvertisseurV2.ViewModels;
using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using Microsoft.Extensions.DependencyInjection;
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
    public sealed partial class ConvertisseurEuroPage : Page
    {
        public ConvertisseurEuroPage()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(ConvertisseurEuroViewModel));
        }
    }
}
