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

namespace StepController.Controls
{
    public partial class StepControl : UserControl
    {

        public StepControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<Step> steps
        {
            get
            {
                ObservableCollection<Step> mySteps = new ObservableCollection<Step>();
                foreach (object child in StepGrid.Children)
                {
                    if (child is Step)
                    {
                        mySteps.Add((Step)child);
                    }
                }
                return mySteps;
            }
            set
            {
                StepGrid.Children.Clear();

                if (value == null)
                {
                    ObservableCollection<Step> singleStep = new ObservableCollection<Step>();
                    Step step = new Step();
                    step.stepContent = "1";
                    step.stepLabel = "Step 1";
                    step.stepClickMode = clickMode;
                    singleStep.Add(step);
                    value = singleStep;
                }

                int i = 1;
                foreach (Step step in value)
                {
                    int stepsCount = StepGrid.ColumnDefinitions.Count;
                    ColumnDefinition cd = new ColumnDefinition();
                    cd.Width = new GridLength(50, GridUnitType.Auto);
                    StepGrid.ColumnDefinitions.Add(cd);

                    step.Name = "Step" + i.ToString();
                    step.stepClickMode = clickMode;
                    step.MouseUp += Step_MouseLeftButtonUp;
                    step.SetValue(Grid.ColumnProperty, stepsCount);

                    if (i == 1)
                    {
                        step.stepExtenderVisibility = System.Windows.Visibility.Collapsed;
                    }

                    step.isSelected = false;

                    StepGrid.Children.Add(step);
                    i++;
                }
            }
        }

        private myClickMode clickMode = myClickMode.Step;
        public myClickMode ClickMode
        {
            get { return clickMode; }
            set { clickMode = value; }
        }

        private void Step_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Step step = sender as Step;
            if (step.canClick) { SelectSteps(int.Parse(step.Name.Replace("Step", ""))); }
            step.canClick = false;
        }

        private void SelectSteps(int selected)
        {
            foreach (Step step in steps)
            {
                int stepPosition = int.Parse(step.Name.Replace("Step", ""));

                if (stepPosition < selected)
                {
                    step.isSelected = false;
                    step.isCompleted = true;
                }

                if (stepPosition == selected)
                {
                    if (selected == 1 && step.isCompleted)
                    {
                        step.isSelected = false;
                        step.isCompleted = false;
                    }
                    else
                    {
                        if (step.isCompleted || step.isSelected)
                        {
                            step.isSelected = true;
                            step.isCompleted = false;
                        }
                        //else if (step.isSelected)
                        //{
                        //    step.isSelected = false;
                        //    step.isCompleted = true;
                        //}

                        if (!step.isSelected && !step.isCompleted)
                        {
                            step.isSelected = true;
                            step.isCompleted = true;
                        }
                    }
                }

                if (stepPosition > selected)
                {
                    step.isSelected = false;
                    step.isCompleted = false;
                }
            }
        }
    }
}
