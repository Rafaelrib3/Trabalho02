using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho02
{
    public class GerenciadorDeRotas
    {
        public List<Rota> Rotas = new List<Rota>();

        public GerenciadorDeRotas()
        {
            Rotas = new List<Rota>();
        }

        public void AdicionarRota(int numero, string nome)
        {
            if (Rotas.Any(r => r.Numero == numero))
                throw new InvalidOperationException("Rota com o número já existente.");

            Rotas.Add(new Rota(numero, nome));
        }

        public void RemoverRota(int numero)
        {
            var rota = Rotas.FirstOrDefault(r => r.Numero == numero);
            if (rota == null)
                throw new InvalidOperationException("Rota inexistente.");

            Rotas.Remove(rota);
        }
        public Rota BuscarRota(int numero)
        {
            return Rotas.First(r => r.Numero == numero);
        }
        public List<Rota> ListarRotas()
        {
            return Rotas;
        }
        public bool VerificarConflitos()
        {

            for (int i = 0; i < Rotas.Count; i++)
            {
                var rotaA = Rotas[i];

                for (int j = i + 1; j < Rotas.Count; j++)
                {
                    var rotaB = Rotas[j];


                    foreach (var paradaA in rotaA.Paradas)
                    {
                        foreach (var paradaB in rotaB.Paradas)
                        {

                            if (paradaA.Nome == paradaB.Nome)
                            {

                                bool horariosConflitam =
                                    paradaA.HorarioSaida < paradaB.HorarioChegada &&
                                    paradaB.HorarioSaida < paradaA.HorarioChegada;

                                if (horariosConflitam)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

    }
}
