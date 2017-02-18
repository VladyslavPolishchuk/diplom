using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoreLib;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Collections.ObjectModel;

namespace k_means
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecognitionByLloidHelper helper = new RecognitionByLloidHelper();
        public MainWindow()
        {
            InitializeComponent();
            var Data = new ObservableCollection<System.Windows.Point>();
            chart.DataContext = this;
            Data.Add(new System.Windows.Point() { X = 1, Y = 2 });
            Data.Add(new System.Windows.Point() { X = 10, Y = 20 });
            Data.Add(new System.Windows.Point() { X = 1, Y = 2 });
            chart.AddLineChart(Data);
            //chart.
            //var points = new List<Point>();
            //for(int i=0;)
        }

        private void LoadDataClick(object sender, RoutedEventArgs e)
        {
            helper.LoadDataFromFile();
        }
    }
}
