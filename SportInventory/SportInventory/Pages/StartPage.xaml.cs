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

namespace SportInventory.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            StartList.ItemsSource = Data.SportEntities.GetContext().User.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Classe.Manager.MainFrame.Navigate(new Pages.AddEditPage((sender as Button).DataContext as Data.User));
            Init();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Classe.Manager.MainFrame.Navigate(new Pages.AddEditPage(null));
            Init();
        }
    }
}
