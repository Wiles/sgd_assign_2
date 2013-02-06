namespace Dice
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.nub_range = new System.Windows.Forms.NumericUpDown();
            this.btn_run = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_total = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nub_range)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.results)).BeginInit();
            this.SuspendLayout();
            // 
            // nub_range
            // 
            this.nub_range.DecimalPlaces = 2;
            this.nub_range.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nub_range.Location = new System.Drawing.Point(93, 15);
            this.nub_range.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nub_range.Name = "nub_range";
            this.nub_range.Size = new System.Drawing.Size(61, 20);
            this.nub_range.TabIndex = 0;
            this.nub_range.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(12, 12);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 2;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // results
            // 
            this.results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.results.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.results.Legends.Add(legend2);
            this.results.Location = new System.Drawing.Point(12, 42);
            this.results.Name = "results";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Min";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Actual";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Max";
            this.results.Series.Add(series4);
            this.results.Series.Add(series5);
            this.results.Series.Add(series6);
            this.results.Size = new System.Drawing.Size(664, 482);
            this.results.TabIndex = 3;
            this.results.Text = "chart1";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(160, 17);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(0, 13);
            this.lbl_total.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 536);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.results);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.nub_range);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nub_range)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.results)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nub_range;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.DataVisualization.Charting.Chart results;
        private System.Windows.Forms.Label lbl_total;
    }
}

