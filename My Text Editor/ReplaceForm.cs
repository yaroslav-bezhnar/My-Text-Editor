using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class ReplaceForm : Form
    {
        RichTextBox rtbSearch;

        int srchPos = 0;
        bool isSearched = true;

        public ReplaceForm(RichTextBox richbox)
        {
            rtbSearch = richbox;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RichTextBoxFinds rtbFinds = RichTextBoxFinds.None;
            if (checkBoxWord.Checked)
                rtbFinds |= RichTextBoxFinds.WholeWord;
            if (checkBoxRegistry.Checked)
                rtbFinds |= RichTextBoxFinds.MatchCase;

            Search(textBox1.Text, rtbFinds);
        }

        public void Replace(string searchText, string replaceText, RichTextBoxFinds rtbFinds)
        {
            if (srchPos != rtbSearch.Text.Length && srchPos <= rtbSearch.Text.Length)
            {
                srchPos = rtbSearch.Find(searchText, srchPos, rtbSearch.Text.Length, rtbFinds);
            }
            else
                srchPos = -1;

            if (srchPos != -1)
            {
                rtbSearch.Select(srchPos, searchText.Length);
                //srchPos += searchText.Length;
                string SubSone = rtbSearch.Text.Substring(0, srchPos);
                string SubStwo = rtbSearch.Text.Substring(srchPos + searchText.Length);
                rtbSearch.Text = SubSone + replaceText + SubStwo;
                srchPos += searchText.Length;
            }
            else
            {
                MessageBox.Show(string.Format("Співпадінь немає: ", searchText));
                srchPos = 0;
                isSearched = false;
            }
        }

        public void Search(string zoekText, RichTextBoxFinds rtbF)
        {
            if (srchPos != rtbSearch.Text.Length)
                srchPos = rtbSearch.Find(zoekText, srchPos, rtbSearch.Text.Length, rtbF);
            else
                srchPos = -1;

            if (srchPos != -1)
            {
                rtbSearch.Select(srchPos, zoekText.Length);
                srchPos += zoekText.Length;
            }
            else
            {
                MessageBox.Show(string.Format("Співпадінь немає: ", zoekText));
                srchPos = 0;
                isSearched = false;
            }
        }

        public void ReplaceAll(string searchText, string replaceText, RichTextBoxFinds rtbFinds)
        {
            while (srchPos != -1)
            {
                if (srchPos != rtbSearch.Text.Length && srchPos <= rtbSearch.Text.Length)
                {
                    srchPos = rtbSearch.Find(searchText, srchPos, rtbSearch.Text.Length, rtbFinds);
                }
                else
                {
                    srchPos = -1;
                }
                if (srchPos != -1)
                {
                    rtbSearch.Select(srchPos, searchText.Length);
                    rtbSearch.SelectedText.Replace(rtbSearch.SelectedText, replaceText);
                    string SubSone = rtbSearch.Text.Substring(0, srchPos);
                    string SubStwo = rtbSearch.Text.Substring(srchPos + searchText.Length);
                    rtbSearch.Text = SubSone + replaceText + SubStwo;
                    srchPos += searchText.Length;
                }
                else
                {
                    isSearched = false;
                }
            }
            srchPos = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RichTextBoxFinds rtbFind = RichTextBoxFinds.None;
            if (checkBoxWord.Checked)
                rtbFind |= RichTextBoxFinds.WholeWord;
            if (checkBoxRegistry.Checked)
                rtbFind |= RichTextBoxFinds.MatchCase;

            Replace(textBox1.Text, textBox2.Text, rtbFind);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RichTextBoxFinds rtbF = RichTextBoxFinds.None;
            if (checkBoxWord.Checked)
                rtbF |= RichTextBoxFinds.WholeWord;
            if (checkBoxRegistry.Checked)
                rtbF |= RichTextBoxFinds.MatchCase;

            ReplaceAll(textBox1.Text, textBox2.Text, rtbF);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
