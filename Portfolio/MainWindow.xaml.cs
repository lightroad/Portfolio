using Portfolio.Models;
using Portfolio.Utilities;
using Portfolio.ViewModels;
using Portfolio.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;

namespace Portfolio
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			App.PopupCalled += MainWindow_PopupCalled;
			App.IsBusyChanged += App_IsBusyChanged;
			App.StatusTextChanged += App_StatusTextChanged;
		}

		private async void App_StatusTextChanged(string StatusText)
		{
			(this.DataContext as NavigationVM).StatusText = StatusText;

			// 상태메시지 5초간 표시 후 초기화
			await Task.Delay(5000);
			(this.DataContext as NavigationVM).StatusText = string.Empty;
		}

		private void MainWindow_PopupCalled(string Header, string Content)
		{
			ModelPopup.PopupHeader = Header;
			ModelPopup.PopupContent = Content;
			ModelPopup.Visibility = Visibility.Visible;
		}

		private void App_IsBusyChanged(bool IsBusy)
		{
			(this.DataContext as NavigationVM).IsBusy = IsBusy;
		}

		/// <summary>
		/// 좌측 마우스 누른 상태에서 포인트 이동 시 창 이동
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);

			this.DragMove();
		}

		protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
		{
			base.OnMouseDoubleClick(e);

			if (e.LeftButton == MouseButtonState.Pressed)
			{
				WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
			}
			Thickness a = SystemParameters.WindowResizeBorderThickness;
			Thickness b = SystemParametersFix.WindowResizeBorderThickness;

		}

		private void CloseApp_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
