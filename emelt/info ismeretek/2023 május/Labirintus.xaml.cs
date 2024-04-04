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
		ComboBox cb1;
		ComboBox cb2;
		ComboBox cb3;
		public MainWindow()
		{
			InitializeComponent();
			Loaded += MainWindow_Loaded;
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			cb1 = StackPanel1.Children[1] as ComboBox;
			cb2 = StackPanel1.Children[2] as ComboBox;
			cb3 = StackPanel2.Children[2] as ComboBox;

			for (int i = 5; i <= 20; i++)
			{
				cb1.Items.Add(i);
				cb2.Items.Add(i);
			}
			cb1.SelectedValue = 12;
			cb2.SelectedValue = 12;
			for (int i = 1; i <= 16; i++)
			{
				cb3.Items.Add(i);
			}
			cb3.SelectedValue = 3;
		}

		private void CreateLab(object sender, RoutedEventArgs e)
		{
			SpContainer.Children.Clear();
			for (int i = 0; i < (int)cb1.SelectedValue; i++)
			{
				StackPanel sp = new()
				{
					Orientation = Orientation.Horizontal,
				};
				for (int j = 0; j < (int)cb2.SelectedValue; j++)
				{
					if (i == 1 && j == 0 || j == (int)cb2.SelectedValue - 1 && i == (int)cb1.SelectedValue - 2)
					{
						sp.Children.Add(new CheckBox()
						{
							IsEnabled = false
						});
					}
					else if (i == 0 || i == (int)cb1.SelectedValue - 1 || j == 0 || j == (int)cb2.SelectedValue - 1)
					{
						sp.Children.Add(new CheckBox()
						{
							IsChecked = true,
							IsEnabled = false
						});
					}
					else sp.Children.Add(new CheckBox());
					
				}
				SpContainer.Children.Add(sp);
			}
		}

		private void SaveLab(object sender, RoutedEventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < SpContainer.Children.Count ; i++)
			{
				StackPanel SpCurrentChild = SpContainer.Children[i] as StackPanel;
				for (int j = 0; j < SpCurrentChild.Children.Count; j++)
				{
					CheckBox cb = SpCurrentChild.Children[j] as CheckBox;
					if(cb.IsChecked == true) sb.Append('X');
					else sb.Append(' ');
				}
				sb.Append('\n');
			}
			File.WriteAllText($"Lab{IndexCombo.SelectedValue}.txt", sb.ToString());
		}
	}
}
