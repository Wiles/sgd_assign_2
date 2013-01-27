using System;
using System.Linq;
using System.Windows.Forms;

namespace Dice
{
    public partial class Form1 : Form
    {
        private static readonly double[] probabilites = new double[]{ 0, 0, 2.75, 5.56, 8.33, 11.11, 13.89, 16.67, 13.89, 11.11, 8.33, 5.56, 2.75 };

        private double[] actual;

        private readonly Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            int rolls = 0;
            actual = new double[13];

            double range = (double)nub_range.Value;

            while (true)
            {
                rolls += 1;
                int roll = rand.Next(1, 7) + rand.Next(1, 7);
                actual[roll]++;
                bool match = true;
                foreach (var n in Enumerable.Range(0, 12))
                {
                    double percent = Math.Abs(actual[n]/rolls*100 - probabilites[n]);
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
                if (probabilites[r] == 0.0) continue;
                double min = probabilites[r] - range;
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
                if (probabilites[r] == 0.0) continue;
                results.Series["Actual"].Points.AddXY(r, actual[r]);
            }

            foreach (var r in Enumerable.Range(0,13))
            {
                if (probabilites[r] == 0.0) continue;
                results.Series["Max"].Points.AddXY(r, rolls * (probabilites[r] + range) / 100);
            }
            lbl_total.Text = "Total Rolls: " + rolls;
        }
    }
}
