using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Portfolio.Utilities
{
	/// <summary>
	/// Maximize 적용 시 작업표시줄 공간까지 차지하는 증상 대응용 클래스
	/// 
	/// </summary>
	public static class SystemParametersFix
	{
		/// <summary>
		/// Maximize에 사용할 보정된 상하좌우 여백
		/// </summary>
		public static Thickness WindowResizeBorderThickness
		{
			get
			{
				float dpix = GetDpi(GetDeviceCapsIndex.LOGPIXELSX);
				float dpiy = GetDpi(GetDeviceCapsIndex.LOGPIXELSY);

				int dx = GetSystemMetrics(GetSystemMetricsIndex.CXFRAME);
				int dy = GetSystemMetrics(GetSystemMetricsIndex.CYFRAME);

				// this adjustment is needed only since .NET 4.5 
				int d = GetSystemMetrics(GetSystemMetricsIndex.SM_CXPADDEDBORDER);
				dx += d;
				dy += d;

				// 보정된 상하, 좌우 너비 계산
				var leftBorder = dx / dpix;
				var topBorder = dy / dpiy;
				
				// 하단은 작업표시줄 높이 합산
				var bottomBorder = topBorder 
								 + (SystemParameters.PrimaryScreenHeight - SystemParameters.FullPrimaryScreenHeight - SystemParameters.WindowCaptionHeight);

				return new Thickness(leftBorder, topBorder, leftBorder, bottomBorder);
			}
		}

		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("user32.dll")]
		private static extern IntPtr GetDC(IntPtr hwnd);

		[DllImport("gdi32.dll")]
		private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		private static float GetDpi(GetDeviceCapsIndex index)
		{
			IntPtr desktopWnd = IntPtr.Zero;
			IntPtr dc = GetDC(desktopWnd);
			float dpi;
			try
			{
				dpi = GetDeviceCaps(dc, (int)index);
			}
			finally
			{
				ReleaseDC(desktopWnd, dc);
			}
			return dpi / 96f;
		}

		private enum GetDeviceCapsIndex
		{
			LOGPIXELSX = 88,
			LOGPIXELSY = 90
		}

		[DllImport("user32.dll")]
		private static extern int GetSystemMetrics(GetSystemMetricsIndex nIndex);

		private enum GetSystemMetricsIndex
		{
			CXFRAME = 32,
			CYFRAME = 33,
			SM_CXPADDEDBORDER = 92
		}
	}
}
