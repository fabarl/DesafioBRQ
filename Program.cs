using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Entrada de Dados
            Console.Write("Informe o Nome: "); var nome = Peso.VerificaNome(Console.ReadLine());
            // Console.WriteLine("#### Para o Calculo de IMC necessitamos saber o Sexo ### \r\n### Devido a isso e Somente por isso limitamos a resposta a 2 Opções! ###");
            Console.Write("Informe o Sexo, [M] Masculino ou [F] Feminino: "); var sexo = Peso.VerificaSexo(Console.ReadLine());
            Console.Write("Informe a Idade: "); var idade = Peso.VerificaIdade();
            Console.Write("Informe a Altura: "); var altura = Peso.VerificaAltura();
            Console.Write("Informe o Peso: "); var peso = Peso.VerificaPeso();
            Console.Clear();
            // Fim Entrada de Dados
            // Exibir os Dados
            Console.WriteLine("DIAGNÓSTICO PRÉVIO \r\n");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Sexo: {sexo}");
            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Altura: {altura}");
            Console.WriteLine($"Peso: {peso}");
            Console.WriteLine($"Categoria: {Peso.VerificaCategoria(idade)} \r\n");
            Console.WriteLine($"IMC Desejável: Entre 20 e 24");

            var imc = Peso.CalculoIMC(altura, peso);
            var informacoes = Peso.InformacoesImc(imc);

            Console.WriteLine($"Resultado IMC: {imc.ToString("F2")}");
            Console.WriteLine($"Riscos: {informacoes.Riscos}");
            Console.WriteLine($"Recomendação Inicial: {informacoes.Recomendacao}");
        }
    }
}
