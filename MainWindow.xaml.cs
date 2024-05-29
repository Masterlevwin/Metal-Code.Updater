using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Metal_Code.Updater
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string serverPath = $"Y:\\Конструкторский отдел\\Расчет Заказов ЛФ Сервер\\Metal-Code_Local\\Metal-Code_Local";

        public MainWindow()
        {
            InitializeComponent();

            if (CheckVersion()) UpdateApp();

            Process.Start(Directory.GetCurrentDirectory() + "\\Metal-Code.exe");
            Environment.Exit(0);
        }

        public bool CheckVersion()
        {
            FileInfo serverVersionFile = new FileInfo(serverPath + "\\version.txt");
            FileInfo localVersionFile = new FileInfo(Directory.GetCurrentDirectory() + "\\version.txt");

            return serverVersionFile.Exists && localVersionFile.Exists
                && File.ReadAllText(serverPath + "\\version.txt") == File.ReadAllText(Directory.GetCurrentDirectory() + "\\version.txt");
        }

        public void UpdateApp()
        {
            FileInfo lib = new FileInfo(serverPath + "\\Metal-Code.dll");
            lib.CopyTo(Directory.GetCurrentDirectory() + "\\Metal-Code.dll", true);
        }
    }
}
