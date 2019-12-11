using projectView.Connection;
using projectView.entities;
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

namespace projectView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApiConnector connector = new ApiConnector();
        List<Categories> categories;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListWindow list = new ListWindow();
            list.Show();
            this.Close();

            /*/
            try
            {
                categories = connector.Get_categories();
                //Guid test = connector.Login("admin", "admin!");
                int test2 = 1;
            }
            catch (Exception ex)
            {
                int test = 1;
            }
            //*/
        }
    }
}
