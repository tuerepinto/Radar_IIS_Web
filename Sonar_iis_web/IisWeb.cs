using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;
using static Sonar_iis_web.StringFolder.Texto;


namespace Sonar_iis_web
{
    public class IisWeb
    {
        public const int Versao_antiga_iis = 6;
        public async Task Relatorio()
        {
            var applicationSettings = ConfigurationManager.GetSection("ApplicationSettings") as NameValueCollection;

            if (applicationSettings.Count == 0)
            {
                Console.WriteLine(new ArgumentException(MensagemErro.Servidor_Nao_Encontrado));
                Console.ReadKey();
            }

            foreach (var item in applicationSettings.AllKeys)
            {
                var enderecoServidor = applicationSettings[item];

                if (Conexao.ServidorValido(enderecoServidor))
                {
                    Console.WriteLine(string.Format("Servidor {0} {1}", item, enderecoServidor));
                    Console.WriteLine(Style.DivisorTexto);

                    await ObterIisWebVersaoNovas(enderecoServidor);
                }

            }
        }

        public async Task ObterIisWebVersaoNovas(string servidor)
        {
            await IisVersaoNova.ObterInformacoesIis(servidor);
        }
    }
}
