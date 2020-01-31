using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        #region Fields

        private FontStyle _fontStyle;

        #endregion

        #region Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public bool Edited
        {
            get;
            set;
        }

        public FileInfo CurrentFile
        {
            get;
            set;
        }

        public Font CopyFont
        {
            get;
            set;
        }

        public FontStyle FontStyle
        {
            get => _fontStyle;
            set
            {
                _fontStyle = value;

                //Check which buttons we have to set as checked and which not
                btnBold.Checked = cmsBold.Checked = ( FontStyle & FontStyle.Bold ) != 0;
                btnItalic.Checked = cmsItalic.Checked = ( FontStyle & FontStyle.Italic ) != 0;
                btnUnderline.Checked = cmsUnderline.Checked = ( FontStyle & FontStyle.Underline ) != 0;
            }
        }

        #endregion

        #region Private Methods

        private void Form1_Load( object sender, EventArgs e )
        {
            btnFont.Items.Clear();

            foreach ( var font in FontFamily.Families )
            {
                btnFont.Items.Add( font.Name );
            }

            btnFont.SelectedIndex = 200;

            for ( var i = 1; i < 91; i++ )
            {
                btnSize.Items.Add( i );
            }

            btnSize.SelectedIndex = 11;
        }

        private static FontFamily GetFontFamilyByName( string name )
        {
            foreach ( var font in FontFamily.Families )
            {
                if ( font.Name == name )
                {
                    return font;
                }
            }

            return FontFamily.GenericMonospace;
        }

        private void OpenDocument()
        {
            var openFileResult = openFileDialog1.ShowDialog();
            if ( openFileResult == DialogResult.OK )
            {
                // open file and load in text field
                richTextBox1.LoadFile( openFileDialog1.FileName, RichTextBoxStreamType.RichText );
                CurrentFile = new FileInfo( openFileDialog1.FileName );
                Text = @"Word Processor - " + CurrentFile.Name;
            }
        }

        private void SaveDocument()
        {
            if ( CurrentFile != null )
            {
                if ( CurrentFile.Exists )
                {
                    richTextBox1.SaveFile( CurrentFile.FullName, RichTextBoxStreamType.RichText );
                    return;
                }
            }

            var saveFileResult = saveFileDialog1.ShowDialog();
            if ( saveFileResult == DialogResult.OK )
            {
                richTextBox1.SaveFile( saveFileDialog1.FileName, RichTextBoxStreamType.RichText );
                CurrentFile = new FileInfo( saveFileDialog1.FileName );
                Text = @"Word Processor - " + CurrentFile.Name;
            }
        }

        private void NewDocument()
        {
            var newDoc = new Form1();
            newDoc.Show();
            newDoc.Text = @"Новий документ";
        }

        private void ChangeSelectedFont( FontFamily family, float size )
        {
            var startSelection = richTextBox1.SelectionStart;
            var selectionLength = richTextBox1.SelectionLength;

            // default if don't have selection
            if ( richTextBox1.SelectionLength == 0 )
            {
                if ( family != null )
                {
                    richTextBox1.Font = new Font( family, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style );
                }

                if ( size != 0 )
                {
                    richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style );
                }
            }
            else if ( richTextBox1.SelectionLength == richTextBox1.Text.Length )
            {
                if ( family != null )
                {
                    richTextBox1.Font = new Font( family, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style );
                }

                if ( size != 0 )
                {
                    richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style );
                }
            }
            else if ( richTextBox1.SelectionLength != richTextBox1.Text.Length )
            {
                if ( family != null )
                {
                    richTextBox1.SelectionFont = new Font( family, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style );
                }

                if ( size != 0 )
                {
                    richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style );
                }
            }

            richTextBox1.SelectionStart = startSelection;
            richTextBox1.SelectionLength = selectionLength;
            richTextBox1.Focus();
        }

        private void btnFont_SelectedIndexChanged( object sender, EventArgs e )
        {
            ChangeSelectedFont( GetFontFamilyByName( btnFont.Text ), 0 );
        }

        private void btnSize_SelectedIndexChanged( object sender, EventArgs e )
        {
            ChangeSelectedFont( null, float.Parse( btnSize.Text ) );
        }

        private void btnNewDoc_Click( object sender, EventArgs e )
        {
            NewDocument();
        }

        private void btnOpenDoc_Click( object sender, EventArgs e )
        {
            OpenDocument();
        }

        private void btnSaveDoc_Click( object sender, EventArgs e )
        {
            SaveDocument();
        }

        private void richTextBox1_TextChanged( object sender, EventArgs e )
        {
            if ( Edited == false )
            {
                Edited = true;
            }
        }

        private void btnBold_Click( object sender, EventArgs e )
        {
            if ( richTextBox1.SelectionFont == null )
            {
                return;
            }

            if ( !btnBold.Checked )
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Bold );
                btnBold.Checked = tsmBold.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Bold );
                btnBold.Checked = tsmBold.Checked = false;
            }
        }

        private void btnItalic_Click( object sender, EventArgs e )
        {
            if ( richTextBox1.SelectionFont == null )
            {
                return;
            }

            if ( !btnItalic.Checked )
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Italic );
                btnItalic.Checked = tsmItalic.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Italic );
                btnItalic.Checked = tsmItalic.Checked = false;
            }
        }

        private void btnUnderline_Click( object sender, EventArgs e )
        {
            if ( richTextBox1.SelectionFont == null )
            {
                return;
            }

            if ( !btnUnderline.Checked )
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Underline );
                btnUnderline.Checked = tsmUnderline.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Underline );
                btnUnderline.Checked = tsmUnderline.Checked = false;
            }
        }

        private void btnCopy_Click( object sender, EventArgs e )
        {
            richTextBox1.Copy();
            btnPaste.Enabled = true;
        }

        private void btnPaste_Click( object sender, EventArgs e )
        {
            richTextBox1.Paste();
        }

        private void btnSearch_ButtonClick( object sender, EventArgs e )
        {
            var search = new SearchForm( richTextBox1 );
            search.Show();
        }

        private void btnReplace_ButtonClick( object sender, EventArgs e )
        {
            var replace = new ReplaceForm( richTextBox1 );
            replace.Show();
        }

        private void btnCut_Click( object sender, EventArgs e )
        {
            richTextBox1.Cut();
            btnPaste.Enabled = true;
        }

        private void btnBlack_Click( object sender, EventArgs e )
        {
            richTextBox1.SelectionColor = Color.Black;
        }

        private void btnRed_Click( object sender, EventArgs e )
        {
            richTextBox1.SelectionColor = Color.Red;
        }

        private void btnGreen_Click( object sender, EventArgs e )
        {
            richTextBox1.SelectionColor = Color.Green;
        }

        private void btnYellow_Click( object sender, EventArgs e )
        {
            richTextBox1.SelectionColor = Color.Yellow;
        }

        private void btnBlue_Click( object sender, EventArgs e )
        {
            richTextBox1.SelectionColor = Color.Blue;
        }

        private void btnWhite_Click( object sender, EventArgs e )
        {
            richTextBox1.SelectionColor = Color.White;
        }

        private void btnGray_Click( object sender, EventArgs e )
        {
            richTextBox1.SelectionColor = Color.Gray;
        }

        private void tsmPrint_Click( object sender, EventArgs e )
        {
            printDialog1.ShowDialog();
        }

        private void richTextBox1_SelectionChanged( object sender, EventArgs e )
        {
            if ( CopyFont != null )
            {
                if ( richTextBox1.SelectionFont != null )
                {
                    richTextBox1.SelectionFont = CopyFont;
                    CopyFont = null;
                }
            }

            //Check which font style we have
            FontStyle = FontStyle.Regular;
            if ( richTextBox1.SelectionFont != null )
            {
                if ( richTextBox1.SelectionFont.Bold )
                {
                    FontStyle |= FontStyle.Bold;
                }

                if ( richTextBox1.SelectionFont.Italic )
                {
                    FontStyle |= FontStyle.Italic;
                }

                if ( richTextBox1.SelectionFont.Underline )
                {
                    FontStyle |= FontStyle.Underline;
                }
            }
        }

        private void tsmCopy_Click( object sender, EventArgs e )
        {
            richTextBox1.Copy();
            btnPaste.Enabled = true;
        }

        private void tsmCut_Click( object sender, EventArgs e )
        {
            richTextBox1.Cut();
            btnPaste.Enabled = true;
        }

        private void tsmPaste_Click( object sender, EventArgs e )
        {
            richTextBox1.Paste();
        }

        private void tsmBold_Click( object sender, EventArgs e )
        {
            if ( richTextBox1.SelectionFont == null )
            {
                return;
            }

            if ( !btnBold.Checked )
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Bold );
                btnBold.Checked = tsmBold.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Bold );
                btnBold.Checked = tsmBold.Checked = false;
            }
        }

        private void tsmUnderline_Click( object sender, EventArgs e )
        {
            if ( richTextBox1.SelectionFont == null )
            {
                return;
            }

            if ( !btnUnderline.Checked )
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Underline );
                btnUnderline.Checked = tsmUnderline.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Underline );
                btnUnderline.Checked = tsmUnderline.Checked = false;
            }
        }

        private void tsmItalic_Click( object sender, EventArgs e )
        {
            if ( richTextBox1.SelectionFont == null )
            {
                return;
            }

            if ( !btnItalic.Checked )
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style | FontStyle.Italic );
                btnItalic.Checked = tsmItalic.Checked = true;
            }
            else
            {
                richTextBox1.SelectionFont = new Font( richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style & ~FontStyle.Italic );
                btnItalic.Checked = tsmItalic.Checked = false;
            }
        }

        private void tsmSearch_Click( object sender, EventArgs e )
        {
            var search = new SearchForm( richTextBox1 );
            search.Show();
        }

        private void tsmReplace_Click( object sender, EventArgs e )
        {
            var replace = new ReplaceForm( richTextBox1 );
            replace.Show();
        }

        private void tsmNewDoc_Click( object sender, EventArgs e )
        {
            NewDocument();
        }

        private void tsmOpenDoc_Click( object sender, EventArgs e )
        {
            OpenDocument();
        }

        private void tsmSave_Click( object sender, EventArgs e )
        {
            SaveDocument();
        }

        private void tsmClose_Click( object sender, EventArgs e )
        {
            Close();
        }

        #endregion
    }
}