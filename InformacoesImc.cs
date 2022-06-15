namespace IMC
{
    public class InformacoesImc
    {
        public string Riscos { get; private set; }
        public string Recomendacao { get; private set; }
        public void AdicionaRisco(string risco)
        {
            Riscos = risco;
        }
        public void AdicionaRecomendacao(string recomendacao)
        {
            Recomendacao = recomendacao;
        }
    }
}
