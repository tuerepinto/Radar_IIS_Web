namespace Sonar_iis_web
{
    public class Arquivo
    {
        private readonly string arquivo;
        public Arquivo(string arquivo)
        {
            this.arquivo = arquivo;
        }

        public void Escrever<T>(T conteudo)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(this.arquivo, true))
            {
                sw.WriteLine(conteudo);
                sw.Close();
            }
        }
    }
}