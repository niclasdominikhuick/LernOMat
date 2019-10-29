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
    public partial class EditWordsView : Form, IEditWordsView
    {
        private int mouseMove;
        private int mouseX;
        private int mouseY;

        public EditWordsView()
        {
            InitializeComponent();

            foreach (String s in Controller.GetWordboxlistController())
            {
                listBoxEditWordsWordbox.Items.Add(s);
            }
        }

        private void ButtonEditWordsMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonEditWordsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditWordsView_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMove = 1;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void EditWordsView_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        private void EditWordsView_MouseUp(object sender, MouseEventArgs e)
        {
            mouseMove = 0;
        }

        private void ButtonEditWordsAdd_Click(object sender, EventArgs e)
        {
            Controller.EditWordsAddWord(listBoxEditWordsWordbox.SelectedItem.ToString(), textBoxEditWordsQuestion.Text, textBoxEditWordsAnswer.Text);
        }

        private void ButtonEditWordsRefresh_Click(object sender, EventArgs e)
        {
            listBoxEditWordsQuestion.Items.Clear();

            foreach (String s in Controller.GetQuestionsController(Controller.GetQuestiontopicController(listBoxEditWordsWordbox.SelectedItem.ToString())))
            {
                listBoxEditWordsQuestion.Items.Add(s);
            }

            listBoxEditWordsWordbox.Items.Clear();

            foreach (String s in Controller.GetWordboxlistController())
            {
                listBoxEditWordsWordbox.Items.Add(s);
            }
        }

        private void ButtonEditWordsImportCSV_Click(object sender, EventArgs e)
        {
            if (openFileDialogEditWords.ShowDialog() == DialogResult.OK)
            {
                String path = openFileDialogEditWords.FileName;
                Controller.ConvertCSVtoXML(listBoxEditWordsWordbox.SelectedItem.ToString(), path);
            }
        }

        private void ButtonEditWordsDelete_Click(object sender, EventArgs e)
        {

        }

        private void ButtonEditWordsExportCSV_Click(object sender, EventArgs e)
        {

        }
    }
}
