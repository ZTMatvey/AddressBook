﻿using AddressBook.ViewModel;
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

namespace AddressBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BitmapImage _minimize;
        private readonly BitmapImage _maximize;
        private bool _isMinimized;
        public MainWindow()
        {
            InitializeComponent();
            _minimize = new BitmapImage();
            _minimize.BeginInit();
            _minimize.UriSource = new Uri("pack://application:,,,/Images/close_fullscreen.png");
            _minimize.EndInit();
            _maximize = new BitmapImage();
            _maximize.BeginInit();
            _maximize.UriSource = new Uri(@"pack://application:,,,/Images/open_in_full.png");
            _maximize.EndInit();
            Minimize();
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            ((NavigationVM)DataContext).SavePeople();
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Minimize()
        {
            _isMinimized = true;
            WindowState = WindowState.Normal;
            MaxMinApp.Background = new ImageBrush(_maximize);
        }


        private void Maximize()
        {
            _isMinimized = false;
            WindowState = WindowState.Maximized;
            MaxMinApp.Background = new ImageBrush(_minimize);
        }

        private void MaxMinApp_Click(object sender, RoutedEventArgs e)
        {
            if (_isMinimized)
            {
                Maximize();
            }
            else
            {
                Minimize();
            }
        }
    }
}