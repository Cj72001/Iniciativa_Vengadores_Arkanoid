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
        public delegate void GetNickName(string text);
        public GetNickName gn;


        public Game()
        {
            //Propiedad del form Game
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Image.FromFile("../../Resources/fondo1.jpg");
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
                MessageBox.Show("PERDISTE");
                
                var menuForm = new Menu();
                menuForm.Show();
                this.Close();
            };
            
            //Metodo GameWon que vuelve al menu al ganar la partida
            ac.GameWon = () =>{
                
                MessageBox.Show("GANASTE LA PARTIDA");
                var menuForm = new Menu();
                menuForm.Show();
                this.Close();
            };
        }

        //Propiedades de botones:
        private void BtnPlay_MouseEnter(object sender, EventArgs e) { BtnPlay.BackColor = Color.Red; }

        private void BtnPlay_MouseLeave(object sender, EventArgs e) { BtnPlay.BackColor = Color.Transparent; }
        
        private void BtnBack_MouseEnter(object sender, EventArgs e) { BtnBack.BackColor = Color.Red; }

        private void BtnBack_MouseLeave(object sender, EventArgs e) { BtnBack.BackColor = Color.Transparent; }


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
                        Console.WriteLine("Bienvenido de nuevo "+ TxtName.Text);
                        tableLayoutPanel1.Hide();
                        this.Text = "Arkanoid";
                        Controls.Add(ac);   
                    }
                    else
                    {
                        //Agregando User a DB
                        DBConnetion.RealizarAccion(agregar);
                        
                        //Cambiando el control del tableLayout por ArkanoidControl
                        tableLayoutPanel1.Hide();
                        this.Text = "Arkanoid";
                        Controls.Add(ac);
                        
                        //Metodo para agregar UserName y Score
                        ac.user = () =>
                        {
                            // new User(TxtName.Text, GameData.score);
                            DBConnetion.RealizarAccion($"INSERT into USERS(name, score) VALUES('{TxtName.Text}', '{GameData.score}')");
                        };
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var menuForm = new Menu();
                menuForm.Show();
                this.Close();
        }
        
    }
}