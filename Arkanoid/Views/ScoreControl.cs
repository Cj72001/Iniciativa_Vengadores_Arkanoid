using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Arkanoid.Controllers;

namespace Arkanoid.Views
{
    public partial class ScoreControl : UserControl
    {
        private Menu menu;
        public delegate void OnPanel();
        public OnPanel RemoveScoreControl;
            
        public ScoreControl()
        {
            InitializeComponent();
        }

        private void ScoreControl_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            
            List<string> headers = new List<string>();
            DataTable scores;
            scores = ScoreController.GetTopTen(ref headers);

            tlpScores.AutoSize = true;
            tlpScores.ColumnStyles.Clear();
            tlpScores.ColumnCount = headers.Count;
            for (int x = 0; x < tlpScores.ColumnCount; x++)
            {
                tlpScores.ColumnStyles.Add(new ColumnStyle() { Width = 50, SizeType = SizeType.Percent });
            }
            tlpScores.RowStyles.Clear();
            tlpScores.RowCount = scores.Rows.Count + 2;
            for (int x = 0; x < tlpScores.RowCount; x++)
            {
                tlpScores.RowStyles.Add(new RowStyle() { Height = 50, SizeType = SizeType.Percent });
            }

            int lo = 0;
            foreach (string h in headers)
            {
                Label l = new Label();
                l.Text = h;
                l.ForeColor = Color.White;
                l.Dock = DockStyle.Fill;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Font = new Font("Showcard Gothic", 18);
                tlpScores.Controls.Add(l, lo, 0);
                lo++;
            }

            for (int x = 1; x < tlpScores.RowCount - 1; x++)
            {
                for (int y = 0; y < scores.Columns.Count; y++)
                {
                    Label l = new Label();
                    l.Text = scores.Rows[x - 1][y].ToString();
                    l.ForeColor = Color.White;
                    l.Dock = DockStyle.Fill;
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.Font = new Font("Showcard Gothic", 16);
                    tlpScores.Controls.Add(l, y, x);
                }

            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            RemoveScoreControl?.Invoke();
        }

        //Propiedades de botones:
        private void button1_MouseEnter(object sender, EventArgs e) { button1.BackColor = Color.Red; }

        private void button1_MouseLeave(object sender, EventArgs e) { button1.BackColor = Color.Transparent; }
    }
}
