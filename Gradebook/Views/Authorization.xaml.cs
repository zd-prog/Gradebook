using Gradebook.Models;
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

namespace Gradebook
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public interface IPasswordSupplier
    {
        string GetPassword();
    }
    public partial class Authorization : Window, IPasswordSupplier
    {
        public Authorization()
        {
            InitializeComponent();
        }
        public string GetPassword()
        {
            return PasswordU.Password;
        }
    }
}
