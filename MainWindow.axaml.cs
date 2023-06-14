using Avalonia.Controls;
using ORM_00.Classes;
using System.Linq;

namespace ORM_00
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitElements();
        }

        public void InitElements()
        {
            loginButt.Click += LoginButt_Click;
        }


        //вход по логину и паролю
        private void LoginButt_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                //Переменная пользователя
                var selectedUser = DBClass.db.Users.FirstOrDefault(x => x.Userlogin == loginBox.Text.Trim());

                //Проверка на совпадение данных
                if (selectedUser != null && selectedUser.Userpassword == passBox.Text.Trim())
                {
                    OKRWindow okrWindow = new OKRWindow();

                    okrWindow.Show();
                    this.Close();

                }
                else
                {
                    errorText.IsVisible = true;
                }
            }
            catch
            {
                errorText.IsVisible = true;
            }
        }
    }
}