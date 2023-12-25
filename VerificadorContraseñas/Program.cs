using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificadorContraseñas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("YO SOY UN PROGRAMADOR Y EXPERTO EN REDES RECONOCIDO Y EXCELENTE");
            /* * De entre 8 y 20 caracteres
             *van a contener una letra minuscula
             *una letra mayuscula
             y un caracter especial*/
            //Variables necesarias
            string nombreUsuario, opcion, contraseña;
            //declaramos una tupla de nombre "verificarContraseña" para que reciba dos valores del metodo que valida la contraseña
            (bool contraseñaValida, string mensajeError) verificarContraseña;

            //Un titulo para el programa
            Console.WriteLine("\t\tRegistro\n\n");
            //Pedimos nombre de usuario
            Console.Write("Ingrese nombre de usuario:  ");
            nombreUsuario = Console.ReadLine();
            //Preguntamos si se desea hacer uso del generador de contraseñas o escribir una nosostros mismos
            Console.Write("¿desea que le generemos una contraseña segura? (si/no): ");
            opcion = Console.ReadLine();
            opcion = opcion.ToLower();//Convertimos a minuscula la respuesta del usuario ( en caso de que use mayusculas o una combinacion de ambas)
            //Seguimos una de las dos posibles rutas
            switch (opcion)
            {
                case "si":
                    //instanciamos a la clase Contraseña para poder hacer uso de ella
                    Contraseña contraseña1 = new Contraseña();
                    //llamamos a su metodo "GenerarContraseña" y le asignamos lo que devuelva a nuestra variable local "contraseña"
                    contraseña = contraseña1.GenerarContraseña();

                    Console.WriteLine($"Esta es la contraseña que generamos para ti, guardala en un lugar seguro: {contraseña}");
                    Console.Write("\nPresiona cualquier tecla para terminar tu registro ");
                    Console.ReadKey();
                    Console.Clear();
                    //Mostramos un resumen de los datos
                    Console.WriteLine($"\nTus datos de acceso son los siguientes:\n\tusuario: {nombreUsuario}\n\tcontraseña: {contraseña}");
                    break;

                case "no":
                    Console.WriteLine($"\nIngrese una contraseña segura(La contraseña debe contener entre 8 -20 caracteres,incluido un numero, una mayuscula, una minuscula y uno de los siguientes caracteres especiales: $%#&!?): ");
                    contraseña = Console.ReadLine();

                    //Instanciamos a la clase Contraseña para poder hacer uso de ella
                    Contraseña contraseña2 = new Contraseña();

                    //Le asignamos a la tupla lo que devuelva el metodo "Comporobar contraseña" y tambien le mandamos como argumento a la variable local "contraseña"
                    verificarContraseña = contraseña2.ComprobarContraseña(contraseña);

                    //Si el primer elemento de la tupla (bool contraseñaValida) es "true" entonces ingresamos al "if"

                    if (verificarContraseña.contraseñaValida)
                    {
                        Console.Write("\nPresiona cualquier tecla para terminar tu registro");
                        Console.ReadKey();
                        Console.Clear();

                        Console.Write("\nTus datos de acceso son los siguientes:\n\tusuario:{nombreUsuario}\n\tcontraseña: {contraseña}");

                    }
                    //De lo contrario mostramos el mensaje de error devuelto por el metodo y agregamos uno extra
                    else
                    {
                        //Usamos el segundo elemento de la tupla(mensajeError) al que se le asigno una de las devoluciones del metodo, para despues mostrarlo
                        Console.WriteLine(verificarContraseña.mensajeError + " .Ingrese una contraseña valida");
                    }
                    break;
            }

           

        }
    }
    class Contraseña
    {
        //CAMPOS
        //4 colecciones de caracteres para escoger
        string numeros = "0123456789";
        string letrasMin = "abcdefghijklmnñopqrstuvwxyz";
        string letrasMay = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        string caracterEspecial = "$%#&!?";
        //contadores para verificar el numero de caracteres de cada grupo
        int numContiene = 0, minContiene = 0, mayContiene = 0, espContiene = 0;

        //Metodo para generar la contraseña
        public string GenerarContraseña()
        {
            //Aqui guardamos la contraseña
            string contraseñaGenerada = "";
            //Instanciamos la clase random para usarla mas adelante
            Random random = new Random();
            //Declaramos una variable para que guarde el tamaño que tendra la contraseña,
            //generamos un numero aleatorio para determinar una longitud de entre 8 y 20 caracteresy se lo asignamos a la variable

        }

        //Metodo para comprobar contraseña
        public (bool, string) ComprobarContraseña(string contraseñaPa)
        {
            //Variable que guardara el valor bool cuando compruebe todas las caracteristicas de la contraseña
            bool contraseñaValida = false;
            //Variables para cada criterio de la contraseña
            bool hayNumero = false, hayMinuscula = false, hayMayuscula =false, hayEspecial = false;
            //Variable que contendra el mensaje de error
            string mensajeError = "";
            //verificar que se cumpla primero la longitud
            if(contraseñaPa.Length >=8 && contraseñaPa.Length <= 20)
            {
                foreach (char elemento in numeros)
                {
                    //Si el elemento de "numeros" se encuentra en la contraseña dada por el usuario, entonces se ingresa al "If" y "esNumero" se convierte en "True"
                    
                    if (contraseñaPa.IndexOf(elemento) >= 0)
                    {
                        hayNumero = true;
                        break; // Lainstruccion "break" fuerza la terminacion del foreach en el momento en que encuentre un numero, lo que significa que el "if" se cumple

                    }
                    else
                    {
                        hayNumero = false;
                        mensajeError = "La contraseña debe contener al menos un numero";
                    }

                }
                //Verificamos que haya existido un numero en la contraseña
                if (hayNumero)
                {
                    //Verificamos que contenga al menos una letra minuscula
                    foreach (char elemento in letrasMin)
                    {
                        if(contraseñaPa.IndexOf(elemento) >= 0)
                        {
                            hayMinuscula = true;
                            break; //La instruccion "break" fuerza la terminacion del "foreach" en el momento en que encuentre el numero, lo que significa que el "if" se cumple
                        }
                        else
                        {
                            hayMinuscula = false;
                            mensajeError = "La contraseña debe contener al menos una minuscula";
                        }
                    }

                }
                if (hayMayuscula)
                {
                    foreach (char elemento in letrasMay)
                    {
                        if(contraseñaPa.IndexOf(elemento) >= 0)
                        {
                            hayMinuscula = true;
                            break; //La instruccion "break" fuerza la terminacion del "foreach" en el momento en que encuentre la mayuscula, lo que significa que el "if" se cumple

                        }
                        else
                        {
                            hayMayuscula = false;
                            mensajeError = "La contraseña debe contener al menos una mayuscula";
                        }
                    }
                }
                if (hayEspecial)
                {
                    foreach(char elemento in caracterEspecial)
                    {
                        if(contraseñaPa.IndexOf(elemento) >= 0)
                        {
                            hayEspecial = true;
                            break;
                        }
                        else
                        {
                            hayEspecial = false;
                            mensajeError = "La contraseña debe contener al menos un caracter especial($%#&!?";
                        }
                    }
                }
                //Verificamos que exista un numero, una letra minuscula, una letra mayuscula y un caracter especial
              if(hayNumero && hayMinuscula && hayMayuscula && hayEspecial)
                {
                    //Sila contraseña cumple con todos los requisitos, entonces devolvemos un "true"
                    contraseñaValida = true;

                }
                else
                {
                    //Si la contraseña no cumple con los requisitos, entonces devolvemos un "false"
                    contraseñaValida = false;
                }

            }

            else
            {
                //Si la contraseña no cumple si quiera con la longitud requerida, entonces se lo indicamos al usuario
                mensajeError = "La contraseña debe contener entre 8 y 20 caracteres";
                contraseñaValida = false;
            }
            //Devolvemos una tupla conformada por el booleano de la contraseña y por el mensaje de error
            return (contraseñaValida, mensajeError);

        }

    }
}
