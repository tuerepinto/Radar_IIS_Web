using Microsoft.Web.Administration;
using Sonar_iis_web.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Sonar_iis_web.StringFolder.Texto;


namespace Sonar_iis_web
{
    public static class IisVersaoNova
    {
        public static async Task ObterInformacoesIis(string servidor)
        {
            var listServidorIis = new List<ServidorIis>();

            string path = string.Empty;
            string physicalPath = string.Empty;
            string applicationPoolName = string.Empty;
            string siteName = string.Empty;
            string runtime = string.Empty;
            string userName = string.Empty;

            ServerManager serverManager = ServerManager.OpenRemote(servidor);
            SiteCollection sites = serverManager.Sites;

            foreach (Site site in sites)
            {
                //retrieve the State of the Site
                ObjectState siteState = site.State;
                siteName = site.Name;

                //Get the list of all Applications for this Site
                ApplicationCollection applications = site.Applications;
                foreach (Application application in applications)
                {
                    //get the name of the ApplicationPool
                    applicationPoolName = application.ApplicationPoolName;

                    VirtualDirectoryCollection directoriesApplication = application.VirtualDirectories;
                    foreach (VirtualDirectory directory in directoriesApplication)
                    {
                        //ConfigurationAttributeCollection attributes = directory.Attributes;
                        //foreach (ConfigurationAttribute attribute in attributes)
                        //{
                        //    //put code here to work with each attribute
                        //}

                        //ConfigurationChildElementCollection childElements = directory.ChildElements;
                        //foreach (ConfigurationElement element in childElements)
                        //{
                        //    //put code here to work with each ConfigurationElement
                        //}

                        //get the directory.Path
                        path = directory.Path;

                        //get the physical path
                        physicalPath = directory.PhysicalPath;
                    }
                }

                ApplicationPoolCollection applicationPools = serverManager.ApplicationPools;
                foreach (ApplicationPool pool in applicationPools)
                {
                    //get the AutoStart boolean value
                    bool autoStart = pool.AutoStart;

                    //get the name of the ManagedRuntimeVersion
                    runtime = pool.ManagedRuntimeVersion;

                    //get the name of the ApplicationPool
                    string appPoolName = pool.Name;

                    //get the identity type
                    ProcessModelIdentityType identityType = pool.ProcessModel.IdentityType;

                    //get the username for the identity under which the pool runs
                    userName = pool.ProcessModel.UserName;

                    //get the password for the identity under which the pool runs
                    string password = pool.ProcessModel.Password;
                }

                listServidorIis.Add(new ServidorIis
                {
                    Site = siteName,
                    VersaoIis = string.Empty,
                    Pool = applicationPoolName,
                    SiteState = siteState.ToString(),
                    DiretorioSiteVirtual = path,
                    DiretorioSiteFisico = physicalPath,
                    Runtime = runtime,
                    UsuarioPool = userName
                });

            }

            for (int i = 0; i < listServidorIis.Count; i++)
            {
                ExibirConsole(listServidorIis[i]);
                SalvarLog(listServidorIis[i], servidor);
            }
        }

        private static void SalvarLog(ServidorIis servidorIis, string servidor)
        {
            var dateParse = DateTime.Now.ToShortDateString();
            var arquivo = string.Format(ArquivoString.Nome, Regex.Replace(dateParse, "[/]", ""));
            var salvar = new Arquivo(@"C:\" + arquivo);

            var usuarioPool = string.IsNullOrEmpty(servidorIis.UsuarioPool) ? "Usuário não configurado" : servidorIis.UsuarioPool;
            var versaoISS = string.IsNullOrEmpty(servidorIis.VersaoIis) ? "Não foi possÍvel obter a vesão do IIS" : servidorIis.VersaoIis;

            salvar.Escrever(string.Format(ArquivoString.Log,
                DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
                Environment.MachineName,
                servidor,
                versaoISS,
                servidorIis.Site,
                servidorIis.SiteState,
                servidorIis.Runtime,
                servidorIis.Pool,
                usuarioPool,
                servidorIis.DiretorioSiteFisico,
                servidorIis.DiretorioSiteVirtual));
        }
    }
}
