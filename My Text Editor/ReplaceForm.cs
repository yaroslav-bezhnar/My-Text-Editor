using System;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class ReplaceForm : Form
    {
        #region Fields

        private readonly RichTextBox _rtbSearch;

        private int _searchPos;

        #endregion

        #region Constructors

        public ReplaceForm( RichTextBox richTextBox )
        {
            InitializeComponent();

            _rtbSearch = richTextBox;
        }

        #endregion

        #region Public Methods

        public void Replace( string searchText, string replaceText, RichTextBoxFinds rtbFinds )
        {
            if ( _searchPos != _rtbSearch.Text.Length && _searchPos <= _rtbSearch.Text.Length )
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

                var subStrOne = _rtbSearch.Text.Substring( 0, _searchPos );
                var subStrTwo = _rtbSearch.Text.Substring( _searchPos + searchText.Length );

                _rtbSearch.Text = subStrOne + replaceText + subStrTwo;
                _searchPos += searchText.Length;
            }
            else
            {
                MessageBox.Show( @"Співпадінь немає: " );
                _searchPos = 0;
            }
        }

        public void Search( string text, RichTextBoxFinds rtbFinds )
        {
            if ( _searchPos != _rtbSearch.Text.Length )
            {
                _searchPos = _rtbSearch.Find( text, _searchPos, _rtbSearch.Text.Length, rtbFinds );
            }
            else
            {
                _searchPos = -1;
            }

            if ( _searchPos != -1 )
            {
                _rtbSearch.Select( _searchPos, text.Length );
                _searchPos += text.Length;
            }
            else
            {
                MessageBox.Show( @"Співпадінь немає: " );
                _searchPos = 0;
            }
        }

        public void ReplaceAll( string searchText, string replaceText, RichTextBoxFinds rtbFinds )
        {
            while ( _searchPos != -1 )
            {
                if ( _searchPos != _rtbSearch.Text.Length && _searchPos <= _rtbSearch.Text.Length )
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
                    _rtbSearch.SelectedText.Replace( _rtbSearch.SelectedText, replaceText );

                    var subStrOne = _rtbSearch.Text.Substring( 0, _searchPos );
                    var subStrTwo = _rtbSearch.Text.Substring( _searchPos + searchText.Length );

                    _rtbSearch.Text = subStrOne + replaceText + subStrTwo;
                    _searchPos += searchText.Length;
                }
            }

            _searchPos = 0;
        }

        #endregion

        #region Private Methods

        private void button1_Click( object sender, EventArgs e )
        {
            var rtbFinds = RichTextBoxFinds.None;

            if ( checkBoxWord.Checked )
                rtbFinds |= RichTextBoxFinds.WholeWord;

            if ( checkBoxRegistry.Checked )
                rtbFinds |= RichTextBoxFinds.MatchCase;

            Search( textBox1.Text, rtbFinds );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            var rtbFind = RichTextBoxFinds.None;

            if ( checkBoxWord.Checked )
                rtbFind |= RichTextBoxFinds.WholeWord;

            if ( checkBoxRegistry.Checked )
                rtbFind |= RichTextBoxFinds.MatchCase;

            Replace( textBox1.Text, textBox2.Text, rtbFind );
        }

        private void button3_Click( object sender, EventArgs e )
        {
            var rtbF = RichTextBoxFinds.None;

            if ( checkBoxWord.Checked )
                rtbF |= RichTextBoxFinds.WholeWord;

            if ( checkBoxRegistry.Checked )
                rtbF |= RichTextBoxFinds.MatchCase;

            ReplaceAll( textBox1.Text, textBox2.Text, rtbF );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            Close();
        }

        #endregion
    }
}