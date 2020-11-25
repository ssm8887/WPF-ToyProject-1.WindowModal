using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UControl
{
    public partial class Modal
    {
        private bool isChecked;
        private bool isModal;

        /// <summary>
        /// 최대화, 최소화 ToggleButton 상태
        /// </summary>
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                updateModel.OnPropertyUpdate("IsChecked");
            }
        }


        /// <summary>
        /// 모달창 생성시 배경 Control(ex. Button, ToggleButton, Checkbox 등 모든 컨트롤) 작동 상태
        /// True - 모달을 제외한 Control 이벤트 차단
        /// False - 모든 컨트롤 이벤트 발생 
        /// </summary>
        public bool IsModal
        {
            get => isModal;
            set
            {
                isModal = value;
                updateModel.OnPropertyUpdate("IsModal");

                if (isModal)
                {
                    CreateModalBackground();
                }
            }
        }
    }

}
