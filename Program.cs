using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace programa26_ArchivoTextoBytes
{
    //Dueñas Nuñez Alan Gabriel 19211630
    class Program
    {
        //clase para flujo de bytes
        public class TextoBytes
        {
            //campos de la clase
            public string nombre;
            FileStream fInput = null;
            FileStream fOutput = null;
            public byte[] bArray = new byte[81]; //arreglo de bytes 
            public char[] cArray = new char[81]; //arreglo de caracteres 
            public int nbytes = 0, mensaje; 

            //contructor que recibe la variable del nombre
            public TextoBytes(string nombre)
            {
                this.nombre = nombre;
            }

            //metodo para crear archivo
            public void CrearArchivo()
            {
                try
                {
                    //crear un flujo hacia el archivo
                    fInput = new FileStream("./" + nombre + ".txt", FileMode.Create, FileAccess.Write);

                    //escribir en el archivo de texto
                    Console.WriteLine("Escriba el texto que desea almacenar en el archivo " +
                        nombre + " ,al finalizar presione <enter>:\n");

                    while ((mensaje = Console.Read()) != '\r' && (nbytes < bArray.Length))
                    {
                        bArray[nbytes] = (byte)mensaje; //convierte en byte el carácter leído
                        nbytes++;
                    }

                    // Escribe la línea de texto en el archivo 
                    fInput.Write(bArray, 0, nbytes);
                }
                catch (IOException e1)
                {
                    Console.WriteLine("Mensaje del Error: " + e1.Message);
                    Console.WriteLine("Ruta del Error: " + e1.StackTrace);
                }
                finally
                {
                    if (fInput != null) fInput.Close();  //cierra el flujo escritura
                    Console.WriteLine("\nEl finally siempre se ejecuta...");
                }
            }

            //metodo para leer archivo
            public void LeerArchivo()
            {
                try
                {
                    // Crea un flujo desde el archivo texto.txt
                    fOutput = new FileStream("./" + nombre + ".txt", FileMode.Open, FileAccess.Read);

                    // Lee del archivo una línea de texto
                    nbytes = fOutput.Read(bArray, 0, 81);

                    // Crea un objeto string con el texto leído 
                    Array.Copy(bArray, cArray, bArray.Length);
                    String str = new String(cArray, 0, nbytes);

                    // Muestra el texto leído
                    Console.WriteLine("Contenido del Archivo " + nombre + "\n");
                    Console.WriteLine(str);
                }

                catch (IOException e2)
                {
                    Console.WriteLine("Mensaje del Error: " + e2.Message);
                    Console.WriteLine("Ruta del Error: " + e2.StackTrace);
                }

                finally
                {
                    if (fOutput != null) fOutput.Close();  //cierra el flujo lectura
                    Console.WriteLine("\nEl finally siempre se ejecuta...");                   
                }
            }
        }
        static void Main(string[] args)
        {
            //variables
            string auxnombre, opcion;
  
            //nombre del archivo del archivo
            Console.WriteLine("MENU Archivo de Texto con Flujo de Bytes");
            Console.WriteLine("........................................");
            Console.Write(">>Ingrese el nombre del archivo que se creara y leera: ");
            auxnombre = Console.ReadLine();

            //mandar la variable auxiliar al constructor de TextoBytes
            TextoBytes obj1 = new TextoBytes(auxnombre);

            //menu
            do
            {
                //limpiar pantalla
                Console.Clear();

                //opciones del menu
                Console.WriteLine("MENU Archivo de Texto con Flujo de Bytes");
                Console.WriteLine("........................................");
                Console.WriteLine("Nombre: " + auxnombre);
                Console.WriteLine("\na) Crear el Archivo.");
                Console.WriteLine("b) Leer el archivo.");
                Console.WriteLine("c) Salir del programa.");
                Console.Write("\nSeleccione una opcion: ");
                opcion = Console.ReadLine();

                //eleccion de opcion
                if (opcion == "a")
                {
                    //crear el archivo y escribir en el
                    //limpiar pantalla
                    Console.Clear();

                    //metodo para crear y escribir en archivo de texto
                    obj1.CrearArchivo();

                    Console.Write("\nPresione <enter> para regresar al menu...");
                    Console.ReadKey();
                }
                else if (opcion == "b")
                {
                    //leer el archivo

                    //limpiar pantalla
                    Console.Clear();

                    //metodo para leer archivo
                    obj1.LeerArchivo();

                    Console.Write("\nPresione <enter> para regresar al menu...");
                    Console.ReadKey();

                }
                else if (opcion == "c")
                {
                    //vacio
                    //cierre del programa
                }               
            } while (opcion != "c");
        }
    }
}
