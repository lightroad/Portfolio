using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Portfolio.Models;
using Portfolio.Utilities;

namespace Portfolio.ViewModels
{
	class NavigationVM : Utilities.ViewModelBase
	{
		#region MainWindow 현재 활성 화면
		private object _currentView;
		public object CurrentView
		{
			get => _currentView;
			set { _currentView = value; OnPropertyChanged(); }
		}
		#endregion

		#region MainWindow 하단 Progress Bar 동작 속성
		private bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set
			{
				_isBusy = value;
				Opacity = value == true ? 1 : 0.3;
				OnPropertyChanged();
			}
		}
		#endregion

		#region MainWindow 하단 Progress Bar 투명도
		private double _opacity = 0.3;
		public double Opacity
		{
			get => _opacity;
			set { _opacity = value; OnPropertyChanged(); }
		}
		#endregion


		#region MainWindow 하단 상태 메시지
		private string _statusText;
		public string StatusText
		{
			get => _statusText;
			set { _statusText = value; OnPropertyChanged(); }
		} 
		#endregion

		#region ICommand, View 호출

		public ICommand PortfolioCommand { get; set; }
		public ICommand LoginCommand { get; set; }
		public ICommand CustomerCommand { get; set; }
		public ICommand SettingsCommand { get; set; }

		private PortfolioVM PortfolioVM = new PortfolioVM();
		private LoginVM LoginVM = new LoginVM();
		private CustomerVM CustomerVM = new CustomerVM();
		private SettingVM SettingVM = new SettingVM();

		private void Portfolio(object obj) => CurrentView = PortfolioVM;

		private void Login(object obj) => CurrentView = LoginVM;

		private void Customer(object obj) => CurrentView = CustomerVM;

		private void Setting(object obj) => CurrentView = SettingVM;

		#endregion



		public NavigationVM() 
		{
			PortfolioCommand = new RelayCommand<object>(Portfolio);
			LoginCommand = new RelayCommand<object>(Login);
			CustomerCommand = new RelayCommand<object>(Customer);
			SettingsCommand = new RelayCommand<object>(Setting);

			// Startup Page
			CurrentView = new PortfolioVM();
		}
	}
}

