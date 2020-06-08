using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;


namespace _01_Tasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Rede, armazenamento, tela/display - Geram tempo de espera.
        private async void btnBaixar_Click(object sender, EventArgs e)
        {
            //Quando usamos "TASKS", transformamos nosso fluxo(thread) em asyncrono,
            //ou seja, não precisa esperar que ele seja executado para continuar o programa.
            string endereco = txtBoxSite.Text;

            //Classe para fazer downloads de conteúdos da internet
            WebClient web = new WebClient();

            //Download com método "syncrono"
            //string html = web.DownloadString(endereco);

            //Download com método "asyncrono"
            string html = await web.DownloadStringTaskAsync(new Uri(endereco));

            TxtResultado.Text = html;
        }
    }
}
