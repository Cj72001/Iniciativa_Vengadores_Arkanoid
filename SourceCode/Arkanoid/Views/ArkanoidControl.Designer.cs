using System.ComponentModel;

namespace Arkanoid.Views
{
    partial class ArkanoidControl
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
    this.components = new System.ComponentModel.Container();
    this.playerPb = new System.Windows.Forms.PictureBox();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    ((System.ComponentModel.ISupportInitialize) (this.playerPb)).BeginInit();
    this.SuspendLayout();
    // 
    // playerPb
    // 
    this.playerPb.BackColor = System.Drawing.Color.Transparent;
    this.playerPb.Location = new System.Drawing.Point(54, 308);
    this.playerPb.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
    this.playerPb.Name = "playerPb";
    this.playerPb.Size = new System.Drawing.Size(250, 33);
    this.playerPb.TabIndex = 0;
    this.playerPb.TabStop = false;
    // 
    // timer1
    // 
    this.timer1.Interval = 60;
    this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
    // 
    // ArkanoidControl
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    this.BackColor = System.Drawing.Color.Transparent;
    this.Controls.Add(this.playerPb);
    this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
    this.Name = "ArkanoidControl";
    this.Size = new System.Drawing.Size(1168, 641);
    this.Load += new System.EventHandler(this.ArkanoidControl_Load);
    this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArkanoidControl_KeyDown);
    this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_MouseMove);
    ((System.ComponentModel.ISupportInitialize) (this.playerPb)).EndInit();
    this.ResumeLayout(false);
}

private System.Windows.Forms.PictureBox playerPb;
private System.Windows.Forms.Timer timer1;

#endregion
    }
}