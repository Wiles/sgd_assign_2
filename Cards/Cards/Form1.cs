using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cards;

namespace Cards
{
    public partial class Form1 : Form
    {
        private List<int> cards = new List<int>(); 
        public Form1()
        {
            InitializeComponent();
            Reset();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_knuth_Click(object sender, EventArgs e)
        {
            cards.Knuth();
            UpdateListBox();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            cards.Clear();
            foreach (var i in Enumerable.Range(1, 52))
            {
                cards.Add(i);
            }
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            lb_items.BeginUpdate();
            lb_items.Items.Clear();
            foreach (var i in cards)
            {
                lb_items.Items.Add(i);
            }
            lb_items.EndUpdate();
            
        }

        private void btn_shuffle_Click(object sender, EventArgs e)
        {
            cards.OverhandShuffle();
            UpdateListBox();

        }

        private void btn_riffle_Click(object sender, EventArgs e)
        {

            cards.Riffle();
            UpdateListBox();
        }
    }
}
