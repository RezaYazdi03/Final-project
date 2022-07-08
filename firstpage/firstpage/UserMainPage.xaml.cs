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
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.ServiceProcess;
using System.Diagnostics;

namespace firstpage
{
	/// <summary>
	/// Interaction logic for UserMainPage.xaml
	/// </summary>
	public class Book
	{
		public int id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public int Page_Number { get; set; }
		public double Price { get; set; }
		public bool VIP { get; set; }
		public string image { get; set; }
		public string pdf { get; set; }

		public Book( int id , string Name, string Author, int Page_Number, double Price, bool VIP, string image , string pdf)
		{
			this.id = id;
			this.Name = Name;
			this.Author = Author;
			this.Page_Number = Page_Number;
			this.Price = Price;
			this.VIP = VIP;
			this.image = image;
			this.pdf = pdf;
		}
			
	}

	public class tabUser
	{
		public string name;
		public string lastname;
		public string phone;
		public string email;
		public string username;
		public string password;
		public tabUser(string name,string lastname,string phone,string email,string username,string password)
		{
			this.name = name;
			this.lastname = lastname;
			this.phone = phone;
			this.email = email;
			this.username = username;
			this.password = password;
		}
		public void edit(string _name, string _lastname, string _phone, string _email, string _username, string _password , int id)
		{
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yazdi-pc\Desktop\Final-project\firstpage\Finalprojectdb.mdf;Integrated Security=True;Connect Timeout=30");
			connection.Open();
			string command = "update UsersTable SET Name = '" + _name + "',Lastname = '" + _lastname + "',Phone = '" + _phone + "',Email = '" + _email + "',Username = '" + _username + "',Password = '" + _password + "' where id = '" + id + "'";
			SqlCommand com = new SqlCommand(command,connection);
			com.ExecuteNonQuery();
			connection.Close();
		}
	}


	public partial class UserMainPage : Window
	{
		public ObservableCollection<Book> books { get; set; }
		public ObservableCollection<Book> mybooks { get; set; }
		public ObservableCollection<Book> bookmarks { get; set; }
		int ID;
		tabUser user = new tabUser("", "", "", "", "", "");
		public UserMainPage(int id)
		{
			ID = id;
			books = new ObservableCollection<Book>();
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yazdi-pc\Desktop\Final-project\firstpage\Finalprojectdb.mdf;Integrated Security=True;Connect Timeout=30");
			string command = "select * from BookTable ";
			SqlDataAdapter book_data = new SqlDataAdapter(command, connection);
			DataTable datatable = new DataTable();
			book_data.Fill(datatable);
			connection.Close();
			for (int i = 0; i < datatable.Rows.Count; i++)
			{
				books.Add(new Book(int.Parse(datatable.Rows[i][0].ToString()), datatable.Rows[i][1].ToString(), datatable.Rows[i][2].ToString(), int.Parse(datatable.Rows[i][3].ToString()), double.Parse(datatable.Rows[i][4].ToString()), bool.Parse(datatable.Rows[i][5].ToString()), datatable.Rows[i][6].ToString(), datatable.Rows[i][7].ToString()));
			}
			mybooks = new ObservableCollection<Book>();
			bookmarks = new ObservableCollection<Book>();
			connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yazdi-pc\Desktop\Final-project\firstpage\Finalprojectdb.mdf;Integrated Security=True;Connect Timeout=30");
			command = "select * from ownerTable";
			book_data = new SqlDataAdapter(command, connection);
			datatable = new DataTable();
			book_data.Fill(datatable);
			connection.Close();
			for (int i = 0; i < datatable.Rows.Count; i++)
			{
				if (int.Parse(datatable.Rows[i][0].ToString()) == ID)
				{
					int bookid = int.Parse(datatable.Rows[i][1].ToString());
					IEnumerable<Book> b = books.Where(x => x.id == bookid);
					foreach (var item in b)
					{
						mybooks.Add(item);
						if (bool.Parse(datatable.Rows[i][2].ToString()))
						{
							bookmarks.Add(item);
						}
					}

				}
			}


			

			DataContext = this;
			InitializeComponent();
		}

		private void imgbox_ImageFailed(object sender, ExceptionRoutedEventArgs e)
		{
			e.Source = @"downloadC:\Users\yazdi-pc\Desktop\Final-project\firstpage\firstpage\bin\Debug\net6.0-windows\download.jpg";
		}

		private void Closebtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void HomeTabBtn_Click(object sender, RoutedEventArgs e)
		{
			books.Clear();
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yazdi-pc\Desktop\Final-project\firstpage\Finalprojectdb.mdf;Integrated Security=True;Connect Timeout=30");
			string command = "select * from BookTable ";
			SqlDataAdapter book_data = new SqlDataAdapter(command, connection);
			DataTable datatable = new DataTable();
			book_data.Fill(datatable);
			connection.Close();
			for (int i = 0; i < datatable.Rows.Count; i++)
			{
				books.Add(new Book(int.Parse(datatable.Rows[i][0].ToString()), datatable.Rows[i][1].ToString(), datatable.Rows[i][2].ToString(), int.Parse(datatable.Rows[i][3].ToString()), double.Parse(datatable.Rows[i][4].ToString()), bool.Parse(datatable.Rows[i][5].ToString()), datatable.Rows[i][6].ToString(), datatable.Rows[i][7].ToString()));
			}
			tabcntrl.SelectedIndex = 0;
		}

		private void MyLibraryTabBtn_Click(object sender, RoutedEventArgs e)
		{
			
			mybooks.Clear();
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yazdi-pc\Desktop\Final-project\firstpage\Finalprojectdb.mdf;Integrated Security=True;Connect Timeout=30");
			string command = "select * from ownerTable";
			SqlDataAdapter book_data = new SqlDataAdapter(command, connection);
			DataTable datatable = new DataTable();
			book_data.Fill(datatable);
			connection.Close();
			for (int i = 0; i < datatable.Rows.Count; i++)
			{
				if (int.Parse(datatable.Rows[i][0].ToString()) == ID)
				{
					int bookid = int.Parse(datatable.Rows[i][1].ToString());
					IEnumerable<Book> b= books.Where(x => x.id == bookid);
					foreach (var item in b)
					{
						mybooks.Add(item);
					}
					
				}
			}

			tabcntrl.SelectedIndex = 1;
		}

		private void BookmarkTabBtn_Click(object sender, RoutedEventArgs e)
		{
			bookmarks.Clear();
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yazdi-pc\Desktop\Final-project\firstpage\Finalprojectdb.mdf;Integrated Security=True;Connect Timeout=30");
			string command = "select * from ownerTable";
			SqlDataAdapter book_data = new SqlDataAdapter(command, connection);
			DataTable datatable = new DataTable();
			book_data.Fill(datatable);
			connection.Close();
			for (int i = 0; i < datatable.Rows.Count; i++)
			{
				if (int.Parse(datatable.Rows[i][0].ToString()) == ID && bool.Parse(datatable.Rows[i][2].ToString()))
				{
					int bookid = int.Parse(datatable.Rows[i][1].ToString());
					IEnumerable<Book> b = books.Where(x => x.id == bookid);
					foreach (var item in b)
					{
							bookmarks.Add(item);
					}

				}
			}
			tabcntrl.SelectedIndex = 2;
		}

		private void ValetTabBtn_Click(object sender, RoutedEventArgs e)
		{
			tabcntrl.SelectedIndex = 3;
		}

		private void VIPTabBtn_Click(object sender, RoutedEventArgs e)
		{
			tabcntrl.SelectedIndex = 4;
		}

		private void UserDataTabbtn_Click(object sender, RoutedEventArgs e)
		{
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yazdi-pc\Desktop\Final-project\firstpage\Finalprojectdb.mdf;Integrated Security=True;Connect Timeout=30");
			string command = "select * from UsersTable ";
			SqlDataAdapter book_data = new SqlDataAdapter(command, connection);
			DataTable datatable = new DataTable();
			book_data.Fill(datatable);
			connection.Close();
			
			for (int i = 0; i < datatable.Rows.Count; i++)
			{
				if (int.Parse(datatable.Rows[i][0].ToString()) == ID)
				{
					user = new tabUser(datatable.Rows[i][1].ToString(), datatable.Rows[i][2].ToString(), datatable.Rows[i][3].ToString(), datatable.Rows[i][4].ToString(), datatable.Rows[i][5].ToString(), datatable.Rows[i][6].ToString());
					break;
				}
			}
			Namebox.Text = user.name;
			Lastnamebox.Text = user.lastname;
			Phonebox.Text = user.phone;
			Emailbox.Text = user.email;
			signupUsernamebox.Text = user.username;
			signuppasswordbox.Password = user.password;
			signuppassboxtxt.Text = user.password;
			tabcntrl.SelectedIndex = 5;
		}

		private void CartTabBtn_Click(object sender, RoutedEventArgs e)
		{
			tabcntrl.SelectedIndex = 6;
		}

		private void Signoutbtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow m = new MainWindow();
			m.Show();
			this.Close();
		}

		private void Savebtn_Click(object sender, RoutedEventArgs e)
		{
			string Name = Namebox.Text;
			string Lastname = Lastnamebox.Text;
			string Phone = Phonebox.Text;
			string Email = Emailbox.Text;
			string Username = signupUsernamebox.Text;
			string Password = signuppasswordbox.Password;
			string Confirmpassword = confirmpasswordbox.Password;
			int flg = 0;

			if (!User.Name_Check(Name))
			{
				flg = 1;
				signupnameerrorbox.Text = "Name should contain between 3 to 32 character!";
			}
			if (!User.Name_Check(Lastname))
			{
				flg = 1;
				signuplastnameerrorbox.Text = "Lastname should contain between 3 to 32 character!";
			}
			if (!User.Phone_Check(Phone))
			{
				flg = 1;
				signupphoneerrorbox.Text = "Phone number should start with 09 and has 11 digit!";
			}
			if (!User.Email_check(Email))
			{
				flg = 1;
				signupemailerrorbox.Text = "It's not in email form!";
			}
			else if (User.Email_Already_Exist(Email)&&Email!=user.email)
			{
				flg = 1;
				signupemailerrorbox.Text = "This email already signedup!";
			}
			if (User.Username_already_exist(Username)&&Username!=user.username)
			{
				flg = 1;
				signupUsernameerrorbox.Text = "This username already exist!";
			}
			if (!User.Password_Check(Password))
			{
				flg = 1;
				signuppassworderrorbox.Text = "Password should atleast has 8 character and contain upper and lowercase char !";
			}
			if (Password != Confirmpassword)
			{
				flg = 1;
				signupconfirmpassbox.Text = "It should be same as password!";
			}
			if (flg == 0)
			{
				user.edit(Name, Lastname, Phone, Email, Username, Password,ID);
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

		private void signupUsernamebox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			signupUsernameerrorbox.Text = "";
		}

		private void readbtn_Click(object sender, RoutedEventArgs e)
		{
			Button b = (Button)sender;
			Book bo = (Book)b.DataContext;

			Process process = new Process();
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.FileName = bo.pdf;
			process.Start();
		}
	}
}
