﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho02
{
    public class Parada
    {
        public string Nome { get; set; }

        public TimeSpan HorarioSaida { get; set; }

        public TimeSpan HorarioChegada { get; set; }

        public Parada(string nome, TimeSpan horarioSaida, TimeSpan horarioChegada)
        {
            Nome = nome;
            HorarioSaida = horarioSaida;
            HorarioChegada = horarioChegada;
        }
    }
}
