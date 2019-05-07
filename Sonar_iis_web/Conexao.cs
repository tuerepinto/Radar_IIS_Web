using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static Sonar_iis_web.StringFolder.Texto;

namespace Sonar_iis_web
{
    public static class Conexao
    {
        public static bool ServidorValido(string ip)
        {
            var ping = new Ping();
            var reply = ping.Send(ip);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine(string.Format(MensagemSucesso.Ip_encontrato, ip));
                return ServidorValido(true);
            }
            else
            {
                Console.WriteLine(string.Format(MensagemErro.Ip_Nao_encontrato, ip));
                return ServidorValido(false);
            }
        }

        private static bool ServidorValido(bool sucesso)
        {
            if (sucesso)
            {
                return true;
            }

            return false;
        }
    }
}
