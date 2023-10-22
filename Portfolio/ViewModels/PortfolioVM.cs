using Portfolio.Models;
using Portfolio.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Security.Cryptography;
using System.Collections;

namespace Portfolio.ViewModels
{
	/// <summary>
	/// 계정 뷰모델
	/// </summary>
	class PortfolioVM : Utilities.ViewModelBase
	{
		private readonly Portfolio.Models.Portfolio _portfolioModel;
		//public IQueryable<Portfolio.Models.Portfolio> Portfolios;
		private List<Portfolio.Models.Portfolio> _portfolios;
		public List<Portfolio.Models.Portfolio> Portfolios
		{
			get 
			{
				return _portfolios; 
			}
			set { _portfolios = value; OnPropertyChanged(); }
		}

		public ICommand PortfolioCommand { get; set; }
		private void Portfolio(object obj) => Portfolio();

		//private async void Login(object obj) => await DoLogin();

		public PortfolioVM()
		{
			_portfolioModel = new Portfolio.Models.Portfolio();
			PortfolioCommand = new RelayCommand<object>(Portfolio);
			Portfolio();
		}

		private void Portfolio()
		{
			GetPortfolio();
		}

		/// <summary>
		/// 포트폴리오 조회
		/// </summary>
		/// <param name="PortfolioName"></param>
		/// <param name="DataBaseName"></param>
		/// <param name="Tag"></param>
		/// <returns>포트폴리오 조회 결과</returns>
		private void GetPortfolio(string PortfolioName = "", string DataBaseName = "", string Tag = "")
		{
			App.IsBusyChange(true);
			//var task = Task.Run(() => { return DataEntities.Entities.Portfolios.Where(a => string.IsNullOrEmpty(PortfolioName) ? true : a.PortfolioName.Contains(PortfolioName)
			//																			&& string.IsNullOrEmpty(DataBaseName) ? true : a.DataBaseName.Contains(DataBaseName)
			//																			&& string.IsNullOrEmpty(Tag) ? true : a.DevelopType.Contains(Tag)); });
			//IQueryable<Portfolio.Models.Portfolio> Portfolios = await task;
			App.IsBusyChange(false);

			Portfolios = DataEntities.Entities.Portfolios.ToList();

			//return Portfolios;
		}
	}
}
