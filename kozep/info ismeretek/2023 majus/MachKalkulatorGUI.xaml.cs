using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace practiceWPF
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

		private void Calc(object sender, RoutedEventArgs e)
		{
			try
			{
				double doubleQC = double.Parse(qc.Text.Replace(',', '.'));
				double doubleP0 = double.Parse(p0.Text.Replace(',', '.'));
				double Ma = Math.Sqrt(5 * (Math.Pow(doubleQC / doubleP0 + 1, ((double)2) / 7) - 1));
				list.Items.Add($"qc={doubleQC} p0={doubleP0} Ma={Ma}");
			}catch
			{
				MessageBox.Show("Nem megfelelo a beneti karakterlanc formatuma.");
			}
			
			
		}
	}
}
