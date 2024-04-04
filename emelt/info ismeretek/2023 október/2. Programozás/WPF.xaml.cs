using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfproject
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

        private void Generate(object sender, RoutedEventArgs e)
        {
            sp.Children.Clear();
            Random rnd = new();
            HashSet<int> hs = new();
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(j == 2 && i == 2)
                        sp.Children.Add(new TextBox()
                        {
                            Text = "X",
                            IsEnabled = false,
                            Width = 30,
                            Margin = new(10)
                        });
                    else
                    {
                        while (true)
                        {
                            var rn = rnd.Next(j * 15 + 1, (j + 1) * 15 + 1);
                            if (!hs.Add(rn)) continue;
                            sp.Children.Add(new TextBox()
                            {
                                Text = rn.ToString(),
                                Width = 30,
                                Margin = new(10)
                            });
                            break;
                        }
                    }
                        
                }
            }
            
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < sp.Children.Count; i++)
            {
                if (i % 5 == 0) sb.Append("\n");
                sb.Append($"{(sp.Children[i] as TextBox).Text}");
                if ((i + 1) % 5 != 0) sb.Append(";");
            }
            Debug.WriteLine(sb.ToString());
            File.WriteAllText(filename.Text, sb.ToString());
        }
    }
}