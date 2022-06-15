using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace IMC
{
    public class Peso
    {
        public static string VerificaNome(string nome) // Função que fará a verificação do nome afim de evitar dados inválidos!
        {
            while (string.IsNullOrWhiteSpace(nome))//Verifico se existe só espaços ou espaços nulos
            {
                Console.Write("Nome Inválido! \r\nInsira o Nome Novamente: ");
                nome = Console.ReadLine(); // laço para receber um valor válido!
            }
            return nome;//tudo OK retorna a string
        }
        public static string VerificaSexo(string sex) // Função para verificar se foi informado o Sexo Corretamente
        {
            string sexo = sex;
            while (sex.ToUpper() != "M" && sex.ToUpper() != "F")// Coloco toda string em maiscula e faço a comparação
            {
                Console.Write("[ERRO] Sexo inválido! \r\nInforme o sexo [M] Masculino ou [F] Feminino:  ");
                sex = Console.ReadLine(); // Laço para obter um sexo válido
            }
            if (sex.ToUpper() == "M") // Depois de Identificado o sexo, retorno ele por extenso
                sexo = "Masculino"; 
            if (sex.ToUpper() == "F") 
                sexo = "Feminino";
            return sexo;
        }
        public static int VerificaIdade() //Verifica se a Idade é válida
        {
            int num;
            bool exit; // Bolleano pra sair do laço
            do
            {
                var idade = Console.ReadLine(); //recebe a entrada
                if (Regex.IsMatch(idade, "^[0-9]{1,}$"))// Verifica a idade e não aceita idade com valores flutuantes, usei Regex por ser mais dinâmico, apesar de complexo e verificações mais detalhadas
                {
                    num = Convert.ToInt16(idade); 
                    if (num > 0 && num <= 130)// verifica se a idade está no intervalo, segundo o padrão do e-SUS a idade maxima no Brasil hoje (14/06/2022)  é 130 Anos
                        exit = true; //Tudo Ok, atribuo true a variavel de comparação para sair do laço
                    else //Não está no intervalo de 0 a 130 Anos
                    {
                        Console.Write("[ERRO2] Idade Fora do Padrão, Digite Novamente: ");
                        return VerificaIdade();//Recursividade para receber o valor novamente
                    }

                }
                else //Não entrou no regex, ou não é número ou é um valor flutuante, idade de comparação feita pelo enunciando é inteiro positivo
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
                try // Verifica se a entrada é Double
                {
                    var entrada2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); // recebe a entrada e converte para o Double padrão Brasileiro
                    if (entrada2 > 0 && entrada2 < 3)//Verifico se a altura entá entre 0 a 3 metros, a Pessoa mais alta da História foi Robert Wadlow, com 2,73m e atualmente Sultan Kösen com 2,51 ambos abaixo dos 3 metros
                        num = entrada2;
                    else
                        Console.Write("[ERRO] Altura Inválida, Digite Novamente: ");
                }
                catch (Exception) // Erro caso a entrada não seja Double
                {
                    Console.Write("[ERRO] Altura Inválida, Digite Novamente: ");
                }
            } while (num < 1);// entrada correta no intervalo solicitado, sai do laço
            return num;
        }

        public static double VerificaPeso() // Função para Verificar se o Peso informado é Válido!
        {
            double vlr = 0;
            do
            {
                try // Verifica se a entrada é Double
                {
                    var pes = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); // recebe a entrada e converte para o Double padrão Brasileiro
                    if (pes > 0 && pes < 700) // verifica o intervalo de peso de 0 a 700kg e atribui o vlor da, a pessoa mais pesada da história foi Jon Brower Minnoch com 635Kg.
                        vlr = pes; 
                    else Console.Write("[ERRO] Peso inválido! Digite novamente: ");
                }
                catch (Exception)// Erro caso a entrada não seja Double
                {
                    Console.Write("[ERRO] Peso inválido! Digite novamente: ");
                }
            } while (vlr < 1);// entrada correta no intervalo solicitado , sai do laço
            return vlr;
        }


        public static string VerificaCategoria(int idade) // Função para definir a categoria
        {
            if (idade < 12) // Verifica a Idade e retorno a Informação conforme a idade
                return "Infantil";
            if (idade >= 12 && idade <= 20) 
                return "Juvenil";
            if (idade >= 21 && idade <= 65) 
                return "Adulto";
            if (idade > 65) 
                return "Idoso";
            return "Nenhuma";
        }
        public static double CalculoIMC(double alt, double peso)// Função que Faz o calculo do IMC
        {
            var result = peso / Math.Pow(alt, 2);
            return result;
        }

        public static InformacoesImc InformacoesImc(double imc)//Função de tipo classe para exibir as informações de Recomendação e Riscos
        {
            var msg = "Sem informações com os parametros informados";
            var retorno = new InformacoesImc(); //cria o objeto e instância ele
            retorno.AdicionaRecomendacao(msg); //metodo para adicionar uma mensagem por default caso as validações abaixo não sejam atendidas
            retorno.AdicionaRisco(msg);//metodo para adicionar uma mensagem por default caso as validações abaixo não sejam atendidas
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