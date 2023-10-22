using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Portfolio.Views
{
	/// <summary>
	/// ModalPopup.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class ModalPopup : System.Windows.Controls.UserControl
    {
		#region 팝업 헤더 속성 정의
		public static readonly DependencyProperty PopupHeaderProperty = DependencyProperty.Register("PopupHeader",
																									typeof(string),
																									typeof(ModalPopup),
																									null);

		public string PopupHeader
		{
			//get { return (string)GetValue(ModalPopup.HeaderProperty); }
			//set { SetValue(ModalPopup.HeaderProperty, value); } 
			set { HeaderText.Text = value; }
		}
		#endregion

		#region 팝업 컨텐츠 속성 정의
		public static readonly DependencyProperty PopupContentProperty = DependencyProperty.Register("PopupContent",
																							   typeof(string),
																							   typeof(ModalPopup),
																							   null);

		public string PopupContent
		{
			//get { return (string)GetValue(ModalPopup.HeaderProperty); }
			//set { SetValue(ModalPopup.HeaderProperty, value); } 
			set { ContentText.Text = value; }
		} 
		#endregion

		public ModalPopup()
		{
			InitializeComponent();
		}

		private void PopupClose_Click(object sender, RoutedEventArgs e)
		{
			PopupHeader = "";
			PopupContent = "";
			this.Visibility = Visibility.Collapsed;
        }
    }
}
