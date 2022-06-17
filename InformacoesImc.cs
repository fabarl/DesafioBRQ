namespace IMC
{
    /// <summary>
    /// Clase InformacoesImc
    /// Atributos Riscos e Recomendacao
    /// Metodos AdicionaRisco e AdicionaRecomendacao
    /// está classe é responsavel por armazenar as informações sobre o resultado do IMC
    /// </summary>
    public class InformacoesImc
    {
        public string Riscos { get; private set; }
        public string Recomendacao { get; private set; }
        /// <summary>
        /// Adiciona a entrada informada ao atributo Riscos
        /// </summary>
        /// <param name="risco"></param>
        public void AdicionaRisco(string risco)
        {
            Riscos = risco;
        }
        /// <summary>
        /// Adiciona a entrada informada ao atributo Recomendacao
        /// </summary>
        /// <param name="recomendacao"></param>
        public void AdicionaRecomendacao(string recomendacao)
        {
            Recomendacao = recomendacao;
        }
    }
}
