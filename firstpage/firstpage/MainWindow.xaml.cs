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
using System.Text.RegularExpressions;

namespace firstpage
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			
		}

		private void Closebtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Backbtn_Click(object sender, RoutedEventArgs e)
		{
			tabcntrl.SelectedIndex = 0;
		}

		private void Showpasscheck_Checked(object sender, RoutedEventArgs e)
		{
			passwordbox.Visibility = Visibility.Hidden;
			passboxtxt.Text = passwordbox.Password;
			passboxtxt.Visibility = Visibility.Visible;
		}

		private void Showpasscheck_Unchecked(object sender, RoutedEventArgs e)
		{
			passboxtxt.Visibility = Visibility.Hidden;
			passwordbox.Password = passboxtxt.Text;
			passwordbox.Visibility = Visibility.Visible;
		}

		private void Loginbtn_Click(object sender, RoutedEventArgs e)
		{
			string username = Usernamebox.Text;
			string password = passwordbox.Password;
			
		}


		private void Admintabbtn_Click(object sender, RoutedEventArgs e)
		{
			tabcntrl.SelectedIndex = 2;
		}

		private void Signuptabbtn_Click(object sender, RoutedEventArgs e)
		{
			tabcntrl.SelectedIndex = 1;
		}

		private void signupShowpasscheck_Checked(object sender, RoutedEventArgs e)
		{
			signuppasswordbox.Visibility = Visibility.Hidden;
			confirmpasswordbox.Visibility = Visibility.Hidden;
			signuppassboxtxt.Text = signuppasswordbox.Password;
			confirmpassboxtxt.Text = confirmpasswordbox.Password;
			signuppassboxtxt.Visibility = Visibility.Visible;
			confirmpassboxtxt.Visibility = Visibility.Visible;
		}

		private void signupShowpasscheck_Unchecked(object sender, RoutedEventArgs e)
		{
			signuppassboxtxt.Visibility = Visibility.Hidden;
			confirmpassboxtxt.Visibility = Visibility.Hidden;
			signuppasswordbox.Password = signuppassboxtxt.Text;
			confirmpasswordbox.Password = confirmpassboxtxt.Text;
			signuppasswordbox.Visibility = Visibility.Visible;
			confirmpasswordbox.Visibility = Visibility.Visible;
		}

		private void Signupbtn_Click(object sender, RoutedEventArgs e)
		{
			string Name = Namebox.Text;
			if (!Name_Check(Name))
			{
				/*write later*/
			}
			string Lastname = Lastnamebox.Text;
			if (!Name_Check(Lastname))
			{
				/*write later*/
			}
			try { int Phone = int.Parse(Phonebox.Text); }
			catch
			{
				/*write later*/
			}
			string Email = Emailbox.Text;
			if (Email_check(Email))
			{
				/*write later*/
			}
			string Password = passwordbox.Password;
			string Confirmpassword = confirmpasswordbox.Password;


		}
		static bool Name_Check(string Name)
		{
			if (Regex.IsMatch(Name, "^[a-zA-Z]{3,32}$"))
			{
				return true;
			}
			return false;
		}
		static bool Email_check(string Email)
		{
			return false;
		}

		private void Phonebox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
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
