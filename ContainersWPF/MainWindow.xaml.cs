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

namespace ContainersWPF
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

        private void buttonWrapPanel_Click(object sender, RoutedEventArgs e)
        {
            WindowWrapPanel windowWrapPanel = new WindowWrapPanel();
            windowWrapPanel.Show();
        }

        private void buttonStackPanel_Click(object sender, RoutedEventArgs e)
        {
            WindowStackPanel windowStackPanel = new WindowStackPanel();
            windowStackPanel.Show();
        }

        private void buttonDockPanel_Click(object sender, RoutedEventArgs e)
        {
            WindowDockPanel windowDockPanel = new WindowDockPanel();
            windowDockPanel.Show();
        }
        private void buttonGrid_Click(object sender, RoutedEventArgs e)
        {
            WindowGrid windowGrid = new WindowGrid();
            windowGrid.Show();

        }
    }
}
