using System.ComponentModel;

namespace Arkanoid
{
    partial class Play
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Play));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 72F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(323, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(938, 200);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1467, 1040);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Play";
            this.Text = "Play";
            this.Resize += new System.EventHandler(this.Play_Resize);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}