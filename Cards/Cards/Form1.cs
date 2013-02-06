using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cards
{
    public partial class Form1 : Form
    {
        private readonly List<int> _unshuffled = Enumerable.Range(0, 52).ToList();
        private List<int> _cards = new List<int>();
        private readonly int _knuthRFactor;
        public Form1()
        {
            InitializeComponent();
            Reset();

            var knuth = 0;

            for (var i = 0; i < 10000; ++i)
            {
                _cards.Knuth();
                knuth += RFactor(_unshuffled, _cards);
            }
            _knuthRFactor = knuth/10000;
            Reset();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_knuth_Click(object sender, EventArgs e)
        {
            _cards.Knuth();
            lb_rfactor.Text = String.Format("{0:0.00}", RFactor(_unshuffled, _cards) / (double)_knuthRFactor);
            UpdateListBox();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            _cards.Clear();
            _cards = _unshuffled.Select(i => i).ToList();
            lb_rfactor.Text = String.Format("{0:0.00}", RFactor(_unshuffled, _cards) / (double)_knuthRFactor);
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            lb_items.BeginUpdate();
            lb_items.Items.Clear();
            foreach (var i in _cards)
            {
                lb_items.Items.Add(i + 1);
            }
            lb_items.EndUpdate();
            
        }

        private void btn_shuffle_Click(object sender, EventArgs e)
        {
            _cards.OverhandShuffle();
            lb_rfactor.Text = String.Format("{0:0.00}", RFactor(_unshuffled, _cards) / (double)_knuthRFactor);
            UpdateListBox();
        }

        private void btn_riffle_Click(object sender, EventArgs e)
        {
            _cards.Riffle();
            lb_rfactor.Text = String.Format("{0:0.00}", RFactor(_unshuffled, _cards) / (double)_knuthRFactor);
            UpdateListBox();
        }

        private int RFactor(IList<int> original, IList<int> shuffled)
        {
            var rfactor = 0;
            for (int i = 0; i < original.Count; ++i)
            {
                var origin = shuffled.IndexOf(original[i]);
                var next = shuffled.IndexOf(original[(i + 1)%52]);
                var diff = Math.Abs(origin - next);
                if (diff > original.Count/2)
                {
                    diff = original.Count - diff;
                }
                rfactor += diff;
            }
            return rfactor - 52;
        }
    }
}
