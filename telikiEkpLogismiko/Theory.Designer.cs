namespace telikiEkpLogismiko
{
    partial class Theory
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
            this.final = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // final
            // 
            this.final.AutoSize = true;
            this.final.BackColor = System.Drawing.Color.Transparent;
            this.final.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.final.LinkColor = System.Drawing.Color.Violet;
            this.final.Location = new System.Drawing.Point(12, 9);
            this.final.Name = "final";
            this.final.Size = new System.Drawing.Size(162, 25);
            this.final.TabIndex = 3;
            this.final.TabStop = true;
            this.final.Text = "Take final test";
            this.final.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.final_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(190, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "ΕΠΙΛΕΞΤΕ ΜΑΘΗΜΑ";
            // 
            // Theory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::telikiEkpLogismiko.Properties.Resources.VmZHnTO_4163944480;
            this.ClientSize = new System.Drawing.Size(1110, 651);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.final);
            this.Name = "Theory";
            this.Text = "Theory";
            this.Load += new System.EventHandler(this.Theory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel final;
        private System.Windows.Forms.Label label2;
    }
}