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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        public static Data.User currentUser = new Data.User();
        public bool flag = true;
        public AddEditPage(Data.User _user)
        {
            InitializeComponent();
            if(_user == null)
            {
                flag = false;
            }
            else
            {
                currentUser = _user;
                flag = true;
            }
            Init();
        }
        public void Init()
        { GenderComboBox.ItemsSource = Data.SportEntities.GetContext().Gender.ToList();
          RoleComboBox.ItemsSource = Data.SportEntities.GetContext().Role.ToList();
            if (flag == false)  //add
            {
                NameTextBox.Text = null;
                PatronimicTextBox.Text = null;
                SurnameTextBox.Text = null;
                NameTextBox.Text = null;
                GenderComboBox = null; 
                RoleComboBox.SelectedItem = null;
                TelephoneTextBox.Text = null;
                DateBerthTextBox.Text = null;
                Password2TextBox.Text = null;
                PasswordTextBox.Text = null;
                EmailTextBox.Text = null;
                LoginTextBox.Text = null;
            }
            if (flag == true) //edit
            {
                IdTextBlock.Text = currentUser.Id.ToString();
                NameTextBox.Text = currentUser.Name;
                PatronimicTextBox.Text = currentUser.Patronimic;
                SurnameTextBox.Text = currentUser.Surname;
                GenderComboBox.SelectedItem = Data.SportEntities.GetContext().Gender.Where(d=>d.Id == currentUser.IdGender).FirstOrDefault();
                RoleComboBox.SelectedItem = Data.SportEntities.GetContext().Role.Where(d => d.Id == currentUser.IdRole).FirstOrDefault();
                TelephoneTextBox.Text = currentUser.Telephone;
                DateBerthTextBox.Text = currentUser.DataBerth.ToString();
                Password2TextBox.Text = currentUser.Password;
                PasswordTextBox.Text = currentUser.Password;
                EmailTextBox.Text = currentUser.Email;
                LoginTextBox.Text = currentUser.Login;
            }
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            var selectedRole = RoleComboBox.SelectedItem as Data.Role;
            currentUser.IdRole = selectedRole.Id;
            var selectedGender = RoleComboBox.SelectedItem as Data.Gender;
       
            currentUser.Name = NameTextBox.Text;
            currentUser.Surname = SurnameTextBox.Text;
            currentUser.Patronimic = PatronimicTextBox.Text;
            currentUser.Telephone = TelephoneTextBox.Text;
            currentUser.DataBerth = Convert.ToDateTime(DateBerthTextBox.Text).Date;
            if (Password2TextBox.Text == PasswordTextBox.Text)
            {
                currentUser.Password = Password2TextBox.Text;
            }

            currentUser.Email = EmailTextBox.Text;

            currentUser.Login = LoginTextBox.Text;
            if (flag == false)  //add
            {
                Data.SportEntities.GetContext().User.Add(currentUser);
                Data.SportEntities.GetContext().SaveChanges();
            }
            if (flag == true)  //edit
            {
                Data.SportEntities.GetContext().SaveChanges();
              
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Classe.Manager.MainFrame.CanGoBack)
            {
                Classe.Manager.MainFrame.GoBack();
            }

        }
    }
}
