using System;

namespace Tateti
{
    class Program
    {
        static String[] tablero = new String[9];
        static String jugarDeNuevo = "Y";
        static int contador = 0;

        static void inicializarTablero()
        {
            for (int i = 0; i < 9; i++)
            {
                tablero[i] = (i + 1).ToString();
            }
        }

        static void jugarDeNuevoMensaje(String message)
        {
            Console.WriteLine(message + "Queres jugar de nuevo? Y/N");
            jugarDeNuevo = Console.ReadLine().ToUpper();
            while (!jugarDeNuevo.Equals("Y") && !jugarDeNuevo.Equals("N"))
            {
                Console.WriteLine("Respuesta incorrecta");
                Console.WriteLine(message + "Queres jugar de nuevo? Y/N");
                jugarDeNuevo = Console.ReadLine().ToUpper();
            }
        }

        static void Main(string[] args)
        {
            introduccion();
            while (jugarDeNuevo.Equals("Y"))
            {
                inicializarTablero();
                while (hayGanador() == false && contador < 9)
                {
                    pedirSeleccion("X");
                    if (hayGanador() == true)
                        break;
                    pedirSeleccion("O");
                }
                if (hayGanador() == true)
                    jugarDeNuevoMensaje("Felicitaciones! Usted Ganó! ");
                else
                    jugarDeNuevoMensaje("El juego terminó empatado!");
            }
            saludo();
        }

        static void saludo()
        {
            Console.WriteLine("Gracias por jugar!");
            Console.ReadLine();
        }

        static void pedirSeleccion(String jugador)
        {
            Console.Clear();

            Console.WriteLine("Jugador: " + jugador);
            int seleccion;

            while (true)
            {
                Console.WriteLine("Ingrese su elección");
                dibujarTablero();
                seleccion = Convert.ToInt32(Console.ReadLine());
                if (seleccion < 1 || seleccion > 9)
                {
                    Console.WriteLine("Selección inválida!");
                }
                else if (tablero[seleccion - 1].Equals("X") || tablero[seleccion - 1].Equals("O"))
                {
                    Console.WriteLine("Selección inválida!");
                }
                else
                {
                    break;
                }
            }
            tablero[seleccion - 1] = jugador;
        }

        static void dibujarTablero()
        {
            for (int i = 0; i < 7; i += 3)
                Console.WriteLine(tablero[i] + "|" + tablero[i + 1] + "|" + tablero[i + 2]);
        }

        static Boolean hayGanador()
        {
            for (int i = 0; i < 7; i += 3)
            {
                if (tablero[i].Equals(tablero[i + 1]) && tablero[i + 1].Equals(tablero[i + 2]))
                {
                    return true;
                }
            }
            if (tablero[0].Equals(tablero[3]) && tablero[3].Equals(tablero[6]))
                return true;
            if (tablero[1].Equals(tablero[4]) && tablero[4].Equals(tablero[7]))
                return true;
            if (tablero[2].Equals(tablero[5]) && tablero[5].Equals(tablero[8]))
                return true;
            if (tablero[2].Equals(tablero[4]) && tablero[4].Equals(tablero[6]))
                return true;
            if (tablero[0].Equals(tablero[4]) && tablero[4].Equals(tablero[8]))
                return true;
            return false;
        }


        static void introduccion()
        {
            Console.Title = ("Ta-Te-Ti");
            Console.WriteLine("Bienvenidos! \n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
