using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Text_Editor
{
    public partial class SearchForm : Form
    {
        RichTextBox rtbSearch;
        int srchPos = 0;
        bool isSearched = true;

        public SearchForm(RichTextBox richbox)
        {
            rtbSearch = richbox;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RichTextBoxFinds rtbF = RichTextBoxFinds.None;
            if (checkBoxWord.Checked)
                rtbF |= RichTextBoxFinds.WholeWord;
            if (checkBoxRegistry.Checked)
                rtbF |= RichTextBoxFinds.MatchCase;
            Search(textBox1.Text, rtbF);
        }

        public void Search(string srchText, RichTextBoxFinds rtbFinds)
        {
            if (srchPos != rtbSearch.Text.Length)
                srchPos = rtbSearch.Find(srchText, srchPos, rtbSearch.Text.Length, rtbFinds);
            else
                srchPos = -1;

            if (srchPos != -1)
            {
                rtbSearch.Select(srchPos, srchText.Length);
                srchPos += srchText.Length;
            }
            else
            {
                MessageBox.Show(string.Format("Співпадінь немає: ", srchText));
                srchPos = 0;
                isSearched = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
