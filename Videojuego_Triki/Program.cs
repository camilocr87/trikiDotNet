using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videojuego_Triki
{
    internal class Program
    {
        //Creamos un arreglo bidimensional para el tablero del juego
        static int[,] tablero = new int[3, 3]; // 3 filas y 3 columnas
        //Creaos un arreglo para los simbolos del tablero (Espacio, Jug1 y Jug2)
        static char[] simbolo = { ' ', 'O', 'X' };

        static void Main(string[] args)
        {
            bool terminado = false;

            // Dibuja el trablero incial
            DibujarTablero();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");

            do
            {
                //Turno Jugador 1
                PreguntarPosicion(1); //Envio el valor de 1 a la funcion PreguntarPosicion

                //Dibujar la casilla del jugador 1
                DibujarTablero ();

                //Comprobar si ha ganado la partida el Jugador 1
                terminado = ComprobarGanador();

                if(terminado == true)
                {
                    Console.WriteLine("El jugador 1 ha ganado!");
                }
                else //Comprobamos si hubo empate
                {
                    terminado = ComprobarEmpate();
                    if(terminado == true)
                    {
                        Console.WriteLine("Esto es un empate!");
                    }

                    //Si jugador 1 no gano y tampoco hubo empate, es turno del jugador 2
                    else
                    {
                        //Turno jugador2
                        PreguntarPosicion (2);
                        //Dibujar la casilla del jugador 2
                        DibujarTablero();
                        //Comprobar si ha ganado la partida el jugador 2
                        terminado = ComprobarGanador();

                        if( terminado == true)
                        {
                            Console.WriteLine("El jugador 2 ha ganado!!");
                        }
                    }
                }

            } while (terminado == false); //Mientras el juego no haya terminado, es decir mientras la variable sea igual a false, se seguira repitiendo el ciclo.

        }//Cierre de Main

        static void DibujarTablero()
        {
            //Variables de conteo del ciclo
            int fila = 0;
            int columna = 0;

            Console.WriteLine(); //Espacio antes del dibujo del tablero
            Console.WriteLine("-------------"); // Dibuja la 1 linea horizontal
            for(fila = 0; fila < 3; fila ++) 
            {
                Console.Write("|"); //Dibujar la 1 linea vertical
                for (columna = 0; columna < 3; columna++)
                {
                    //Asigna un Espacio, O, X segun corresponda
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------"); // Dibuja las lineas horizontales

            }

        }

        //Funcion para preguntar donde escribir y lo dibuja en el tablero
        static void PreguntarPosicion(int jugador) //1= Jugador1 ; 2 = Jugador2
        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}", jugador);
                //Pedimos el numero de fila
                do
                {
                    Console.Write("Selecciona la fila (1 a 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());

                } while ((fila < 1) || (fila > 3));

                //Pedimos el numero de columna
                do
                {
                    Console.Write("Selecciona la columna (1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());

                } while ((columna < 1) || (columna > 3));

                if (tablero[fila - 1, columna - 1] != 0)
                    Console.WriteLine("Casilla ocupada!");

            } while (tablero[fila - 1, columna - 1] != 0);

            //Si todo es correcto, se le asigna al jugador correspondiente
            tablero[fila - 1, columna - 1] = jugador;
        }

        //Devuelve un true si hay tres en linea
        static bool ComprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool triki = false;

            //Si en alguna fila todas las casillas son = y no estan vacias
            for(fila = 0; fila < 3; fila++)
            {
                if( (tablero[fila,0] == tablero[fila,1]) 
                &&  (tablero[fila,0] == tablero[fila,2])
                &&  (tablero[fila,0] != 0) )
                {
                    triki = true;
                }
            }

            //Si en alguna columna todas las casillas son iguales y no estan vacias
            for (columna = 0; columna < 3; columna ++)
            {
                if ((tablero[0, columna] == tablero[1, columna])
                &&  (tablero[0, columna] == tablero[2, columna])
                &&  (tablero[0, columna]!= 0))
                {
                    triki = true;
                }
            }

            //Si en alguna diagonal todas la casillas son igual y no estan vacias
            if ((tablero[0, 0] == tablero[1, 1])
            &&  (tablero[0, 0] == tablero[2, 2])
            &&  (tablero[0, 0] != 0))
            {
                triki = true;
            }
            if ((tablero[0, 2] == tablero[1, 1])
            &&  (tablero[0, 2] == tablero[2, 0])
            &&  (tablero[0, 2] != 0))
            {
                triki = true;
            }
            return triki;
        }

        //Devuleve true si hay empate
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for(fila = 0; fila < 3; fila++) 
            {
                for(columna = 0;columna < 3; columna++) 
                {
                    if (tablero[fila, columna] == 0)
                    {
                        hayEspacio = true;   
                    }
                }
            }
            return !hayEspacio; //Si el ciclo anterior nos regresa un true donde indica que hay un espacio libre, se tiene que regresar negacion de true para que la condicion de empate no se cumpla en la funcion de Main.
        }
    }
}
