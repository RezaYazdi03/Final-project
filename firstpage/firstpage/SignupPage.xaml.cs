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
	/// Interaction logic for SignupPage.xaml
	/// </summary>
	public partial class SignupPage : Window
	{
		public SignupPage()
		{
			InitializeComponent();
		}

		private void Closebtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Backbtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}

		private void Showpasscheck_Checked(object sender, RoutedEventArgs e)
		{
			passwordbox.Visibility = Visibility.Hidden;
			confirmpasswordbox.Visibility = Visibility.Hidden;
			passboxtxt.Text = passwordbox.Password;
			confirmpassboxtxt.Text = confirmpasswordbox.Password;
			passboxtxt.Visibility = Visibility.Visible;
			confirmpassboxtxt.Visibility = Visibility.Visible;
		}

		private void Showpasscheck_Unchecked(object sender, RoutedEventArgs e)
		{
			passboxtxt.Visibility = Visibility.Hidden;
			confirmpassboxtxt.Visibility = Visibility.Hidden;
			passwordbox.Password = passboxtxt.Text;
			confirmpasswordbox.Password = confirmpassboxtxt.Text;
			passwordbox.Visibility = Visibility.Visible;
			confirmpasswordbox.Visibility = Visibility.Visible;
		}
		private void Loginbtn_Click(object sender, RoutedEventArgs e)
		{
			string username = Namebox.Text;
			string password = passwordbox.Password;

		}

	}
}
