//File:     Form1.cs
//Name:     Samuel Lewis (5821103)
//Date:     02/01/2013
//Class:    Simulation and Game Development
//Ass:      2
//
//Desc:     Main logic for dice simulation 
using System;
using System.Linq;
using System.Windows.Forms;

namespace Dice
{
    /// <summary>
    /// Dice simulation main form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The normal probability for two sided dice. 0 and 1 are impossible but are included to make indexing easier
        /// </summary>
        private static readonly double[] Probabilites = new[]{ 0.0, 0.0, 2.75, 5.56, 8.33, 11.11, 13.89, 16.67, 13.89, 11.11, 8.33, 5.56, 2.75 };

        /// <summary>
        /// The actual results of the dice rolls
        /// </summary>
        private double[] _actual;

        /// <summary>
        /// The rand
        /// </summary>
        private readonly Random _rand = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btn_run control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btn_run_Click(object sender, EventArgs e)
        {
            int rolls = 0;
            _actual = new double[13];

            double range = (double)nub_range.Value;

            while (true)
            {
                rolls += 1;
                var roll = _rand.Next(1, 7) + _rand.Next(1, 7);
                _actual[roll]++;
                var match = true;
                foreach (var n in Enumerable.Range(0, 12))
                {
                    double percent = Math.Abs(_actual[n]/rolls*100 - Probabilites[n]);
                    if (!(percent <= range))
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    break;
                }

            }

            results.Series["Min"].Points.Clear();
            results.Series["Actual"].Points.Clear();
            results.Series["Max"].Points.Clear();

            foreach (var r in Enumerable.Range(0, 13))
            {
                if (Probabilites[r] == 0.0) continue;
                double min = Probabilites[r] - range;
                if (min < 0)
                {
                    results.Series["Min"].Points.AddXY(r, 0);
                }
                else
                {
                    results.Series["Min"].Points.AddXY(r, rolls * (min) / 100);
                }
            }

            foreach (var r in Enumerable.Range(0, 13))
            {
                if (Probabilites[r] == 0.0) continue;
                results.Series["Actual"].Points.AddXY(r, _actual[r]);
            }

            foreach (var r in Enumerable.Range(0,13))
            {
                if (Probabilites[r] == 0.0) continue;
                results.Series["Max"].Points.AddXY(r, rolls * (Probabilites[r] + range) / 100);
            }
            lbl_total.Text = @"Total Rolls: " + rolls;
        }
    }
}
