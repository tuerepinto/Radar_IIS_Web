using Sonar_iis_web.Model;
using System;
using System.Collections.Generic;

namespace Sonar_iis_web.StringFolder
{
    public class Texto
    {
        public const string Nome_Aplicacao = "Radar IIS WEB";

        public struct Style
        {
            public const string QuebraLinha = "\r";
            public const string DivisorTexto = "-----------------------------------------\n";
        }

        public struct MensagemErro
        {
            public const string Servidor_Nao_Encontrado = "Não existe servidor configurando para o rastreio.";
            public const string Ip_Nao_encontrato = "Terminal Offline: {0}";
        }

        public struct MensagemSucesso
        {
            public const string Ip_encontrato = "Terminal Online: {0}";
        }

        public struct ArquivoString
        {
            public const string Nome = "Relatorio_IIS_{0}.txt";
            public const string Log = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\n";
        }
                
        public static void ExibirConsole(ServidorIis servidorIis)
        {
            Console.WriteLine(string.Format("Versão IIS: {0}\r", servidorIis.VersaoIis));
            Console.WriteLine(string.Format("Site: {0}\r", servidorIis.Site));
            Console.WriteLine(string.Format("Runtime: {0}\r", servidorIis.Runtime));
            Console.WriteLine(string.Format("Diretorio: {0}\r", servidorIis.DiretorioSiteFisico));
            Console.WriteLine(string.Format("Pool: {0}\r", servidorIis.Pool));
            Console.WriteLine(string.Format("Usuário Pool: {0}\r", servidorIis.UsuarioPool));
            Console.WriteLine(Style.DivisorTexto);
        }
    }
}
