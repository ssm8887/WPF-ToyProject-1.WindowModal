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
        // MouseDown 판별용
        protected Boolean isDragging;

        // 드래그 가능대상(모달)내에서 클릭한 좌표
        private Point mouseLocationWithinMe;

        // 이벤트 등록대상(모달)에서 MouseButtonDown이벤트 발생시
        private void RectMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            var canvasObject = sender as UIElement;
            isDragging = true;
            mouseLocationWithinMe = e.GetPosition(canvasObject);

            canvasObject.CaptureMouse();
        }

        // 이벤트 등록대상(모달)에서 MouseButtonUp이벤트 발생시
        private void RectMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            var canvasObject = sender as UIElement;
            isDragging = false;
            canvasObject.ReleaseMouseCapture();
        }

        // 이벤트 등록대상(모달)에서 MouseMove이벤트 발생시
        private void RectMouseMove(object sender, MouseEventArgs e)
        {

            if (isDragging)
            {
                var mouseWithinParent = e.GetPosition(parent);
                var canvasObject = sender as FrameworkElement;

                /////////////////// ParentContainer내에서만 모달 이동가능 ////////////////////////////////////////////////////////////////////////

                //Canvas.SetLeft(canvasObject
                //    , Clamp((mouseWithinParent.X - mouseLocationWithinMe.X), 0, parent.ActualWidth - canvasObject.ActualWidth));

                //Canvas.SetTop(canvasObject
                //    , Clamp((mouseWithinParent.Y - mouseLocationWithinMe.Y), 0, parent.ActualHeight - canvasObject.ActualHeight));

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                /////////////////// ParentContainer내에서 이동한 마우스포인터까지 모달 이동가능 ///////////////////////////////////////////////////

                Canvas.SetLeft(canvasObject,
                   Clamp(mouseWithinParent.X, 0, parent.ActualWidth) - mouseLocationWithinMe.X);

                Canvas.SetTop(canvasObject,
                    Clamp(mouseWithinParent.Y, 0, parent.ActualHeight) - mouseLocationWithinMe.Y);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                /////////////////// ParentContainer에 상관없이 내, 외 모두 이동가능 /////////////////////////////////////////////////////////////

                //Canvas.SetLeft(canvasObject, 
                //    mouseWithinParent.X - mouseLocationWithinMe.X);

                //Canvas.SetTop(canvasObject
                //    , mouseWithinParent.Y - mouseLocationWithinMe.Y);

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            }
        }

        // 범위 제한용 Clamp함수
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
