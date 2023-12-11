using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {

        public static void suma(int numero1, int numero2, out int result)
        {
            result = numero1 + numero2;
        }

        public static void Resta(int numero1, int numero2, out int result)
        {
            result = numero1 - numero2;
        }

        public static void Multiplicacion(int numero1, int numero2, out int result)
        {
            result = numero1 * numero2;
        }

        public static void Division(int numero1, int numero2, out int result)
        {
            result = numero1 * numero2;
        }



        static void Main(string[] args)
        {

            int numero1 = 10;
            int numero2 = 2;
            int result;

            Console.WriteLine("RESULTADO OPERACIONES");

            suma(numero1, numero2, out result);
            Console.WriteLine("El resultado de la Suma es: " + result);

            Resta(numero1, numero2, out result);
            Console.WriteLine("El resultado de la Resta es: " + result);

            Multiplicacion(numero1, numero2, out result);
            Console.WriteLine("El resultado de la Multiplicacion es: " + result);

            Division(numero1, numero2, out result);
            Console.WriteLine("El resultado de la Division es: " + result);

            int menu = 0;
            do
            {
                Console.WriteLine("-------------------MENU-----------------------\n" +
                "[0] SALIR\n" +
                    "[1] Agregar Un Usuario\n" +
                    "[2] Actualizar un Usuario\n" +
                    "[3] Eliminar Un Usuario\n" +
                    "[4] Obtener todos los Usuarios\n" +
                    "[5] Consultar datos de un Usuario en específico");

                Console.WriteLine("Digite la opcion que desea: ");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    //case 1:
                    //    //PL.Usuarios.AddEF();
                    //    PL.Usuarios.Add();
                    //    break;
                    //case 2:
                    //    //PL.Usuarios.UpdateEF();
                    //    PL.Usuarios.Update();
                    //    break;
                    case 3:
                        PL.Usuarios.Delete();
                        break;
                    case 4:
                        PL.Usuarios.GetAll();
                        break;
                    case 5:
                        PL.Usuarios.GetById();
                        break;
                
                }
                Console.WriteLine("Desea Cumplir otra accion: \n" + "Digite [1] si desea realizar otra accion de lo contrario meta [0]");
                menu = int.Parse(Console.ReadLine());
            } while (menu == 1);

        }


    }
}
