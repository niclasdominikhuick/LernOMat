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
    public partial class EditWordboxView : Form, IEditWordboxView
    {
        private int mouseMove;
        private int mouseX;
        private int mouseY;

        public EditWordboxView()
        {
            InitializeComponent();

            foreach (String s in Controller.GetWordboxlistController())
            {
                listBoxEditWordbox.Items.Add(s);
            }
        }

        private void ButtonEditWordboxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonEditWordboxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonEditWordboxDelete_Click(object sender, EventArgs e)
        {
            Controller.EditWordboxDeleteWordbox(Convert.ToString(listBoxEditWordbox.SelectedItem));
            listBoxEditWordbox.Items.Clear();

            foreach (String s in Controller.GetWordboxlistController())
            {
                listBoxEditWordbox.Items.Add(s);
            }
        }

        private void ButtonEditWordboxAdd_Click(object sender, EventArgs e)
        {
            Controller.EditWordboxAddWordbox(textBoxEditWordboxQuestion.Text, textBoxEditWordboxAnswer.Text);
            listBoxEditWordbox.Items.Clear();

            foreach (String s in Controller.GetWordboxlistController())
            {
                listBoxEditWordbox.Items.Add(s);
            }
        }

        private void EditWordboxView_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMove = 1;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void EditWordboxView_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        private void EditWordboxView_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMove = 0;
        }
    }
}
