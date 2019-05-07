using System.Collections.Generic;

namespace Sonar_iis_web.Model
{
    public class ServidorIis
    {
        public string Name { get; set; }
        public string SiteState { get; set; }
        public string VersaoIis { get; set; }
        public string Site { get; set; }
        public string Pool { get; set; }
        public string UsuarioPool { get; set; }
        public string DiretorioSiteFisico { get; set; }
        public string DiretorioSiteVirtual { get; set; }
        public string Runtime { get; set; }
    }
}
