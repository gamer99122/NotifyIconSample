using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotifyIconSample
{
    public partial class Main : Form
    {
        private NotifyIcon notifyIcon;
        private ContextMenu contextMenu;
        private bool isFormVisible;

        public Main()
        {
            InitializeComponent();
            InitializeNotifyIcon();
        }

        private void InitializeNotifyIcon()
        {
            // 創建 NotifyIcon 控制項
            notifyIcon = new NotifyIcon();

            // 設置圖示
            //notifyIcon.Icon = Properties.Resources.YourIcon; // 替換成你的圖示
            // 指定本地檔案的路徑作為圖示
            string iconPath = @"C:\Users\Lawliet\Desktop\CodeProject\NotifyIconSample\Resources\icon.ico";
            notifyIcon.Icon = new Icon(iconPath);

            // 創建右鍵選單
            contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add("顯示", OnShowClick);
            contextMenu.MenuItems.Add("退出", OnExitClick);

            // 將右鍵選單指定給 NotifyIcon
            notifyIcon.ContextMenu = contextMenu;

            // 設置雙擊事件
            notifyIcon.DoubleClick += OnNotifyIconDoubleClick;

            // 顯示 NotifyIcon
            notifyIcon.Visible = true;
        }

        private void OnShowClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void OnExitClick(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ShowForm()
        {
            if (!isFormVisible)
            {
                Show();
                WindowState = FormWindowState.Normal;
                isFormVisible = true;
            }
        }

        private void ExitApplication()
        {
            // 釋放 NotifyIcon 相關資源
            notifyIcon.Visible = false;
            notifyIcon.Dispose();

            // 退出應用程式
            Application.Exit();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                isFormVisible = false;
            }
        }
    }
}
