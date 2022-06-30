
namespace UASPABD
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
            this.button2 = new System.Windows.Forms.Button();
            this.Pemesanan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(315, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 43);
            this.button2.TabIndex = 8;
            this.button2.Text = "Keluar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Pemesanan
            // 
            this.Pemesanan.Location = new System.Drawing.Point(396, 158);
            this.Pemesanan.Name = "Pemesanan";
            this.Pemesanan.Size = new System.Drawing.Size(191, 58);
            this.Pemesanan.TabIndex = 7;
            this.Pemesanan.Text = "Menu Pemesanan";
            this.Pemesanan.UseVisualStyleBackColor = true;
            this.Pemesanan.Click += new System.EventHandler(this.Pemesanan_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 59);
            this.button1.TabIndex = 6;
            this.button1.Text = "Menu Makanan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Pemesanan);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Pemesanan;
        private System.Windows.Forms.Button button1;
    }
}

