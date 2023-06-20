﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.Sistema_de_Login.TypesUsers
{
    public class LoginAdmin : IEquatable<LoginAdmin>
    {
        public string Email { get; }
        public string Senha { get; }

        //Criando objeto do Tipo LoginAdmin
        public LoginAdmin(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        //Comparador Personalizado 
        public bool Equals(LoginAdmin? obj)
        {
            if (obj == null) return false;

            //Se os valores dessas propriedades forem iguais em ambos os objetos, eles serão considerados iguais.
            if (Email == obj.Email && Senha == obj.Senha) return true;

            return false;
        }

        public override bool Equals(object? obj) => obj switch
        {
            null => false,
            LoginAdmin user => Equals(user),
            _ => base.Equals(obj)
        };
        public override int GetHashCode()
        {
            // hash é um algoritmo que mapeia dados de tamanho variável para um valor de tamanho fixo, geralmente um valor numérico ou uma sequência de bytes.
            //A palavra-chave unchecked indica que o cálculo do código hash não levanta uma exceção se ocorrer um estouro de inteiro.
            return HashCode.Combine(Email, Senha);
        }
    }
}
