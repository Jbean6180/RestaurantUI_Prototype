using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();

            ApplicationState.StateUpdated += (sender, args) =>
            {
                if (ApplicationState.Instance.CurrentState == ApplicationStates.LoginScreen)
                {
                    Visibility = Visibility.Visible;
                }
                else
                {
                    Visibility = Visibility.Collapsed;
                }
            };
        }

        private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (StreamReader reader = new StreamReader("AppResources/users.json"))
            {
                var json = reader.ReadToEnd();
                var user = JsonConvert.DeserializeObject<List<User>>(json);

                if (user.FirstOrDefault(i => i.Password == PasswordTextBox.Text &&
                                             i.Username == UsernameTextBox.Text) != null)
                {
                    ApplicationState.Instance.SetState(ApplicationStates.TableScreen);
                }

            }
        }
    }
}
