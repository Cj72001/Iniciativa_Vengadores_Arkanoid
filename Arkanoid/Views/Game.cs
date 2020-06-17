using System;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Model;
using Arkanoid.Views;
using Menu = Arkanoid.Views.Menu;

namespace Arkanoid
{
    public partial class Game : Form
    {
        private ArkanoidControl ac;

        public Game()
        {
            //Propiedad del form Game
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Image.FromFile("../../Resources/fondo1.jpg");
        }
        
        private void Game_Load(object sender, EventArgs e)
        {
            //Instanciando ArkanoidControl
            ac = null;
            ac = new ArkanoidControl();
            ac.Dock = DockStyle.Fill;
            ac.Width = Width;
            ac.Height = Height;
            //Metodo GameEnded que vuelve al menu al terminar el juego
            ac.GameEnded = () =>
            {
                // ac = null;
                // ac = new ArkanoidControl();
                // ac.Hide();
                // MessageBox.Show("PERDISTE");
                // tableLayoutPanel1.Show();
                MessageBox.Show("PERDISTE");
                var menuForm = new Menu();
                menuForm.Show();
                this.Close();
            };
            
            //Metodo GameWon que vuelve al menu al ganar la partida
            ac.GameWon = () =>{
                // ac = null;
                // ac = new ArkanoidControl();
                // ac.Hide();
                // MessageBox.Show("PERDISTE");
                // tableLayoutPanel1.Show();
                MessageBox.Show("GANASTE LA PARTIDA");
                var menuForm = new Menu();
                menuForm.Show();
                this.Close();
            };
            
        }

        //Propiedades de botones:
        private void BtnPlay_MouseEnter(object sender, EventArgs e)
        {
            BtnPlay.BackColor = Color.Red; 
        }

        private void BtnPlay_MouseLeave(object sender, EventArgs e)
        {
            BtnPlay.BackColor = Color.Transparent;
        }
        
        private void BtnBack_MouseEnter(object sender, EventArgs e)
        {
            BtnBack.BackColor = Color.Red;
        }

        private void BtnBack_MouseLeave(object sender, EventArgs e)
        {
            BtnBack.BackColor = Color.Transparent;
        }


        private void BtnPlay_Click(object sender, EventArgs e)
        {

            try
            {
                string nombre = TxtName.Text;
                var consultar = DBConnetion.RealizarConsulta($"SELECT * FROM USERS " +
                                                             $"where name = '{nombre}'");
                
                string agregar = $"INSERT into USERS(name) VALUES('{nombre}')";
                
                if (TxtName.Text.Equals(""))
                {
                    MessageBox.Show("Debe ingresar un nombre de usuario");
                }
                else
                {
                    if (consultar.Rows.Count == 1)
                    {
                        tableLayoutPanel1.Hide();
                        this.Text = "Arkanoid";
                        Controls.Add(ac);   
                    }
                    else
                    {
                        //Cambiando el control del tableLayout por ArkanoidControl
                        DBConnetion.RealizarAccion(agregar);
                        tableLayoutPanel1.Hide();
                        this.Text = "Arkanoid";
                        Controls.Add(ac);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                var menuForm = new Menu();
                menuForm.Show();
                // menuForm.Dock = DockStyle.Fill;
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message); throw;
            }
        }
    }
}