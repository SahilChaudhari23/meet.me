﻿using System;
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
using Client.ViewModels;

namespace Client
{
    public partial class LoginWindow : Window
    {
        private MainWindow obj = new MainWindow();
        public LoginWindow()
        {
            InitializeComponent();
        }
        
        private void onJoinClick(object sender, RoutedEventArgs e)
        {
            obj.Show();
            Close();
           /* Page mainPage = new MainPage();
            MainFrame.Navigate(mainPage);*/
        }
    }
}