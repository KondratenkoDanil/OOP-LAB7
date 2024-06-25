using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MultiWindowTextEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorForm newEditor = new EditorForm();
            newEditor.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Метод для зміни мови інтерфейсу на англійську
        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
        }

        // Метод для зміни мови інтерфейсу на українську
        private void UkrainianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("uk");
        }

        // Метод для зміни мови інтерфейсу
        private void ChangeLanguage(string languageCode)
        {
            foreach (Control control in Controls)
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
                resources.ApplyResources(control, control.Name, new CultureInfo(languageCode));
            }
        }
    }

    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();
        }

        private void SaveAsRtfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "RTF Files|*.rtf";
            saveFileDialog.Title = "Save as RTF";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }

        // Метод для вирівнювання тексту по лівому краю
        private void LeftAlignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        // Метод для вирівнювання тексту по правому краю
        private void RightAlignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        // Метод для вирівнювання тексту по центру
        private void CenterAlignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        // Метод для зміни шрифту тексту
        private void ChangeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = fontDialog.Font;
            }
        }
    }
}