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
    }

}
