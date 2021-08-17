using Gradebook.Models;
using Gradebook.ViewModels;
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
using System.Windows.Shapes;

namespace Gradebook.Views
{
    /// <summary>
    /// Interaction logic for RegistrationTeacher.xaml
    /// </summary>
    public partial class RegistrationTeacher : Window, IPasswordSupplier
    {
        public RegistrationTeacher()
        {
            InitializeComponent();
        }
        public string GetPassword()
        {
            return PasswordText.Password;
        }
    }
}
