namespace Cards
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
            this.lb_items = new System.Windows.Forms.ListBox();
            this.btn_knuth = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_shuffle = new System.Windows.Forms.Button();
            this.btn_riffle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_rfactor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_knuth = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_shuffle = new System.Windows.Forms.Label();
            this.lbl_riffle = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_items
            // 
            this.lb_items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_items.FormattingEnabled = true;
            this.lb_items.Location = new System.Drawing.Point(13, 13);
            this.lb_items.Name = "lb_items";
            this.lb_items.Size = new System.Drawing.Size(247, 238);
            this.lb_items.TabIndex = 0;
            this.lb_items.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_knuth
            // 
            this.btn_knuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_knuth.Location = new System.Drawing.Point(266, 42);
            this.btn_knuth.Name = "btn_knuth";
            this.btn_knuth.Size = new System.Drawing.Size(96, 23);
            this.btn_knuth.TabIndex = 1;
            this.btn_knuth.Text = "Knuth";
            this.btn_knuth.UseVisualStyleBackColor = true;
            this.btn_knuth.Click += new System.EventHandler(this.btn_knuth_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reset.Location = new System.Drawing.Point(267, 13);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(95, 23);
            this.btn_reset.TabIndex = 2;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_shuffle
            // 
            this.btn_shuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_shuffle.Location = new System.Drawing.Point(266, 71);
            this.btn_shuffle.Name = "btn_shuffle";
            this.btn_shuffle.Size = new System.Drawing.Size(96, 23);
            this.btn_shuffle.TabIndex = 3;
            this.btn_shuffle.Text = "Shuffle";
            this.btn_shuffle.UseVisualStyleBackColor = true;
            this.btn_shuffle.Click += new System.EventHandler(this.btn_shuffle_Click);
            // 
            // btn_riffle
            // 
            this.btn_riffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_riffle.Location = new System.Drawing.Point(266, 100);
            this.btn_riffle.Name = "btn_riffle";
            this.btn_riffle.Size = new System.Drawing.Size(96, 23);
            this.btn_riffle.TabIndex = 4;
            this.btn_riffle.Text = "Riffle";
            this.btn_riffle.UseVisualStyleBackColor = true;
            this.btn_riffle.Click += new System.EventHandler(this.btn_riffle_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "RFactor:";
            // 
            // lb_rfactor
            // 
            this.lb_rfactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_rfactor.AutoSize = true;
            this.lb_rfactor.Location = new System.Drawing.Point(320, 126);
            this.lb_rfactor.Name = "lb_rfactor";
            this.lb_rfactor.Size = new System.Drawing.Size(22, 13);
            this.lb_rfactor.TabIndex = 6;
            this.lb_rfactor.Text = "0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Knuth:";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 261);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Shuffle:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Riffle:";
            // 
            // lbl_knuth
            // 
            this.lbl_knuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_knuth.AutoSize = true;
            this.lbl_knuth.Location = new System.Drawing.Point(320, 139);
            this.lbl_knuth.Name = "lbl_knuth";
            this.lbl_knuth.Size = new System.Drawing.Size(13, 13);
            this.lbl_knuth.TabIndex = 11;
            this.lbl_knuth.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total:";
            // 
            // lbl_shuffle
            // 
            this.lbl_shuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_shuffle.AutoSize = true;
            this.lbl_shuffle.Location = new System.Drawing.Point(320, 152);
            this.lbl_shuffle.Name = "lbl_shuffle";
            this.lbl_shuffle.Size = new System.Drawing.Size(13, 13);
            this.lbl_shuffle.TabIndex = 13;
            this.lbl_shuffle.Text = "0";
            // 
            // lbl_riffle
            // 
            this.lbl_riffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_riffle.AutoSize = true;
            this.lbl_riffle.Location = new System.Drawing.Point(320, 165);
            this.lbl_riffle.Name = "lbl_riffle";
            this.lbl_riffle.Size = new System.Drawing.Size(13, 13);
            this.lbl_riffle.TabIndex = 14;
            this.lbl_riffle.Text = "0";
            // 
            // lbl_total
            // 
            this.lbl_total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(320, 178);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(13, 13);
            this.lbl_total.TabIndex = 15;
            this.lbl_total.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 261);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.lbl_riffle);
            this.Controls.Add(this.lbl_shuffle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_knuth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_rfactor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_riffle);
            this.Controls.Add(this.btn_shuffle);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_knuth);
            this.Controls.Add(this.lb_items);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_items;
        private System.Windows.Forms.Button btn_knuth;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_shuffle;
        private System.Windows.Forms.Button btn_riffle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_rfactor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_knuth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_shuffle;
        private System.Windows.Forms.Label lbl_riffle;
        private System.Windows.Forms.Label lbl_total;
    }
}

