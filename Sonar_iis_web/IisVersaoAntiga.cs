using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar_iis_web
{
    public class IisVersaoAntiga
    {
        private readonly DirectoryEntry _websiteEntry;
        internal const string IIsWebServer = "IIsWebServer";

        public IisVersaoAntiga(DirectoryEntry Server)
        {
            _websiteEntry = Server;
        }

        public static IisVersaoAntiga OpenWebsite()
        {
            // get directory service
            DirectoryEntry Services = new DirectoryEntry("IIS://localhost/LM/W3SVC");
            IEnumerator ie = Services.Children.GetEnumerator(); // ISS 6 
            DirectoryEntry Server = null;

            // find iis website
            while (ie.MoveNext())
            {
                Server = (DirectoryEntry)ie.Current;
                if (Server.SchemaClassName == IIsWebServer)
                {
                    var teste = Server.Properties["ServerComment"][0].ToString();
                }
            }

            return null;
        }
    }
}
