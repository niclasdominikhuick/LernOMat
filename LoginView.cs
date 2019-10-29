using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lern_O_Mat
{
    public partial class LoginView : Form, ILoginView
    {
        private int mouseMove;
        private int mouseX;
        private int mouseY;

        public LoginView()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                XDocument doc = XDocument.Load("Database.xml");
            }
            catch (Exception)
            {
                XDocument doc = new XDocument(
                    new XElement("userlist")
                );

                doc.Save("Database.xml");
            }
        }

        private void ButtonLoginCreateUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Controller.LoginCreateUser(textBoxLoginUser.Text, textBoxLoginPassword.Text), "", MessageBoxButtons.OK);
        }

        private void ButtonLoginLogin_Click(object sender, EventArgs e)
        {
            if (Controller.LoginLogin(textBoxLoginUser.Text, textBoxLoginPassword.Text) == false)
            {
                MessageBox.Show("Fehlerhafte Eingabe.", "", MessageBoxButtons.OK);
            }

            else
            {
                UserView userView = new UserView();
                userView.Show();
                FindForm().WindowState = FormWindowState.Minimized;
            }
        }

        private void ButtonLoginMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonLoginClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginWindow_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMove = 1;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void LoginWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        private void LoginWindow_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMove = 0;
        }
    }
}
