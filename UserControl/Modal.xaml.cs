using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using CommonModel;

namespace UControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Modal : UserControl
    {

        private double previousWidth;
        private double previousHeight;
        private double previousCanvasLeft;
        private double previousCanvasTop;
        private UIElement modalBackground = null;
        private FrameworkElement parent;

        UpdateModel updateModel = new UpdateModel();

        public Modal()
        {
            InitializeComponent();
            //this.DataContext = updateModel;

            this.Loaded += Modal_Loaded;
            this.MouseLeftButtonDown += RectMouseButtonDown;
            this.MouseLeftButtonUp += RectMouseButtonUp;
            this.MouseMove += RectMouseMove;
            this.ToggleSize.Click += ToggleSize_Click;
            this.TextBlockHeader.MouseDoubleClick += HeaderTextBlock_MouseDoubleClick;
            this.TextBlockHeader.MouseDoubleClick += ToggleSize_Click;
            this.ButtonDispose.Click += ButtonDispose_Click;
            this.Unloaded += Modal_Unloaded;

            this.Width = 200;
            this.Height = 150;
            parent = this.Parent as FrameworkElement;
        }

        public Modal(double width, double height) : this()
        {
            this.Width = width;
            this.Height = height;
        }

        private void Modal_Loaded(object sender, RoutedEventArgs e)
        {
            parent = this.Parent as FrameworkElement;

            var parentWidth = parent.ActualWidth / 2;
            var parentHeight = parent.ActualHeight / 2;

            Canvas.SetLeft(this, parentWidth - this.Width / 2);
            Canvas.SetTop(this, parentHeight - this.Height / 2);
        }

        private void MaximizeModal()
        {
            previousWidth = ActualWidth;
            previousHeight = ActualHeight;

            previousCanvasLeft = Canvas.GetLeft(this);
            previousCanvasTop = Canvas.GetTop(this);

            Canvas.SetLeft(this, 0);
            Canvas.SetTop(this, 0);

            this.Width = parent.ActualWidth;
            this.Height = parent.ActualHeight;

            this.ToggleSize.Content = "▣";
        }

        private void MinimizeModal()
        {
            this.Width = previousWidth;
            this.Height = previousHeight;

            Canvas.SetLeft(this, previousCanvasLeft);
            Canvas.SetTop(this, previousCanvasTop);

            this.ToggleSize.Content = "□";
        }

        private void ToggleSize_Click(object sender, RoutedEventArgs e)
        {
            if (IsChecked)
            {
                MaximizeModal();
            }
            else
            {
                MinimizeModal();
            }

            e.Handled = true;
        }

        private void ButtonDispose_Click(object sender, RoutedEventArgs e)
        {
            (parent as Panel).Children.Remove(this);
        }

        private void HeaderTextBlock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IsChecked = !IsChecked;
        }

        private void CustomModal()
        {
            var parent = this.Parent as Panel;

            StackPanel sp = new StackPanel()
            {
                Width = parent.ActualWidth,
                Height = parent.ActualHeight,
                Background = Brushes.Black,
                Opacity = 0.35
            };

            (parent as Panel).Children.Add(sp);

            Canvas.SetLeft(sp, 0);
            Canvas.SetTop(sp, 0);
            Canvas.SetZIndex(sp, -1);

            sp.MouseDown += Sp_MouseDown;

            modalBackground = sp;
        }

        private void Sp_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Modal_Unloaded(object sender, RoutedEventArgs e)
        {
            if (modalBackground != null)
            {
                (parent as Panel).Children.Remove(modalBackground);
            }
        }

    }
}
