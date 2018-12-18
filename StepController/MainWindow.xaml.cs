using StepController.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StepController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Step> mySteps = new ObservableCollection<Step>();

        public MainWindow()
        {
            InitializeComponent();
            LoadProgressIndicator();
        }

        private void LoadProgressIndicator()
        {
            for (int i = 0; i < 4; i++)
            {
                Add_Click(this, null);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string stepNum = (mySteps.Count + 1).ToString();

            Step step = new Step
            {
                stepLabel = "Step " + stepNum,
                stepContent = stepNum
            };
            mySteps.Add(step);
            progressIndicator.steps = mySteps;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            mySteps.RemoveAt(mySteps.Count - 1);
            progressIndicator.steps = mySteps;
        }
    }
}
