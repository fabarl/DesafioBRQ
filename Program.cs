using System;
using System.Collections.Generic;
using System.Globalization;

namespace IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Entrada de Dados
            Console.Write("Informe o Nome: ");  var nome = Peso.VerificaNome(Console.ReadLine());
            Console.WriteLine("#### Para o Calculo de IMC necessitamos saber o Sexo de nascimento ### \r\n### Devido a isso e Somente por isso limitamos a resposta a 2 Opções! ###");
            Console.Write("Informe o Sexo, [M] Masculino ou [F] Feminino: "); var sexo = Peso.VerificaSexo(Console.ReadLine());
            Console.Write("Informe a Idade: "); var idade = Peso.VerificaIdade(int.Parse(Console.ReadLine()));
            Console.Write("Informe a Altura: ");    var altura = Peso.VerificaAltura(double.Parse(Console.ReadLine()));
            Console.Write("Informe o Peso: ");  var peso = Peso.VerificaPeso(double.Parse(Console.ReadLine()));
            Console.Clear();
            // Fim Entrada de Dados
            // Exibir os Dados
            Console.WriteLine("DIAGNÓSTICO PRÉVIO \r\n");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Sexo: {sexo}");
            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Altura: {altura.ToString(CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Peso: {peso.ToString(CultureInfo.InvariantCulture)}");

        }
    }
}
