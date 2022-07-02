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

		private void Backbtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Closebtn_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Loginbtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Backbtn_Click_1(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}
	}
}
