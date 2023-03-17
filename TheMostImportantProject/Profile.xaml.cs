using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace TheMostImportantProject
{

    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }
        private void Label_MouseUpGoToMenu(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MenuScreen menuScreen = new MenuScreen();
            menuScreen.Show();
            this.Close();
        }

        private void Label_MouseUpGoToBasket(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Basket basket = new Basket();
            basket.Show();
            this.Close();
        }

        private void Label_MouseUpGoToOrders(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

      

        
    }
}
