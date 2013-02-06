//File:     Form1.cs
//Name:     Samuel Lewis (5821103)
//Date:     02/01/2013
//Class:    Simulation and Game Development
//Ass:      2
//
//Desc:     Main logic for card simulation 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cards
{
    /// <summary>
    /// Main form for running the card simulator
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// set of unshuffled cards
        /// </summary>
        private readonly List<int> _unshuffled = Enumerable.Range(0, 52).ToList();
        /// <summary>
        /// list of cards to be shuffled
        /// </summary>
        private List<int> _cards = new List<int>();
        /// <summary>
        /// RFactor based on knuth(Fisher Yates) shuffle
        /// </summary>
        private readonly int _knuthRFactor;

        /// <summary>
        /// Number of times knuth shuffle has been used on the current deck
        /// </summary>
        private int _knuth;
        /// <summary>
        /// Number of times overhand shuffle has been used on the current deck
        /// </summary>
        private int _shuffle;
        /// <summary>
        /// Number of times riffle shuffle has been used on the current deck
        /// </summary>
        private int _riffle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
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

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btn_knuth control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btn_knuth_Click(object sender, EventArgs e)
        {
            _cards.Knuth();
            lb_rfactor.Text = String.Format("{0:0.00}", RFactor(_unshuffled, _cards) / (double)_knuthRFactor);
            _knuth += 1;
            lbl_knuth.Text = String.Format("{0}", _knuth);
            lbl_total.Text = String.Format("{0}", _knuth + _riffle + _shuffle);
            UpdateListBox();
        }

        /// <summary>
        /// Handles the Click event of the btn_reset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        /// <summary>
        /// Resets this instance. Returning the deck and counts to their default state
        /// </summary>
        private void Reset()
        {
            _cards.Clear();
            _cards = _unshuffled.Select(i => i).ToList();
            lb_rfactor.Text = String.Format("{0:0.00}", RFactor(_unshuffled, _cards) / (double)_knuthRFactor);
            _knuth = 0;
            _shuffle = 0;
            _riffle = 0;
            lbl_knuth.Text = String.Format("{0}", 0);
            lbl_shuffle.Text = String.Format("{0}", 0);
            lbl_riffle.Text = String.Format("{0}", 0);
            lbl_total.Text = String.Format("{0}", _knuth + _riffle + _shuffle);
            UpdateListBox();
        }

        /// <summary>
        /// Updates the list box to display the deck of cards in their current order
        /// </summary>
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

        /// <summary>
        /// Handles the Click event of the btn_shuffle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btn_shuffle_Click(object sender, EventArgs e)
        {
            _cards.OverhandShuffle();
            lb_rfactor.Text = String.Format("{0:0.00}", RFactor(_unshuffled, _cards) / (double)_knuthRFactor);
            _shuffle += 1;
            lbl_shuffle.Text = String.Format("{0}", _shuffle);
            lbl_total.Text = String.Format("{0}", _knuth + _riffle + _shuffle);
            UpdateListBox();
        }

        /// <summary>
        /// Handles the Click event of the btn_riffle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btn_riffle_Click(object sender, EventArgs e)
        {
            _cards.Riffle();
            lb_rfactor.Text = String.Format("{0:0.00}", RFactor(_unshuffled, _cards) / (double)_knuthRFactor);
            _riffle += 1;
            lbl_riffle.Text = String.Format("{0}", _riffle);
            lbl_total.Text = String.Format("{0}", _knuth + _riffle + _shuffle);
            UpdateListBox();
        }

        /// <summary>
        /// Calcualtes the full rfactor for the deck provided.
        /// </summary>
        /// <param name="original">The original deck.</param>
        /// <param name="shuffled">The shuffled deck.</param>
        /// <returns></returns>
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
