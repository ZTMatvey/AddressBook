using AddressBook.ViewModel;
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

namespace AddressBook.View
{
    /// <summary>
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class Book : UserControl
    {
        public Book()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = DataContext as BookVM;
            if (context != null)
            {
                context.DeleteCommand.Execute(this);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var context = DataContext as BookVM;
            if (context != null)
            {
                context.EditCommand.Execute(this);
            }
        }
    }
}
