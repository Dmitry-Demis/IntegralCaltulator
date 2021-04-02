using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using OxyPlot;
using OxyPlot.Series;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Runtime.CompilerServices;

namespace IntegralCalculating
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private double? lowerIndex;
        private double? higherIndex;
        private double? N;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {

            MyModel = new PlotModel { Title = "2 * x - Math.Log(7 * x) - 12" };
           
            this.Points = new ObservableCollection<DataPoint>();
           Content = 1;
        }

  
        public ObservableCollection<DataPoint> Points { get; private set; }

        public PlotModel MyModel { get; private set; }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Calculate(long numberN=-1)
        {
            if (!double.TryParse(tbLowerLimit.Text, out double lowerLimit))
            {
                MessageBox.Show($"String {tbLowerLimit.Text} can't be parsed to digit");
            }
            if (!double.TryParse(tbHigherLimit.Text, out double higherLimit))
            {
                MessageBox.Show($"String {tbHigherLimit.Text} can't be parsed to digit");
            }
            if (!long.TryParse(tbN.Text, out long N))
            {
                MessageBox.Show($"String {tbN.Text} can't be parsed to digit");
            }
           
                ICalculator calculator = GetCalculator();
                double result = calculator.Calculate(lowerLimit, higherLimit, N, x => 2 * x - Math.Log(7 * x) - 12);
                tbResult.Text = result.ToString();

        }
        private ICalculator GetCalculator()
        {
            switch (cmbMethods.SelectedIndex)
            {
                case 0:
                    return new RectangleCalculator();
                   case 1:
                    return new TrapezeCalculator();
                default: return new RectangleCalculator();
            }
        }



        private void btnBuildGraphic_Click(object sender, RoutedEventArgs e)
        {
           
            long beginN = 1000;
            long lastN = 1_000_000;
            long delta = 1_000;
           Stopwatch beginning = new Stopwatch();
           MainWindow mn = DataContext as MainWindow;
            this.Cursor = Cursors.Wait;
            int k = 0;
            for (long i = beginN; i < lastN; i += delta)
            {
                beginning.Start();
                Calculate(i);
                beginning.Stop();
                var sec = beginning.ElapsedMilliseconds;
                beginning.Reset();
                if (k==10)
                {
                  
                    DataPoint data = new DataPoint(i, sec);
                    mn.Points.Add(data);

                    k = 0;
                }
                k++;
                
            }
            this.Cursor = Cursors.Arrow;
        }
    }

}
