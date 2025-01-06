
using CompeticióDardsDigitals;

namespace TestCompeticióDardsDigitals
{
    public class TestDardsDigitals
    {
        [Fact]
        public void TestTirarDard()
        {
            // Arrange
            var dards = new Program.DardsDigitals();
            int[,] diana = dards.CrearDiana();
            
            // Simulem que la tirada és (1, 1)
            int jugadorx = 1;
            int jugadory = 1;

            // Act
            var resultat = dards.TirarDard(diana, jugadorx, jugadory);

            // Assert
            Assert.Equal(jugadorx, resultat[0]);
            Assert.Equal(jugadory, resultat[1]);
            Assert.Equal(1, resultat[2]); // El valor en la posició (1, 1) es 2
        }
    }
}