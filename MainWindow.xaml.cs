﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;

namespace Metal_Code.Updater
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string serverPath = $"C:\\Users\\Михаил\\Desktop\\Тест\\Файлы";
        readonly string serverPath = $"Y:\\Конструкторский отдел\\Расчет Заказов ЛФ Сервер\\Metal-Code_Local\\Metal-Code_Local";

        public MainWindow()
        {
            InitializeComponent();

            Thread.Sleep(2000);

            UpdateApp();
        }

        public void UpdateApp()
        {
            if (Directory.Exists(serverPath))
            {
                foreach (string file in Directory.GetFiles(serverPath))
                    File.Copy(file, Directory.GetCurrentDirectory() + $"\\{Path.GetFileName(file)}", true);
            }

            Process.Start(Directory.GetCurrentDirectory() + "\\Metal-Code.exe");
            Environment.Exit(0);
        }
    }
}
