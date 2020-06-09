using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace _03_TaskMulti
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> lista = new List<Task>();
            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));

            //Espera todas as tarefas terminarem para o fluxo principal prosseguir
            Task.WaitAll(lista.ToArray());

            //Espera apenas uma das tarefas terminar para o fluxo principal prosseguir
            //Task.WaitAny();

            //Não faz nenhuma pausa pra esperar as tarefas terminarem
            //Task.WhenAll();

            string[] enderecos = new string[] { "http://www.google.com.br", "http://www.uol.com.br", "http://www.globo.com" };

            //Vai criar um IEnumerable(especie de lista) com a task que vai retornar uma string
            var listaEnd = from end in enderecos select DownloadPagina(end);

            Task.WaitAll(listaEnd.ToArray());

            Console.WriteLine("Programa finalizado!");
            Console.ReadKey();
        }

        static void Metodo01()
        {
            for (int i = 0; i < 1500; i++)
            {
                Console.WriteLine("Valor: " + i + " TaskId: " + Task.CurrentId);
            }
        }

        public static async Task DownloadPagina(string end)
        {
            WebClient web = new WebClient();
            string html = await web.DownloadStringTaskAsync(end);
            Console.WriteLine("Download realizado para a página: " + end);
        }

    }
}


