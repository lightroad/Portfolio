using Portfolio.Utilities;
using System;
using System.Collections.Generic;
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

namespace Portfolio.Views
{
	/// <summary>
	/// Portfolio.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class Portfolios : UserControl
	{
		public Portfolios()
		{
			InitializeComponent();
		}

		private void Btn_Checked(object sender, RoutedEventArgs e)
		{
			string TypeName = (sender as Btn).Tag.ToString();

			PortfolioList.ItemTemplate = Resources[TypeName] as DataTemplate;
		}

		private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{

		}
	}
}
