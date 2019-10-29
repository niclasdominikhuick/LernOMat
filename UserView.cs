using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lern_O_Mat
{
    public partial class UserView : Form, IUserView
    {
        private int mouseMove;
        private int mouseX;
        private int mouseY;

        public UserView()
        {
            InitializeComponent();

            foreach (String s in Controller.GetWordboxlistController())
            {
                listBoxUserWordbox.Items.Add(s);
            }
        }

        private void ButtonUserMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonUserClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserView_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMove = 1;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void UserView_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        private void UserView_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMove = 0;
        }

        private void ButtonUserEditWordbox_Click(object sender, EventArgs e)
        {
            EditWordboxView editWordboxView = new EditWordboxView();
            editWordboxView.ShowDialog();
        }

        private void ButtonUserRefresh_Click(object sender, EventArgs e)
        {
            listBoxUserWordbox.Items.Clear();

            foreach (String s in Controller.GetWordboxlistController())
            {
                listBoxUserWordbox.Items.Add(s);
            }
        }

        private void ButtonUserEditWords_Click(object sender, EventArgs e)
        {
            EditWordsView editWordsView = new EditWordsView();
            editWordsView.ShowDialog();
        }

        private void ButtonUserLearn_Click(object sender, EventArgs e)
        {
            textBoxUserQuestion.Text = Controller.StartLearn(listBoxUserWordbox.SelectedItem.ToString());
            buttonUserLearn.Visible = false;
            buttonUserEditWordbox.Enabled = false;
            buttonUserEditWords.Enabled = false;
        }

        private void ButtonUserNext_Click(object sender, EventArgs e)
        {
            if (Controller.LearnCheck(textBoxUserAnswer.Text) == false)
            {
                MessageBox.Show("Die richtige Antwort ist: " + Controller.GetLearnAnswer(), "", MessageBoxButtons.OK);
            }
            else
            {

            }

            Controller.currentPosition++;
        }
    }
}
