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

        public bool IsModal
        {
            get => isModal;
            set
            {
                isModal = value;
                updateModel.OnPropertyUpdate("IsModal");

                if (isModal)
                {
                    CustomModal();
                }
            }
        }
    }

}
