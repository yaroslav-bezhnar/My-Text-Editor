using System;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class SearchForm : Form
    {
        #region Fields

        private readonly RichTextBox _rtbSearch;
        private int _searchPos;

        #endregion

        #region Constructors

        public SearchForm( RichTextBox richTextBox )
        {
            InitializeComponent();

            _rtbSearch = richTextBox;
        }

        #endregion

        #region Public Methods

        public void Search( string searchText, RichTextBoxFinds rtbFinds )
        {
            if ( _searchPos != _rtbSearch.Text.Length )
            {
                _searchPos = _rtbSearch.Find( searchText, _searchPos, _rtbSearch.Text.Length, rtbFinds );
            }
            else
            {
                _searchPos = -1;
            }

            if ( _searchPos != -1 )
            {
                _rtbSearch.Select( _searchPos, searchText.Length );
                _searchPos += searchText.Length;
            }
            else
            {
                MessageBox.Show( @"Співпадінь немає: " );
                _searchPos = 0;
            }
        }

        #endregion

        #region Private Methods

        private void button1_Click( object sender, EventArgs e )
        {
            var rtbF = RichTextBoxFinds.None;

            if ( checkBoxWord.Checked )
                rtbF |= RichTextBoxFinds.WholeWord;

            if ( checkBoxRegistry.Checked )
                rtbF |= RichTextBoxFinds.MatchCase;
            Search( textBox1.Text, rtbF );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            Close();
        }

        #endregion
    }
}