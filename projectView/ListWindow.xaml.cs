using projectView.Connection;
using projectView.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projectView
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        DispatcherTimer refresher = new DispatcherTimer();
        ApiConnector connector = new ApiConnector();
        List<Categories> CategorieList;
        List<Components> components = new List<Components>();
        List<string> sortingLst = new List<string>() { "open", "closed" };

        public ListWindow()
        {
            InitializeComponent();
            DataContext = this;
            cbStatus.ItemsSource = sortingLst;
            cbStatus.SelectedIndex = 0;

            UpdateContent();

            refresher.Interval = TimeSpan.FromMilliseconds(3000);
            refresher.Tick += timer_Tick;
            refresher.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateContent();
        }

        private void UpdateContent()
        {
            int index = cbCategory.SelectedIndex;
            CategorieList = null;
            
            if (GetDataContext())
            {
                components = new List<Components>(); ;
                cbCategory.ItemsSource = CategorieList;
                int selectedIndex = index >= 0 ? index : 0;
                cbCategory.SelectedIndex = selectedIndex;

                SetContent();
            }
        }

        private void SetContent()
        {
            int index = cbCategory.SelectedIndex;
            int statusIndex = cbStatus.SelectedIndex;

            components = CategorieList[index].Components.ToList();

            if (statusIndex == 1)
            {
                components = components.OrderBy(comp => comp.status).ThenBy(n => n.name).ToList();
            }
            else
            {
                components = components.OrderByDescending(comp => comp.status).ToList();
            }

            lv.ItemsSource = components;
        }

        public bool GetDataContext()
        {
            try
            {
                CategorieList = connector.Get_categories();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (components.Count != 0)
            {
                SetContent();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateContent();
        }
    }
}
