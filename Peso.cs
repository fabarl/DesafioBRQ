using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace IMC
{
    public class Peso
    {
        public static string VerificaNome(string nome) // Função que fará a verificação do nome afim de evitar dados inválidos!
        {
            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.Write("Nome Inválido! \r\nInsira o Nome Novamente: ");
                nome = Console.ReadLine(); // laço para receber um valor válido!
            }
            return nome;
        }
        public static string VerificaSexo(string sex) // Função para verificar se foi informado o Sexo Corretamente
        {
            string sexo = sex;
            while (sex.ToUpper() != "M" && sex.ToUpper() != "F")
            {
                Console.Write("[ERRO] Sexo inválido! \r\nInforme o sexo [M] Masculino ou [F] Feminino:  ");
                sex = Console.ReadLine(); // Laço para obter um sexo válido
            }
            if (sex.ToUpper() == "M") sexo = "Masculino";
            if (sex.ToUpper() == "F") sexo = "Feminino";
            return sexo;
        }
        public static int VerificaIdade() //Verifica se a Idade é válida
        {
            int num;
            bool exit;
            do
            {
                var idade = Console.ReadLine();
                if (Regex.IsMatch(idade, "^[0-9]{1,}$"))// Verifica a idade e não aceita idade com valores flutuantes.
                {
                    num = Convert.ToInt16(idade);
                    if (num > 0 && num < 130)
                        exit = true;
                    else
                    {
                        Console.Write("[ERRO2] Idade Fora do Padrão, Digite Novamente: ");
                        return VerificaIdade();
                    }

                }
                else
                {
                    Console.Write("[ERRO1] Idade Fora do Padrão, Digite Novamente: ");
                    return VerificaIdade();
                }

            } while (!exit);
            return num;
        }

        public static double VerificaAltura() // Função para Verificar a Altura informada
        {
            double num = 0;
            do
            {
                try
                {
                    var entrada2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    if (entrada2 > 0 && entrada2 < 3)
                        num = entrada2;
                    else
                        Console.Write("[ERRO] Altura Inválida, Digite Novamente: ");

                }
                catch (Exception)
                {
                    Console.Write("[ERRO] Altura Inválida, Digite Novamente: ");
                }
            } while (num < 1);
            return num;
        }

        public static double VerificaPeso() // Função para Verificar se o Peso informado é Válido!
        {
            double vlr = 0;
            do
            {
                try
                {
                    var pes = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    if (pes > 0 && pes < 500) vlr = pes;
                    else Console.Write("[ERRO] Peso inválido! Digite novamente: ");
                }
                catch (Exception)
                {
                    Console.Write("[ERRO] Peso inválido! Digite novamente: ");
                }
            } while (vlr < 1);
            return vlr;
        }


        public static string VerificaCategoria(int idade) // Função para definir a categoria
        {
            if (idade < 12) return "Infantil";
            if (idade >= 12 && idade <= 20) return "Juvenil";
            if (idade >= 21 && idade <= 65) return "Adulto";
            if (idade > 65) return "Idoso";
            return "Nenhuma";
        }
        public static double CalculoIMC(double alt, double peso)// Função que Faz o calculo do IMC
        {
            var result = peso / Math.Pow(alt, 2);
            return result;
        }

        public static InformacoesImc InformacoesImc(double imc)
        {
            var msg = "Sem informações com os parametros informados";
            var retorno = new InformacoesImc();
            retorno.AdicionaRecomendacao(msg);
            retorno.AdicionaRisco(msg);
            if (imc < 20)
            {
                retorno.AdicionaRecomendacao("Inclua carboidratos simples em sua dieta, além de proteínas \r\n- indispensáveis para ganho de massa magra. Procure um profissional.");
                retorno.AdicionaRisco("Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso.");
                return retorno;
            }
            if (imc >= 20 && imc <= 24)
            {
                retorno.AdicionaRecomendacao("Mantenha uma dieta saudável e faça seus exames periódicos.");
                retorno.AdicionaRisco("Seu peso está ideal para suas referências.");
                return retorno;
            }

            if (imc > 24 && imc <= 29)
            {
                retorno.AdicionaRecomendacao("Adote um tratamento baseado em dieta balanceada, \r\nexercício físico e medicação. A ajuda de um profissional pode ser interessante");
                retorno.AdicionaRisco("Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.");
                return retorno;
            }

            if (imc > 29 && imc <= 35)
            {
                retorno.AdicionaRecomendacao("Adote uma dieta alimentar rigorosa, com o acompanhamento \r\nde um nutricionista e um médico especialista(endócrino).");
                retorno.AdicionaRisco("Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.");
                return retorno;
            }
            if (imc > 35)
            {
                retorno.AdicionaRecomendacao("Procure com urgência o acompanhamento de um nutricionista para \r\nrealizar reeducação alimentar, um psicólogo e um médico especialista(endócrino).");
                retorno.AdicionaRisco("Procure com urgência o acompanhamento de um nutricionista para \r\nrealizar reeducação alimentar, um psicólogo e um médico especialista(endócrino).");
                return retorno;
            }
            return retorno;
        }
    }
}