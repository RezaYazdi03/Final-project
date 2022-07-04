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
using System.Windows.Shapes;

namespace firstpage
{
	/// <summary>
	/// Interaction logic for AdminPage.xaml
	/// </summary>
	public partial class AdminPage : Window
	{
		public AdminPage()
		{
			InitializeComponent();
		}

		private void AdminLoginbtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AdminShowpasscheck_Checked(object sender, RoutedEventArgs e)
		{
			Adminpasswordbox.Visibility = Visibility.Hidden;
			Adminpassboxtxt.Text = Adminpasswordbox.Password;
			Adminpassboxtxt.Visibility = Visibility.Visible;
		}

		private void AdminShowpasscheck_Unchecked(object sender, RoutedEventArgs e)
		{
			Adminpassboxtxt.Visibility = Visibility.Hidden;
			Adminpasswordbox.Password = Adminpassboxtxt.Text;
			Adminpasswordbox.Visibility = Visibility.Visible;
		}
	}
}
