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

namespace UControl
{
    public partial class Modal
    {

        protected Boolean isDragging;
        private Point mouseLocationWithinMe;

        private void RectMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            var canvasObject = sender as UIElement;
            isDragging = true;
            mouseLocationWithinMe = e.GetPosition(canvasObject);

            canvasObject.CaptureMouse();
        }

        private void RectMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            var canvasObject = sender as UIElement;
            isDragging = false;
            canvasObject.ReleaseMouseCapture();

        }

        private void RectMouseMove(object sender, MouseEventArgs e)
        {

            if (isDragging)
            {
                var mouseWithinParent = e.GetPosition(parent);
                var canvasObject = sender as FrameworkElement;

                //Canvas.SetLeft(canvasObject
                //    , Clamp((mouseWithinParent.X - mouseLocationWithinMe.X), 0, parent.ActualWidth - canvasObject.ActualWidth));

                //Canvas.SetTop(canvasObject
                //    , Clamp((mouseWithinParent.Y - mouseLocationWithinMe.Y), 0, parent.ActualHeight - canvasObject.ActualHeight));

                Canvas.SetLeft(canvasObject,
                   Clamp(mouseWithinParent.X, 0, parent.ActualWidth) - mouseLocationWithinMe.X);

                Canvas.SetTop(canvasObject,
                    Clamp(mouseWithinParent.Y, 0, parent.ActualHeight) - mouseLocationWithinMe.Y);

                //Canvas.SetLeft(canvasObject, 
                //    mouseWithinParent.X - mouseLocationWithinMe.X);

                //Canvas.SetTop(canvasObject
                //    , mouseWithinParent.Y - mouseLocationWithinMe.Y);
            }
        }

        private double Clamp(double currentValue, double minValue, double maxValue)
        {
            if (currentValue < minValue)
            {
                return minValue;
            }
            else if (currentValue > maxValue)
            {
                return maxValue;
            }

            return currentValue;
        }

    }
}
