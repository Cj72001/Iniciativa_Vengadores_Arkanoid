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
        //Declaracion de variable tipo ArkanoidControl
        private ArkanoidControl ac;
        
        //Declaracion del delegate para pasar el nombre desde este Form al ArkanoidControl
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
                Dispose();
            };
            
            //Metodo GameWon que vuelve al menu al ganar la partida y guarda los datos del ganador
            ac.GameWon = () =>
            {
                var id = DBConnetion.RealizarConsulta($"select id from users where name='{TxtName.Text}'").Rows[0][0].
                    ToString();
                var maximo = DBConnetion.RealizarConsulta($"select attempt from attempts" +
                                                          $" where id_user = '{Convert.ToInt32(id)}' ORDER BY attempt DESC FETCH FIRST 1 ROWS ONLY");
                
                int val;
                
                if (maximo.Rows.Count == 0) val = 1;
                else val = Convert.ToInt32(maximo.Rows[0][0].ToString()) + 1;
                
                DBConnetion.RealizarAccion($"INSERT into ATTEMPTS(id_user,attempt,score) VALUES('{Convert.ToInt32(id)}', {val},{GameData.score})");
                MessageBox.Show("GANASTE LA PARTIDA");
                var menuForm = new Menu();
                menuForm.Show();
                Dispose();
            };
        }

        //Propiedades de botones:
        private void BtnPlay_MouseEnter(object sender, EventArgs e) { BtnPlay.BackColor = Color.Red; }

        private void BtnPlay_MouseLeave(object sender, EventArgs e) { BtnPlay.BackColor = Color.Transparent; }
        
        private void BtnBack_MouseEnter(object sender, EventArgs e) { BtnBack.BackColor = Color.Red; }

        private void BtnBack_MouseLeave(object sender, EventArgs e) { BtnBack.BackColor = Color.Transparent; }
        
        
        //Evento el cual se encarga de cargar el ArkanoidControl y de cominar el nombre entre 
        //este Form y el ArkanoidContro
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                gn?.Invoke(TxtName.Text);
                
                string nombre = TxtName.Text;
                var consultar = DBConnetion.RealizarConsulta($"SELECT * FROM USERS " +
                                                             $"where name = '{nombre}'");

                string agregar = $"INSERT into USERS(name) VALUES('{nombre}')";
                
                gn = nick =>{
                    if (TxtName.Text.Equals("")) MessageBox.Show("Debe ingresar un nombre de usuario");
                    
                    else
                    {
                        if (consultar.Rows.Count == 1)
                        {
                            MessageBox.Show($"Bienvenido de nuevo {nick}","Game");
                            tableLayoutPanel1.Hide();
                            Text = "Arkanoid";
                        }
                        else
                        {
                            //Agregando User a DB
                            DBConnetion.RealizarAccion(agregar);
                            MessageBox.Show($"Gracias por registrarte {nick} \n Presiona OK para comenzar a jugar");
                            //Cambiando el control del tableLayout por ArkanoidControl
                            tableLayoutPanel1.Hide();
                            Text = "Arkanoid";
                        }
                    }
                };
                Controls.Add(ac);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        //evento que regresa al menu principal estando en el Game Form
        private void BtnBack_Click(object sender, EventArgs e)
        {
            var menuForm = new Menu();
                menuForm.Show();
                Dispose();
        }
    }
}