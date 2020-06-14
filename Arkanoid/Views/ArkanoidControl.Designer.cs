﻿using System.ComponentModel;

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
    this.pictureBox1 = new System.Windows.Forms.PictureBox();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
    this.SuspendLayout();
    // 
    // pictureBox1
    // 
    this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
    this.pictureBox1.Location = new System.Drawing.Point(54, 308);
    this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
    this.pictureBox1.Name = "pictureBox1";
    this.pictureBox1.Size = new System.Drawing.Size(250, 33);
    this.pictureBox1.TabIndex = 0;
    this.pictureBox1.TabStop = false;
    // 
    // timer1
    // 
    this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
    // 
    // ArkanoidControl
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    this.BackColor = System.Drawing.Color.Transparent;
    this.Controls.Add(this.pictureBox1);
    this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
    this.Name = "ArkanoidControl";
    this.Size = new System.Drawing.Size(1168, 642);
    this.Load += new System.EventHandler(this.Game_Load);
    this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
    this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_MouseMove);
    this.Resize += new System.EventHandler(this.Game_Resize);
    ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
    this.ResumeLayout(false);
}

private System.Windows.Forms.PictureBox pictureBox1;
private System.Windows.Forms.Timer timer1;

#endregion
    }
}