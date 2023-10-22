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

namespace Portfolio.ViewModels
{
	/// <summary>
	/// 계정 뷰모델
	/// </summary>
	class LoginVM : Utilities.ViewModelBase
	{
		private readonly AccountModel _accountModel;
		
		/// <summary>
		/// 아이디
		/// </summary>
		public string UserID 
		{
			get { return _accountModel.UserID; }
			set { _accountModel.UserID = value; OnPropertyChanged(); } 
		}

		/// <summary>
		/// 비밀번호
		/// </summary>
		public string Password
		{
			get { return _accountModel.Password; }
			set { _accountModel.Password = value; OnPropertyChanged(); }
		}

		public ICommand LoginCommand { get; set; }

		private async void Login(object obj) => await DoLogin();

		public LoginVM()
		{
			_accountModel = new AccountModel();
			LoginCommand = new RelayCommand<object>(Login, CanLogin);
		}

		/// <summary>
		/// 로그인
		/// </summary>
		/// <returns>로그인 성공 여부</returns>
		private async Task<bool> DoLogin()
		{
			App.IsBusyChange(true);
			var task = Task.Run(() => { return DataEntities.Entities.Accounts.SingleOrDefault(a => a.UserID == UserID); });
			var account = await task;
			App.IsBusyChange(false);

			// 암호화 적용 조건 체크
			if (account != null && account.EncryptionType != null)
			{
				string Salt = account.EncryptionType.EncryptionTypeName;
				string EncryptPassword = EncryptUtil.Encrypt(Password, Salt);

				if (account.Password == EncryptPassword)
				{
					App.StatusTextChange("로그인 성공");
					App.UserId = UserID;
					return true;
				}
				else
				{
					App.StatusTextChange("로그인 실패");
					App.UserId = string.Empty;
					return false;
				}
			}

			// 아이디나 비밀번호 입력 오류
			else
			{
				App.StatusTextChange("로그인 실패");
				App.UserId = string.Empty;
				return false;
			}
			
		}

		/// <summary>
		/// LoginCommand의 CanExecute
		/// </summary>
		/// <param name="_"></param>
		/// <returns></returns>
		private bool CanLogin(object _)
		{
			return !string.IsNullOrEmpty(UserID) && !string.IsNullOrEmpty(Password);
		}
	}
}
