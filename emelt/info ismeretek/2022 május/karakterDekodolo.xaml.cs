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
			Loaded += MainWindow_Loaded;
		}

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
			for (int i = 0; i < 7; i++)
			{
				StackPanel childSp = new()
				{
					Orientation = Orientation.Horizontal
				};
				for (int j = 0; j < 4; j++)
				{
					var t = new TextBox()
					{
						Text = "0",
						Margin = new Thickness(2),
						Width = 27,
						Height = 27,
						FontSize = 16,
						TextAlignment = TextAlignment.Center
					};
                    t.TextChanged += T_TextChanged;
                    t.PreviewMouseDoubleClick += T_PreviewMouseDoubleClick;
					childSp.Children.Add(t);
					
                }
				sp.Children.Add(childSp);
			}
        }

        private void T_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tbox = sender as TextBox;
			if (tbox.Text == "0") tbox.Text = "1";
            else tbox.Text = "0";
        }

        private void T_TextChanged(object sender, TextChangedEventArgs e)
        {
			var tbox = sender as TextBox;
            if (tbox.Text == "1")
			{
				tbox.Background = Brushes.LightGray;
			}
			else tbox.Background = Brushes.White;
        }
    }
}
