using System;
using System.Threading.Tasks;
using static Sonar_iis_web.StringFolder.Texto;

namespace Sonar_iis_web
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Titulo da aplicação
            Console.WriteLine(string.Format("Console {0} {1}", Nome_Aplicacao, Style.QuebraLinha));
            Console.WriteLine(Style.DivisorTexto);

            //execução do processamento
            try
            {
                MainAsync(args).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(new ArgumentNullException(ex.Message));                
            }

            //Aguardando o processamento
            Console.ReadKey();
        }

        public static async Task MainAsync(string[] args)
        {
            await new IisWeb().Relatorio();
        }
    }
}
