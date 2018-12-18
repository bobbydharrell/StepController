using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class Step : UserControl
    {
        public Step()
        {
            InitializeComponent();
        }

        public SolidColorBrush stepFill
        {
            get { return (SolidColorBrush)myStepFill.Background; }
            set
            {
                if (value == null) value = new SolidColorBrush(Colors.Green);
                myStepFill.Background = value;
            }
        }

        public SolidColorBrush stepBackground
        {
            get { return (SolidColorBrush)myStepBackground.Background; }
            set
            {
                if (value == null) value = new SolidColorBrush(Colors.LightGray);
                myStepBackground.Background = value;
            }
        }

        public SolidColorBrush stepContentForeground
        {
            get { return (SolidColorBrush)myStepContent.Foreground; }
            set
            {
                if (value == null) value = new SolidColorBrush(Colors.Gray);
                myStepContent.Foreground = value;
            }
        }

        public SolidColorBrush stepLabelForeground
        {
            get { return (SolidColorBrush)myStepLabel.Foreground; }
            set
            {
                if (value == null) value = new SolidColorBrush(Colors.Gray);
                myStepLabel.Foreground = value;
            }
        }

        public double stepLabelFontSize
        {
            get { return myStepLabel.FontSize; }
            set
            {
                myStepLabel.FontSize = value;
            }
        }

        public string stepLabel
        {
            get { return myStepLabel.Text; }
            set
            {
                if (value == null) value = "Step 1";
                myStepLabel.Text = value;
            }
        }

        public double stepContentFontSize
        {
            get { return myStepContent.FontSize; }
            set
            {
                myStepContent.FontSize = value;
            }
        }

        public string stepContent
        {
            get { return myStepContent.Text; }
            set
            {
                if (value == null) value = "1";
                myStepContent.Text = value;
            }
        }

        private myClickMode clickMode = myClickMode.Step;
        public myClickMode stepClickMode
        {
            get { return clickMode; }
            set { clickMode = value; }
        }

        private bool clickable = false;
        public bool canClick
        {
            get { return clickable; }
            set
            {
                clickable = value;
            }
        }

        public bool isSelected
        {
            get { return (myStepFill.Visibility == System.Windows.Visibility.Visible && target.Visibility == System.Windows.Visibility.Visible) ? true : false; }
            set
            {
                //if (value)
                //{
                //    myStepFill.Visibility = System.Windows.Visibility.Visible;
                //    target.Visibility = System.Windows.Visibility.Visible;
                //    check.Visibility = System.Windows.Visibility.Collapsed;
                //}
                //else
                //{
                    myStepFill.Visibility = System.Windows.Visibility.Collapsed;
                    target.Visibility = System.Windows.Visibility.Collapsed;
                    check.Visibility = System.Windows.Visibility.Collapsed;
                //}
            }
        }

        public bool isCompleted
        {
            get { return (myStepFill.Visibility == System.Windows.Visibility.Visible && check.Visibility == System.Windows.Visibility.Visible) ? true : false; }
            set
            {
                if (value && isSelected == false)
                {
                    myStepFill.Visibility = System.Windows.Visibility.Visible;
                    target.Visibility = System.Windows.Visibility.Collapsed;
                    check.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        public Visibility stepExtenderVisibility
        {
            get { return myStepExtender.Visibility; }
            set
            {
                myStepExtender.Visibility = value;
            }
        }

        public Visibility stepLabelVisibility
        {
            get { return myStepLabel.Visibility; }
            set
            {
                myStepLabel.Visibility = value;
            }
        }

        public Visibility stepContentVisibility
        {
            get { return myStepContent.Visibility; }
            set
            {
                myStepContent.Visibility = value;
            }
        }

        private void myStepBackground_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (clickMode == myClickMode.Step || clickMode == myClickMode.Whole) clickable = true;
        }

        private void myStepLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (clickMode == myClickMode.Label || clickMode == myClickMode.Whole) clickable = true;
        }

        private void StepGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (clickMode == myClickMode.Whole) clickable = true;
        }
    }
}
