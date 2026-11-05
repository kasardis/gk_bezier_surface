using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BezierSurface
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            InitializeHelp();
        }

        private WebBrowser browser;

        private void InitializeHelp()
        {
            browser = new WebBrowser();
            browser.Dock = DockStyle.Fill;
            this.Controls.Add(browser);

            string htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "help.html");
            if (File.Exists(htmlPath))
                browser.Navigate(htmlPath);
            else
                browser.DocumentText = "<h1>Błąd</h1><p>Brak pliku help.html.</p>";
        }
    }
}
