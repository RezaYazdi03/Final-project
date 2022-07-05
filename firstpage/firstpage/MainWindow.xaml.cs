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
	class User
	{
		string Username;
		string password;
		static List<User> users = new List<User>();

		public User(string Username , string Password)
		{
			this.Username = Username;
			this.password = Password;
		}
		static User()
		{
			//extract data from database and put in users list
		}
		
		public static int User_Check(string username , string password)
		{
			if (/*username and password was ok*/false)
			{
				return 1;
			}
			if (/*username exist but password wass incorrect*/false)
			{
				return 0;
			}
			return -1;
		}


		public static bool Name_Check(string Name)
		{
			if (Regex.IsMatch(Name, "^[a-zA-Z]{3,32}$"))
			{
				return true;
			}
			return false;
		}
		public static bool Phone_Check(string Number)
		{
			if (Regex.IsMatch(Number, "^(09)[0-9]{9}$"))
			{
				return true;
			}
			return false;
		}
		public static bool Email_check(string Email)
		{
			if (Regex.IsMatch(Email, @"^[a-zA-Z0-9.! #$%&'*+/=? ^_`{|}~-]{1,32}@[a-zA-Z0-9-]{1,32}(?:\.[a-zA-Z0-9-]{1,32})*$"))
			{
				return true;
			}
			return false;
		}
		public static bool Password_Check(string password)
		{
			if (Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])\w{8,40}$"))
			{
				return true;
			}
			return false;
		}
		public static bool Email_Already_Exist(string email)
		{
			if (/*Email already exist*/false)
			{
				return true;
			}
			return false;
		}
	}
	class Admin
	{
		string Username;
		string Password;

		public Admin(string Username, string Password)
		{
			this.Username = Username;
			this.Password = Password;
		}
		static Admin()
		{
			//extract data from database and put in users list
		}

		public static int Admin_Check(string username, string password)
		{
			if (/*username and password was ok*/false)
			{
				return 1;
			}
			if (/*username exist but password wass incorrect*/false)
			{
				return 0;
			}
			return -1;
		}
	}

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
			switch (User.User_Check(username , password))
			{
				case 1:
					{
						//open app
						break;
					}
				case 0:
					{
						signinwrongpasswordbox.Text = "Wrong password";
						break;
					}
				case -1:
					{
						signinwronusernameerrorbox.Text = "This username doesn't exist!";
						break;
					}
				default:
					break;
			}

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

			if (!User.Name_Check(Name))
			{
				flg = 1 ;
				signupnameerrorbox.Text = "Name should contain between 3 to 32 character!";
			}
			if (!User.Name_Check(Lastname))
			{
				flg = 1 ;
				signuplastnameerrorbox.Text = "Lastname should contain between 3 to 32 character!";
			}
			if (!User.Phone_Check(Phone))
			{
				flg = 1 ;
				signupphoneerrorbox.Text = "Phone number should start with 09 and has 11 digit!";
			}
			if (!User.Email_check(Email))
			{
				flg = 1 ;
				signupemailerrorbox.Text = "It's not in email form!";
			}
			else if (User.Email_Already_Exist(Email))
			{
				flg = 1;
				signupemailerrorbox.Text = "This email already signedup!";
			}
			if (!User.Password_Check(Password))
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
				tabcntrl.SelectedIndex = 0;
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
			string Username = Adminnamebox.Text;
			string Password = Adminpassboxtxt.Text;
			switch (Admin.Admin_Check(Username,Password))
			{
				case 1:
					{
						//Open admin page
						break;
					}
				case 0:
					{
						Adminpassworderrorbox.Text = "Wrong password!";
						break;
					}
				case -1:
					{
						Adminusernameerrorbox.Text = "This Admin doesn't exist!";
						break;
					}
				default:
					break;
			}
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

		private void Usernamebox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			signinwronusernameerrorbox.Text = "";
		}

		private void passwordbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			signinwrongpasswordbox.Text = "";
		}


		private void Adminnamebox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Adminusernameerrorbox.Text = "";
		}

		private void Adminpasswordbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Adminpassworderrorbox.Text = "";
		}
	}
}
