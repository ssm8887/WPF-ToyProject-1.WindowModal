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
using UControl;
using Xceed;
using Xceed.Wpf.Toolkit;

namespace ModalWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            BottomButton_1.Click += BottomButton_1_Click;
            BottomButton_2.Click += BottomButton_2_Click;
            BottomButton_3.Click += BottomButton_3_Click;
            Button_Display_On.Click += Button_Display_On_Click;
            Button_Display_Off.Click += Button_Display_Off_Click;
            Button_Modal_Close.Click += Button_Modal_Close_Click;
        }


        private void BottomButton_1_Click(object sender, RoutedEventArgs e)
        {
            var modal = new UControl.Modal(300, 200);

            this.canvas.Children.Add(modal);
            //Canvas.SetZIndex(modal, -5);

            modal.IsModal = true;
        }

        private void BottomButton_2_Click(object sender, RoutedEventArgs e)
        {
            var childWindow = new ChildWindow();
            childWindow.Width = 200;
            childWindow.Height = 160;
            childWindow.Content = "World";

            this.canvas.Children.Add(childWindow);

            childWindow.Show();
            childWindow.IsModal = true;

        }

        private void BottomButton_3_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Display_On_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Visibility = Visibility.Visible;
        }

        private void Button_Display_Off_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Visibility = Visibility.Hidden;
            this.canvas.Children.Clear();
        }

        private void Button_Modal_Close_Click(object sender, RoutedEventArgs e)
        {
            this.canvas.Children.Clear();
        }

        private void ExecutingUControl(UserControl uc)
        {
            uc.Width = 200;
            uc.Height = 150;

            this.canvas.Children.Add(uc);
            //((FrameworkElement)this.canvas.Parent).hit
        }

    }
}
