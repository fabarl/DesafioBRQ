using System;
using System.Collections.Generic;

namespace IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Informe o Nome: ");  var nome = Peso.VerificaNome(Console.ReadLine());
            Console.WriteLine("Para o Calculo de IMC necessitamos saber o Sexo de nascimento, Devido a isso e Somente por isso limitamos a resposta a 2 Opções!");
            Console.Write("Informe o Sexo, [M] Masculino, [F] Feminino: "); var sexo = Peso.VerificaSexo(Console.ReadLine());
            Console.Write("Informe a Idade: "); var idade = Peso.VerificaIdade(int.Parse(Console.ReadLine()));
            Console.Write("Informe a Altura: ");    var altura = Peso.VerificaAltura(double.Parse(Console.ReadLine()));
            Console.Write("Informe o Peso: ");  var peso = Peso.VerificaPeso(double.Parse(Console.ReadLine()));
            Console.Clear();


        }
    }
}
