using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotePad;

namespace NotePad
{
    public partial class Ni : Form
    {
        File newFile;
        System.IO.StreamWriter objWriter;
        public Ni()
        {
            InitializeComponent();
        }

        private void Save()
        {
            saveFileDialog1.Filter = "Text(*.text)|*.text";
            saveFileDialog1.Title = "Save";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter objWriter = new System.IO.StreamWriter(saveFileDialog1.FileName);
                objWriter.Write(richTextBox1.Text);
                objWriter.Close();
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                newFile = new File();
            else
            {
                MessageBox.Show("Save Your Work First!");
                Save();
            }
                
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {           
            if (richTextBox1.Text == "")
            {               
                openFileDialog1.Title = "Open";
                openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Text(*.text)|*.text";
                if (openFileDialog1.ShowDialog() ==  DialogResult.OK)
                {
                    newFile = new File(openFileDialog1.FileName);
                    System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            else
            {
                MessageBox.Show("Save Your Work First!");
                Save();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text == "")
            {
                if (MessageBox.Show("Are You Sure You want to Quit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    Application.Exit();

                }
            }

            else
            {
                MessageBox.Show("Save Your Work First!");
                Save();
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            Save();

        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                richTextBox1.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                richTextBox1.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)==true)
            {
                richTextBox1.Paste();
            }
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
                richTextBox1.ClearUndo();
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                richTextBox1.SelectedText = "";
        }

        private void mnuFind_Click(object sender, EventArgs e)
        {

        }

        private void Ni_Load(object sender, EventArgs e)
        {
            menuStrip1.ForeColor = Color.LightSlateGray;
        }
    }
}
