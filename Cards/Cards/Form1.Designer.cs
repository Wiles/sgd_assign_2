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
            this.btn_shuffle.Location = new System.Drawing.Point(267, 72);
            this.btn_shuffle.Name = "btn_shuffle";
            this.btn_shuffle.Size = new System.Drawing.Size(95, 23);
            this.btn_shuffle.TabIndex = 3;
            this.btn_shuffle.Text = "Shuffle";
            this.btn_shuffle.UseVisualStyleBackColor = true;
            this.btn_shuffle.Click += new System.EventHandler(this.btn_shuffle_Click);
            // 
            // btn_riffle
            // 
            this.btn_riffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_riffle.Location = new System.Drawing.Point(267, 102);
            this.btn_riffle.Name = "btn_riffle";
            this.btn_riffle.Size = new System.Drawing.Size(95, 23);
            this.btn_riffle.TabIndex = 4;
            this.btn_riffle.Text = "Riffle";
            this.btn_riffle.UseVisualStyleBackColor = true;
            this.btn_riffle.Click += new System.EventHandler(this.btn_riffle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 261);
            this.Controls.Add(this.btn_riffle);
            this.Controls.Add(this.btn_shuffle);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_knuth);
            this.Controls.Add(this.lb_items);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_items;
        private System.Windows.Forms.Button btn_knuth;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_shuffle;
        private System.Windows.Forms.Button btn_riffle;
    }
}

