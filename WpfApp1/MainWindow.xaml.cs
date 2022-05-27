using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var Products = new table().products;
            ProductGrid.ItemsSource = Products;
            if (XLSFile.Save())
                MessageBox.Show("Plik Excel został utworzony");
            else MessageBox.Show("Plik Excel nie został utworzony");
        }
    }
}
