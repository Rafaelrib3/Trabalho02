using Trabalho02;

namespace Trabalho02Tests
{
    public class GerenciadorRotasTests
    {
        [Fact]
        public void AdicionarRota_DeveAdicionarRotaValida()
        {
            // Arrange
            var gerenciador = new GerenciadorDeRotas();

            // Act
            gerenciador.AdicionarRota(1, "Rota 1");

            // Assert
            Assert.Single(gerenciador.ListarRotas());
            Assert.Equal(1, gerenciador.ListarRotas().First().Numero);
        }

        [Fact]
        public void AdicionarRota_DeveLancarExcecaoParaRotaDuplicada()
        {
            // Arrange
            var gerenciador = new GerenciadorDeRotas();
            gerenciador.AdicionarRota(1, "Rota 1");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => gerenciador.AdicionarRota(1, "Rota 2"));
        }
        [Fact]
        public void AdicionarParada_DeveAdicionarParadaValida()
        {
            // Arrange
            var rota = new Rota(1, "Rota 1");
            var parada = new Parada("Parada 1", TimeSpan.Parse("08:00"), TimeSpan.Parse("08:10"));

            // Act
            rota.AdicionarParada(parada);

            // Assert
            Assert.Single(rota.Paradas);
            Assert.Equal("Parada 1", rota.Paradas.First().Nome);
        }
        [Fact]
        public void RemoverRota_DeveRemoverRotaExistente()
        {
            // Arrange
            var gerenciador = new GerenciadorDeRotas();
            gerenciador.AdicionarRota(1, "Rota 1");

            // Act
            gerenciador.RemoverRota(1);

            // Assert
            Assert.Empty(gerenciador.ListarRotas());
        }

        [Fact]
        public void RemoverRota_DeveLancarExcecaoParaRotaInexistente()
        {
            // Arrange
            var gerenciador = new GerenciadorDeRotas();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => gerenciador.RemoverRota(1));
        }
        [Fact]
        public void RemoverParada_DeveRemoverParadaExistente()
        {
            var rota = new Rota(1, "Rota 1");
            var parada = new Parada("Parada 1", TimeSpan.Parse("08:00"), TimeSpan.Parse("08:10"));
            rota.AdicionarParada(parada);

            rota.RemoverParada("Parada 1");

            Assert.DoesNotContain(parada, rota.Paradas);
        }

        [Fact]
        public void RemoverParada_DeveLancarExcecaoParaParadaInexistente()
        {

            var rota = new Rota(1, "Rota 1");

            Assert.Throws<Exception>(() => rota.RemoverParada("Parada Inexistente"));
        }

        [Fact]
        public void AtualizarNome_DeveAtualizarNomeCorretamente()
        {
            var rota = new Rota(1, "Rota 1");

            rota.AtualizarNome("Nova Rota 1");

            Assert.Equal("Nova Rota 1", rota.Nome);
        }

        [Fact]
        public void ListarRotas_DeveListarTodasAsRotas()
        {

        }

        [Fact]
        public void ListarParadas_DeveListarTodasParadas()
        {
            var rota = new Rota(1, "Rota 1");
            rota.AdicionarParada(new Parada("Parada 1", TimeSpan.Parse("08:00"), TimeSpan.Parse("08:10")));
            rota.AdicionarParada(new Parada("Parada 2", TimeSpan.Parse("08:15"), TimeSpan.Parse("08:25")));

            rota.ListarParadas();
        }

        [Fact]
        public void BuscarRota_DeveRetornarRotaCorreta()
        {
            var gerenciador = new GerenciadorDeRotas();
            gerenciador.AdicionarRota(1, "Rota 1");

            var rota = gerenciador.BuscarRota(1);

            Assert.NotNull(rota);
            Assert.Equal(1, rota.Numero);
        }

        [Fact]
        public void BuscarRota_DeveRetornarNuloParaRotaInexistente()
        {

        }

        [Fact]
        public void VerificarConflitos_DeveIdentificarConflitosCorretamente()
        {
            var gerenciador = new GerenciadorDeRotas();
            var rota1 = new Rota(1, "Rota 1");
            rota1.AdicionarParada(new Parada("Parada 1", TimeSpan.Parse("08:00"), TimeSpan.Parse("08:10")));
            gerenciador.AdicionarRota(1, "Rota 1");

            var rota2 = new Rota(2, "Rota 2");
            rota2.AdicionarParada(new Parada("Parada 1", TimeSpan.Parse("08:05"), TimeSpan.Parse("08:15")));
            gerenciador.AdicionarRota(2, "Rota 2");

            var conflitos = gerenciador.VerificarConflitos();

            Assert.False(conflitos);
        }

        [Fact]
        public void VerificarConflitos_AposRemoverRota_DeveRetornarFalso()
        {
            var gerenciador = new GerenciadorDeRotas();
            var rota1 = new Rota(1, "Rota 1");
            rota1.AdicionarParada(new Parada("Parada 1", TimeSpan.Parse("08:00"), TimeSpan.Parse("08:10")));
            gerenciador.AdicionarRota(1, "Rota 1");

            var rota2 = new Rota(2, "Rota 2");
            rota2.AdicionarParada(new Parada("Parada 1", TimeSpan.Parse("08:05"), TimeSpan.Parse("08:15")));
            gerenciador.AdicionarRota(2, "Rota 2");

            gerenciador.RemoverRota(2);

            var conflitos = gerenciador.VerificarConflitos();

            Assert.False(conflitos);
        }
    }
}

