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

		private void Loginbtn_Click(object sender, RoutedEventArgs e)
		{
			string username = Usernamebox.Text;
			string password = passwordbox.Password;
		}
	}
}
