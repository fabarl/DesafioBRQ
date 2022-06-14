﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMC
{
    public class Peso
    {
        public static string VerificaNome(string nome) // Função que fará a verificação do nome afim de evitar dados inválidos!
        {
                if (nome == null || nome == " " )
                {
                    Console.Write("Nome Inválido! Insira o Nome Novamente: ");
                    VerificaNome(Console.ReadLine()); // recursividade até receber um valor válido!
                }
         return nome;
        }
        public static string VerificaSexo(string sex) // Função para verificar se foi informado o Sexo Corretamente
        {
            if((sex != "M" || sex != "m") && (sex != "F" || sex != "f"))
            {
                Console.Write("[ERRO] Sexo inválido! Informe a Sexualidade [M] Masculino, [F] Feminino:  ");
                VerificaSexo(Console.ReadLine()); // recursividade para obter um sexo válido
            }
            return sex;
        }
        public static int VerificaIdade(int num) // Função para verificar se a idade informada é válida
        {
            try // verifica se o dado informado é inteiro
            {
                if(num <= 0) // verifica se o valor é negativo ou 0
                {
                    Console.Write("[ERRO] Idade Inválida, Digite Novamente: ");
                    VerificaIdade(int.Parse(Console.ReadLine()));
                }
            }
            catch //erro caso o dado informado não seja um numero inteiro
            {
                Console.Write("[ERRO] Idade Inválida, Digite Novamente: ");
                VerificaIdade(int.Parse(Console.ReadLine()));
            }
            return num;
        }
        public static double VerificaAltura(double alt) // Função para Verificar a Altura informáda
        {
            try //verifica se o dado informádo é do Tipo double!
            {
                if(alt <= 0)
                {
                    Console.Write("[ERRO] Altura Inválida! Informe a Altura: ");
                    VerificaAltura(double.Parse(Console.ReadLine()));
                }
            }
            catch
            {
                Console.Write("[ERRO] Altura Inválida! Informe a Altura: ");
                VerificaAltura(double.Parse(Console.ReadLine()));
            }
            return alt;
        }
        public static double VerificaPeso(double pes) // Função para Verificar se o Peso informado é Válido!
        {
            try //Verifica se o dado informado é double
            {
                if(pes <= 0)
                {
                    Console.Write("[ERRO] Peso inválido! Informe o Peso: ");
                    VerificaPeso(double.Parse(Console.ReadLine())); //recursividade até receber o peso correto
                }
            }
            catch
            {
                Console.Write("[ERRO] Peso inválido! Informe o Peso: ");
                VerificaPeso(double.Parse(Console.ReadLine())); //recursividade até receber o peso correto
            }
            return pes;
        }
    }
}
