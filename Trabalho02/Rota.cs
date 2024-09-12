﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho02
{
    public class Rota
    {
        public int Numero { get; set; }
        public string Nome { get; set; }

        public List<Parada> Paradas = new List<Parada>();

        public Rota(int numero, string nome)
        {
            Numero = numero;
            Nome = nome;
            Paradas = new List<Parada>();
        }

        public void AdicionarParada(Parada parada)
        {
            Paradas.Add(parada);
        }
        public void RemoverParada(string nomeParada)
        {
            var parada = Paradas.FirstOrDefault(p => p.Nome == nomeParada);
            if (parada != null)
            {
                Paradas.Remove(parada);
            }
            else
            {
                throw new Exception("Parada não encontrada.");
            }
        }

        public void AtualizarNome(string novoNome)
        {
            Nome = novoNome;
        }

        public void ListarParadas()
        {
            foreach (var parada in Paradas)
            {
                Console.WriteLine($"Parada: {parada.Nome}, Chegada: {parada.HorarioChegada}, Saída: {parada.HorarioSaida}");
            }
        }
    }
}

