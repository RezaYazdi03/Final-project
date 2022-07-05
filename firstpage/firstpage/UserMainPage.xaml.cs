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
	/// Interaction logic for UserMainPage.xaml
	/// </summary>
	class Book
	{
		public Image image { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public int Page_Number { get; set; }
		public double Price { get; set; }
		public static List<Book> Books { get; set; }
		public Book( Image image , string Name , string Author , int Page_Number , double Price)
		{
			
			this.image = image;
			this.Name = Name;
			this.Author = Author;
			this.Page_Number = Page_Number;
			this.Price = Price;
		}
		static Book()
		{
			Books = new List<Book>();
			//extract data from database and put in Books
		}


	}



	public partial class UserMainPage : Window
	{
		public UserMainPage(/*catch data*/)
		{
			InitializeComponent();
			DataContext = Book.Books;
		}

		private void imgbox_ImageFailed(object sender, ExceptionRoutedEventArgs e)
		{
			e.Source = "download";
		}
		private void Closebtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void HomeTabBtn_Click(object sender, RoutedEventArgs e)
		{
			tabcntrl.SelectedIndex = 0;
		}

		private void MyLibraryTabBtn_Click(object sender, RoutedEventArgs e)
		{
			tabcntrl.SelectedIndex = 1;
		}

		private void BookmarkTabBtn_Click(object sender, RoutedEventArgs e)
		{
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
			tabcntrl.SelectedIndex = 5;
		}

		private void CartTabBtn_Click(object sender, RoutedEventArgs e)
		{
			tabcntrl.SelectedIndex = 6;
		}

	}
}
