using System;
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
        //string serverPath = $"C:\\Users\\maste\\Metal-Code\\bin\\Release\\net7.0-windows";
        string serverPath = $"Y:\\Конструкторский отдел\\Расчет Заказов ЛФ Сервер\\Metal-Code_Local\\Metal-Code_Local";

        public MainWindow()
        {
            InitializeComponent();

            Thread.Sleep(2000);

            UpdateApp();
        }

        public void UpdateApp()
        {
            if (File.Exists(serverPath + "\\version.txt"))
            {
                FileInfo serverVersionFile = new FileInfo(serverPath + "\\version.txt");
                serverVersionFile.CopyTo(Directory.GetCurrentDirectory() + "\\version.txt", true);
            }

            if (File.Exists(serverPath + "\\Metal-Code.dll"))
            {
                FileInfo lib = new FileInfo(serverPath + "\\Metal-Code.dll");
                lib.CopyTo(Directory.GetCurrentDirectory() + "\\Metal-Code.dll", true);
            }

            Process.Start(Directory.GetCurrentDirectory() + "\\Metal-Code.exe");

            Environment.Exit(0);
        }
    }
}
