using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Portfolio
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// 로그인 사용자 아이디 - 세션 같이 사용 목적
		/// </summary>
		public static string UserId { get; set; }

		#region 팝업 호출 이벤트
		public delegate void ShowPopupEventHandler(string Header, string Content);
		public static event ShowPopupEventHandler PopupCalled;

		/// <summary>
		/// 공용 팝업 호출
		/// </summary>
		/// <param name="Content">Popup Content</param>
		/// <param name="Header">Popup Header</param>
		public static void ShowPopup(string Content, string Header = "") => PopupCalled?.Invoke(Header, Content);
		#endregion

		#region IsBusy 변경 이벤트
		public delegate void IsBusyChangeEventHandler(bool IsBusy);
		public static event IsBusyChangeEventHandler IsBusyChanged;

		public static void IsBusyChange(bool IsBusy) => IsBusyChanged?.Invoke(IsBusy);
		#endregion

		#region StatusText 변경 이벤트
		public delegate void StatusTextChangeEventHandler(string StatusText);
		public static event StatusTextChangeEventHandler StatusTextChanged;

		public static void StatusTextChange(string StatusText) => StatusTextChanged?.Invoke(StatusText);
		#endregion
	}
}
