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
using TestPageInDG.Model;

namespace TestPageInDG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int countPage = 0;
        int currentPage = 1;
        DBEntities db = new DBEntities();
        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            if (currentPage == countPage) BtnEnd.IsEnabled = false; else BtnEnd.IsEnabled = true;
            if (currentPage == 1) BtnStart.IsEnabled = false;
            else BtnStart.IsEnabled = true;
             countPage = db.Employees.ToList().Count() / 5;
            DG.ItemsSource = db.Employees.ToList().GetRange((currentPage-1) * 5, 5);
        }

        private void BtnStartClick(object sender, RoutedEventArgs e)
        {
            currentPage = 1;
            Update();
        }

        private void BtnEndClick(object sender, RoutedEventArgs e)
        {
            currentPage = countPage;
            Update();
        }

        private void BtnNextClick(object sender, RoutedEventArgs e)
        {
            if (currentPage < countPage)
            {
            currentPage++;
            Update();
            }
        }

        private void BtnPrevClick(object sender, RoutedEventArgs e)
        {
            if (currentPage !=1)
            {
                currentPage--;
                Update();
            }
        }

        private void TbKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
                int selectPage = int.Parse(TbPage.Text);
                if (selectPage>0 && selectPage <= countPage)
                {
                    currentPage = selectPage;
                    Update();
                }
            }
        }
    }
}
