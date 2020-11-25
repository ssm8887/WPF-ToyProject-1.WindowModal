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
        // 모달 최대화후 최소화시 이전상태(Width) 기억용
        private double previousWidth;

        // 모달 최대화후 최소화시 이전상태(Height) 기억용
        private double previousHeight;

        // 모달 최대화후 최소화시 이전상태(Left) 기억용
        private double previousCanvasLeft;

        // 모달 최대화후 최소화시 이전상태(Top) 기억용
        private double previousCanvasTop;

        // IsModal - True 일 경우 모달을 제외한 컨트롤 이벤트 차단을 위한 Element
        private UIElement modalBackground;
        private FrameworkElement parent;

        UpdateModel updateModel = new UpdateModel();

        public Modal()
        {
            InitializeComponent();


            //////////////// 이벤트 등록 /////////////////////////////////
            
            this.Loaded += Modal_Loaded;
            this.MouseLeftButtonDown += RectMouseButtonDown;
            this.MouseLeftButtonUp += RectMouseButtonUp;
            this.MouseMove += RectMouseMove;
            this.ToggleSize.Click += ToggleSize_Click;
            this.TextBlockHeader.MouseDoubleClick += HeaderTextBlock_MouseDoubleClick;
            this.TextBlockHeader.MouseDoubleClick += ToggleSize_Click;
            this.ButtonDispose.Click += ButtonDispose_Click;
            this.Unloaded += Modal_Unloaded;

            ////////////////////////////////////////////////////////////

            this.Width = 200;
            this.Height = 150;

            parent = this.Parent as FrameworkElement;
        }

        public Modal(double width, double height) : this()
        {
            this.Width = width;
            this.Height = height;
        }

        // 모달 관련 Element 모두 Load시 발생이벤트
        private void Modal_Loaded(object sender, RoutedEventArgs e)
        {
            parent = this.Parent as FrameworkElement;

            var parentWidth = parent.ActualWidth / 2;
            var parentHeight = parent.ActualHeight / 2;

            // 모달창 생성시 가운데 위치
            Canvas.SetLeft(this, parentWidth - this.Width / 2);
            Canvas.SetTop(this, parentHeight - this.Height / 2);
        }

        // 창 최대화
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

        // 창 최소화
        private void MinimizeModal()
        {
            // 이전크기로 변경
            this.Width = previousWidth;
            this.Height = previousHeight;

            // 이전위치로 이동
            Canvas.SetLeft(this, previousCanvasLeft);
            Canvas.SetTop(this, previousCanvasTop);

            this.ToggleSize.Content = "□";
        }

        // 모달창 최대화/최소화 버튼 클릭시
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

            // 이벤트 버블링 차단
            e.Handled = true;
        }

        // 모달창 종료 버튼 클릭시
        private void ButtonDispose_Click(object sender, RoutedEventArgs e)
        {
            (parent as Panel).Children.Remove(this);
        }

        // 모달창 상단 헤더 더블클릭시
        private void HeaderTextBlock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IsChecked = !IsChecked;
        }

        private void CreateModalBackground()
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

        private void Sp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }


        // 모달 종료시 이벤트발생
        private void Modal_Unloaded(object sender, RoutedEventArgs e)
        {
            // Modal종료시 modalBackground도 같이 종료

            if (modalBackground != null)
            {
                (parent as Panel).Children.Remove(modalBackground);
            }
        }

    }
}
