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
			string Lastname = Lastnamebox.Text;
			string Phone = Phonebox.Text;
			string Email = Emailbox.Text;
			string Password = signuppasswordbox.Password;
			string Confirmpassword = confirmpasswordbox.Password;
			int flg = 0;

			if (!Name_Check(Name))
			{
				flg = 1 ;
				signupnameerrorbox.Text = "Name should contain between 3 to 32 character!";
			}
			if (!Name_Check(Lastname))
			{
				flg = 1 ;
				signuplastnameerrorbox.Text = "Lastname should contain between 3 to 32 character!";
			}
			if (!Phone_Check(Phone))
			{
				flg = 1 ;
				signupphoneerrorbox.Text = "Phone number should start with 09 and has 11 digit!";
			}
			if (!Email_check(Email))
			{
				flg = 1 ;
				signupemailerrorbox.Text = "It's not in email form!";
			}
			if (!Password_Check(Password))
			{
				flg = 1;
				signuppassworderrorbox.Text = "Password should atleast has 8 character and contain upper and lowercase char !";
			}
			if(Password != Confirmpassword)
			{
				flg = 1;
				signupconfirmpassbox.Text = "It should be same as password!";
			}
			if ( flg == 0 )
			{
				/*add a user with this datas*/
				return;
			}
		}

		private void Namebox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (sender == Namebox)
			{
				signupnameerrorbox.Text = "";
			}
			if (sender == Lastnamebox)
			{
				signuplastnameerrorbox.Text = "";
			}
			e.Handled = !(Regex.IsMatch(e.Text, "^[a-zA-Z]$"));
		}

		private void Phonebox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			signupphoneerrorbox.Text = "";
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

		bool Name_Check(string Name)
		{
			if (Regex.IsMatch(Name, "^[a-zA-Z]{3,32}$"))
			{
				return true;
			}
			return false;
		}
		bool Phone_Check(string Number)
		{
			if (Regex.IsMatch(Number,"^(09)[0-9]{9}$"))
			{
				return true;
			}
			return false;
		}
		bool Email_check(string Email)
		{
			if (Regex.IsMatch(Email, @"^[a-zA-Z0-9.! #$%&'*+/=? ^_`{|}~-]{1,32}@[a-zA-Z0-9-]{1,32}(?:\.[a-zA-Z0-9-]{1,32})*$"))
			{
				return true;
			}
			return false;
		}
		bool Password_Check(string password)
		{
			if (Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])\w{8,40}$"))
			{
				return true;
			}
			return false;
		}

		private void Emailbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			signupemailerrorbox.Text = "";
		}

		private void signuppassboxtxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			signuppassworderrorbox.Text = "";
		}

		private void confirmpasswordbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			signupconfirmpassbox.Text = "";
		}
	}
}
