using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*------------------------------------
             * Ejercicio C# Para no Programadores
             ------------------------------------*/

            /* 
             * Realizar una aplicación de consola codificada en C#, ingresando por teclado los datos de la inflación anual detallada por mes
             * (enero a diciembre). Solo se pueden ingresar de una vez 12 números decimales separados por espacios.
             * Informar por consola: La inflación total, Promedio de Inflación, La maxima/minima inflación y en que mes ocurrió
             * Informar error de ingreso de datos
            */

            Console.WriteLine("***************************\n Calculadora de inflación \n***************************\n");

            Console.WriteLine("Ingrese en orden (Enero, Febrero, ..., Diciembre), los valores numericos correspondientes\na los porcentajes de inflacion de cada mes separados por un espacio.");

            
            string[] entrada = Console.ReadLine().Split(' ');

            while (VerificarValores(entrada) == false)
            {
                entrada = Console.ReadLine().Split(' ');
            }
            double[] inflaciones = GenerarArreglo(entrada);

            double total = CalcularInflacionTotal(inflaciones);
            Console.WriteLine("La Inflacion total en el año es de: {0}%", total);
            getPromedioInflacion(inflaciones);
            getMax_Min(inflaciones);

            Console.WriteLine("***************************\n Fin del Programa \n***************************");


            Console.ReadKey();

        }



        static bool VerificarValores(string[] a) 
        {
            bool verificacion;
            string[] valores = a;
            if (valores.Length == 12)
            {
                if (GenerarArreglo(valores) == null)
                {
                    verificacion = false;
                    Console.WriteLine(" ---- Los datos Ingresados no son correctos ---- ");
                }
                else verificacion = true;
            }
            else 
            {
                Console.WriteLine(" ---- Debe ingresar 12 valores númericos ---- ");
                verificacion = false;
            }
            return verificacion;
        }
        static double[] GenerarArreglo(string[] a)
        {
            string[] valores = a;
            double[] arreglo = new double[valores.Length];
            for (int i = 0; i < valores.Length; i++)
            {
                try { arreglo[i] = double.Parse(valores[i]); }
                catch { return null ; }
            }
            return arreglo;
        }

        static double CalcularInflacionTotal(double[] a ) 
        {
            double[] inflaciones = a;
            double total = 0;

            for (int i = 0; i < inflaciones.Length; i++) total += inflaciones[i];
            return total;
        } 

        static void getPromedioInflacion(double[] a)
        {
            double total = CalcularInflacionTotal(a);
            double promedio = total / 12;
            
            Console.WriteLine("El promedio de inflación mensual es de: {0}%", promedio);
        } 

        static void getMax_Min (double[] a) 
        {
            double[] inflaciones = a;
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            string mesMinimo = meses[0];
            string mesMaximo = meses[0];
            double minimo = inflaciones[0];
            double maximo = inflaciones[0];
            for (int i = 0; i < inflaciones.Length; i++)
            {
                double valor = inflaciones[i];
                if (valor < minimo) 
                { 
                    minimo = valor; 
                    mesMinimo = meses[i]; 
                }
                if (valor > maximo) 
                { 
                    maximo = valor;
                    mesMaximo = meses[i];
                }
            }

            Console.WriteLine("El valor minimo de inflacion fue de {0}% en el mes de {1}", minimo, mesMinimo);
            Console.WriteLine("El valor maximo de inflacion fue de {0}% en el mes de {1}", maximo, mesMaximo);

        }
    }
}
