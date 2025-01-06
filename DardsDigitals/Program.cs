using System;

namespace CompeticióDardsDigitals
{
    public class Program
    {
        static void Main(string[] args)
        {
            Competir();
        }

        public static void Competir()
        {
            var nw = new DardsDigitals();
            
            int totaljugador1 = 0;
            int totaljugador2 = 0;
            int obj = 50;

            int[,] diana = nw.CrearDiana();

            Console.WriteLine("Inicia la competició de dards digitals.");

            while (totaljugador1 < obj && totaljugador2 < obj)
            {
                int[] tirada1 = nw.TirarDard(diana, 2, 3); // Simulación de una tirada fija
                totaljugador1 += tirada1[2];
                Console.WriteLine($"Jugador 1 tira a ({tirada1[0]},{tirada1[1]}) - {totaljugador1} punts.");

                int[] tirada2 = nw.TirarDard(diana, 4, 5); // Simulación de una tirada fija
                totaljugador2 += tirada2[2];
                Console.WriteLine($"Jugador 2 tira a ({tirada2[0]},{tirada2[1]}) - {totaljugador2} punts.");
            }

            nw.Desempate(diana, ref totaljugador1, ref totaljugador2);

            nw.AnunciarGanador(totaljugador1, totaljugador2);
        }

        public class DardsDigitals
        {
            public int[,] CrearDiana()
            {
                return new int[,]
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 1, 1, 1, 1, 1, 1, 0 },
                    { 0, 1, 2, 2, 2, 2, 2, 1, 0 },
                    { 0, 1, 2, 5, 5, 5, 2, 1, 0 },
                    { 0, 1, 2, 5, 10, 5, 2, 1, 0 },
                    { 0, 1, 2, 5, 5, 5, 2, 1, 0 },
                    { 0, 1, 2, 2, 2, 2, 2, 1, 0 },
                    { 0, 1, 1, 1, 1, 1, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };
            }

            public int[] TirarDard(int[,] diana, int jugadorx, int jugadory)
            {
                int punts = diana[jugadorx, jugadory];
                return new int[] { jugadorx, jugadory, punts };
            }

            public void Desempate(int[,] diana, ref int totaljugador1, ref int totaljugador2)
            {
                if (totaljugador1 == totaljugador2)
                {
                    int[] tirada1 = TirarDard(diana, 2, 3);
                    totaljugador1 += tirada1[2];
                    Console.WriteLine($"Jugador 1 tira a ({tirada1[0]},{tirada1[1]}) - {totaljugador1} punts.");

                    int[] tirada2 = TirarDard(diana, 4, 5);
                    totaljugador2 += tirada2[2];
                    Console.WriteLine($"Jugador 2 tira a ({tirada2[0]},{tirada2[1]}) - {totaljugador2} punts.");
                }
            }

            public void AnunciarGanador(int totaljugador1, int totaljugador2)
            {
                if (totaljugador1 > totaljugador2)
                {
                    Console.WriteLine($"Ha guanyat el jugador 1 amb {totaljugador1} punts.");
                }
                else
                {
                    Console.WriteLine($"Ha guanyat el jugador 2 amb {totaljugador2} punts.");
                }
            }
        }
    }
}
