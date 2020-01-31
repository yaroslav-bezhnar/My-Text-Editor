using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        bool edited; // true if document edited
        FileInfo currentFile;
        FontStyle fontStyle;
        Font copyfont;
        
        public bool Edited { get { return edited; } set { edited = value; } }
        public FileInfo CurrentFile { get { return currentFile; } set { currentFile = value; } }
        public Font CopyFont { get { return copyfont; } set { copyfont = value; } }
        public FontStyle FontStyle
        {
            get { return fontStyle; }
            set
            {
                fontStyle = value;
                //Check which buttons we have to set as checked and which not
                btnBold.Checked = cmsBold.Checked = (FontStyle & FontStyle.Bold) != 0 ? true : false;
                btnItalic.Checked = cmsItalic.Checked = (FontStyle & FontStyle.Italic) != 0 ? true : false;
                btnUnderline.Checked = cmsUnderline.Checked = (FontStyle & FontStyle.Underline) != 0 ? true : false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnFont.Items.Clear();
            foreach (FontFamily font in FontFamily.Families)
            {
                btnFont.Items.Add(font.Name);
            }
            btnFont.SelectedIndex = 200;
            for (int i = 1; i < 91; i++)
            {
                btnSize.Items.Add(i);
            }
            btnSize.SelectedIndex = 11;
        }
        FontFamily GetFontFamilyByName(string name)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                if (font.Name == name)
                {
                    return font;
                }
            }
            return FontFamily.GenericMonospace;
        }
        void OpenDocument()
        {
            DialogResult openFileResult = openFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                // open file and load in text field
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                CurrentFile = new FileInfo(openFileDialog1.FileName);
                Text = "Word Processor - " + CurrentFile.Name;
            }
        }
        void SaveDocument()
        {
            if (CurrentFile != null)
            {
                if (CurrentFile.Exists)
                {
                    richTextBox1.SaveFile(CurrentFile.FullName, RichTextBoxStreamType.RichText);
                    return;
                }
            }
            DialogResult saveFileResult = saveFileDialog1.ShowDialog();
            if (saveFileResult == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                CurrentFile = new FileInfo(saveFileDialog1.FileName);
                this.Text = "Word Processor - " + CurrentFile.Name;
            }
        }
        void NewDocument()
        {
            Form1 newDoc = new Form1();
            newDoc.Show();
            newDoc.Text = "Новий документ";
        }
        void ChangeSelectedFont(FontFamily family, float size)
        {
            int startSelection = richTextBox1.SelectionStart;
            int selectionLength = richTextBox1.SelectionLength;

            // default if don't have selection
            if (richTextBox1.SelectionLength == 0)
            {
                if (family != null)
                    richTextBox1.Font = new Font(family, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                if (size != 0)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
            }
            else if (richTextBox1.SelectionLength == richTextBox1.Text.Length)
            {
                if (family != null)
                    richTextBox1.Font = new Font(family, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                if (size != 0)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
            }
            else if (richTextBox1.SelectionLength != richTextBox1.Text.Length)
            {
                if (family != null)
                    richTextBox1.SelectionFont = new Font(family, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                if (size != 0)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
            }
            richTextBox1.SelectionStart = startSelection;
            richTextBox1.SelectionLength = selectionLength;
            richTextBox1.Focus();
        }

        private void btnFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSelectedFont(GetFontFamilyByName(btnFont.Text), 0);
        }

        private void btnSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSelectedFont(null, float.Parse(btnSize.Text));
        }

        private void btnNewDoc_Click(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void btnOpenDoc_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void btnSaveDoc_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (Edited == false)
                Edited = true;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
                return;
            if (!btnBold.Checked)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Bold);
                btnBold.Checked = tsmBold.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);
                btnBold.Checked = tsmBold.Checked = false;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
                return;
            if (!btnItalic.Checked)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Italic);
                btnItalic.Checked = tsmItalic.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);
                btnItalic.Checked = tsmItalic.Checked = false;
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
                return;
            if (!btnUnderline.Checked)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Underline);
                btnUnderline.Checked = tsmUnderline.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);
                btnUnderline.Checked = tsmUnderline.Checked = false;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(richTextBox1);
            search.Show();
        }

        private void btnReplace_ButtonClick(object sender, EventArgs e)
        {
            ReplaceForm replace = new ReplaceForm(richTextBox1);
            replace.Show();
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            btnPaste.Enabled = true;
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (richTextBox1.SelectedText.Length > 0)
            //{
            //    btnCut.Enabled = tsbCopyFont.Enabled = true;
            //}
            //else
            //{
            //    btnCut.Enabled = tsbCopyFont.Enabled = false;
            //}
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Black;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Green;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Yellow;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Blue;
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.White;
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Gray;
        }

        private void tsmPrint_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (CopyFont != null)
            {
                if (richTextBox1.SelectionFont != null)
                {
                    richTextBox1.SelectionFont = CopyFont;
                    CopyFont = null;
                }
            }

            //Check which font style we have
            FontStyle = FontStyle.Regular;
            if (richTextBox1.SelectionFont != null)
            {
                if (richTextBox1.SelectionFont.Bold)
                    FontStyle |= FontStyle.Bold;
                if (richTextBox1.SelectionFont.Italic)
                    FontStyle |= FontStyle.Italic;
                if (richTextBox1.SelectionFont.Underline)
                    FontStyle |= FontStyle.Underline;
            }
        }

        private void tsmCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            btnPaste.Enabled = true;
        }

        private void tsmCut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            btnPaste.Enabled = true;
        }

        private void tsmPaste_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void tsmBold_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
                return;
            if (!btnBold.Checked)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Bold);
                btnBold.Checked = tsmBold.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);
                btnBold.Checked = tsmBold.Checked = false;
            }
        }

        private void tsmUnderline_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
                return;
            if (!btnUnderline.Checked)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Underline);
                btnUnderline.Checked = tsmUnderline.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);
                btnUnderline.Checked = tsmUnderline.Checked = false;
            }
        }

        private void tsmItalic_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
                return;
            if (!btnItalic.Checked)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Italic);
                btnItalic.Checked = tsmItalic.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);
                btnItalic.Checked = tsmItalic.Checked = false;
            }
        }

        private void tsmSearch_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(richTextBox1);
            search.Show();
        }

        private void tsmReplace_Click(object sender, EventArgs e)
        {
            ReplaceForm replace = new ReplaceForm(richTextBox1);
            replace.Show();
        }

        private void tsmNewDoc_Click(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void tsmOpenDoc_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
