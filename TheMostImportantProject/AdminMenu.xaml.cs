﻿using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TheMostImportantProject
{
    public partial class AdminMenu : Window
    {
        public AdminMenu()
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

        private void Label_MouseUpGoToProfile(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillMenu();
        }

        public void FillMenu()
        {
            MainPlace.Children.Clear();
            using (Pizza_MozzarellaEntities db = new Pizza_MozzarellaEntities())
            {
                foreach (var position in db.Position)
                {

                    CreatePositionBlock(position);

                }
            }
        }

        public void CreatePositionBlock(Position position)
        {
            Border border = new Border();
            StackPanel stackPanel = new StackPanel();
            DockPanel dockPanel = new DockPanel();
            Image image = new Image();
            Label labelId = new Label();
            Label labelName = new Label();
            Label labelPrice = new Label();
            Button buttonBuy = new Button();
            Button buttonDelete = new Button();

            border.Margin = new Thickness(178, 25, 0, 10);
            border.BorderThickness = new Thickness(2);
            border.BorderBrush = Brushes.HotPink;
            border.Width = 270;
            border.Height = 450;
            if (position.IsHidden == true)
            {
                border.Background = Brushes.LightGray;
            }

            stackPanel.Width = 250;
            stackPanel.Height = 450;
            

            image.Width = image.Height = 250;

            labelId.Visibility = Visibility.Collapsed;
            labelId.Content = position.PositionID;
            labelId.Name = "Id";

            labelName.FontSize = 20;
            labelPrice.FontSize = 20;
            labelPrice.HorizontalAlignment = HorizontalAlignment.Right;



            MemoryStream ms = new MemoryStream(position.Image);
            image.Source = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

            labelName.Content = position.Name;
            labelPrice.Content = string.Format("{0:0.00}", position.Price) + " Р";

            DockPanel.SetDock(labelName, Dock.Left);
            DockPanel.SetDock(labelPrice, Dock.Right);

            dockPanel.Children.Add(labelName);
            dockPanel.Children.Add(labelPrice);

            stackPanel.Children.Add(image);
            stackPanel.Children.Add(dockPanel);
            stackPanel.Children.Add(buttonBuy);
            stackPanel.Children.Add(buttonDelete);

            border.Child = stackPanel;

            MainPlace.Children.Add(border);


        }

        public void ChangePosition(object sender, RoutedEventArgs e)
        {
            string idString = (sender as Button).Name.Remove(0, 3);
            int Id = Convert.ToInt32(idString);


            Position position = new Position();

            using (Pizza_MozzarellaEntities db = new Pizza_MozzarellaEntities())
            {
                position = db.Position.Where(p => p.PositionID == Id).First();
            }

            PositionAdd positionAdd = new PositionAdd(position);
            positionAdd.Show();
            this.Close();
        }

        public void DeletePosition(object sender, RoutedEventArgs e)
        {
            string idString = (sender as Button).Name.Remove(0, 3);
            int Id = Convert.ToInt32(idString);


            Position position = new Position();

            using (Pizza_MozzarellaEntities db = new Pizza_MozzarellaEntities())
            {
                position = db.Position.Where(p => p.PositionID == Id).First();
                db.Position.Remove(position);
                db.SaveChanges();
            }

            FillMenu();
        }

        private void ToEmployees_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void PositionAdd_Click(object sender, RoutedEventArgs e)
        {
            PositionAdd positionAdd = new PositionAdd();
            positionAdd.Show();
            this.Close();
        }
    }
}
