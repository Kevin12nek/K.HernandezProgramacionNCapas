using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuarios
    {



       // public static void AddEF()
        //public static void Add()
        //{
        //    ML.Usuario usuarios = new ML.Usuario(); 

        //    Console.WriteLine("Ingrese el UserName de la Persona");
        //    usuarios.UserName = Console.ReadLine();

        //    Console.WriteLine("Ingrese el nombre de la Persona");
        //    usuarios.Nombre = Console.ReadLine();

        //    Console.WriteLine("Ingrese Apellido Paterno");
        //    usuarios.ApellidoPaterno = Console.ReadLine();

        //    Console.WriteLine("Ingresa Apellido Materno");
        //    usuarios.ApellidoMaterno = Console.ReadLine();

        //    Console.WriteLine("Ingreses El Email del Usuario");
        //    usuarios.Email = (Console.ReadLine());

        //    Console.WriteLine("Ingresa el Password");
        //    usuarios.Password = Console.ReadLine();

        //    Console.WriteLine("Ingrese el Sexo de la Persona");
        //    usuarios.Sexo = Console.ReadLine();

        //    Console.WriteLine("Ingrese el Telefono de la Persona");
        //    usuarios.Telefono = Console.ReadLine();

        //    Console.WriteLine("Ingrese el Celular de la Persona");
        //    usuarios.Celular = Console.ReadLine();

        //    Console.WriteLine("Ingrese Fecha de Nacimiento de la Persona");
        //    usuarios.FechaNacimiento = DateTime.Parse(Console.ReadLine());

        //    Console.WriteLine("Ingrese su CURP: ");
        //    usuarios.CURP = Console.ReadLine();

        //    Console.WriteLine("Ingrese El IdRol");
        //    usuarios.Rol = new ML.Rol();
        //    usuarios.Rol.IdRol = byte.Parse(Console.ReadLine());

        //    //ML.Result result = BL.Usuarios.AddEF(usuarios); EFEF
        //    ML.Result result = BL.Usuarios.AddLinQ(usuarios);
        //    if (result.Correct)
        //    {
        //        Console.WriteLine("El Usuario se inserto Correctamente");
        //    }
        //    else 
        //    {
        //        Console.WriteLine("Ocurrio un error al insertar el Usuario" + result.ErrorMessage);
        //        Console.WriteLine(result.Ex);
        //    }

        //}

        //UPDATE
        //public static void Update() 
        //{
        //    ML.Usuario usuarios = new ML.Usuario();

        //    //HELP
        //    Console.WriteLine("Ingrese el ID del Usuario a Actualizar:");

        //    usuarios.IdUsuario = byte.Parse(Console.ReadLine());
        //    //HELP


        //    Console.WriteLine("Ingrese el UserName de la Persona");
        //    usuarios.UserName = Console.ReadLine();

        //    Console.WriteLine("Ingrese el nombre de la Persona");
        //    usuarios.Nombre = Console.ReadLine();

        //    Console.WriteLine("Ingrese Apellido Paterno");
        //    usuarios.ApellidoPaterno = Console.ReadLine();

        //    Console.WriteLine("Ingresa Apellido Materno");
        //    usuarios.ApellidoMaterno = Console.ReadLine();

        //    Console.WriteLine("Ingreses El Email del Usuario");
        //    usuarios.Email = (Console.ReadLine());

        //    Console.WriteLine("Ingresa el Password");
        //    usuarios.Password = Console.ReadLine();

        //    Console.WriteLine("Ingrese el Sexo de la Persona");
        //    usuarios.Sexo = Console.ReadLine();

        //    Console.WriteLine("Ingrese el Telefono de la Persona");
        //    usuarios.Telefono = Console.ReadLine();

        //    Console.WriteLine("Ingrese el Celular de la Persona");
        //    usuarios.Celular = Console.ReadLine();

        //    Console.WriteLine("Ingrese Fecha de Nacimiento de la Persona");
        //    usuarios.FechaNacimiento = DateTime.Parse(Console.ReadLine());

        //    Console.WriteLine("Ingrese su CURP: ");
        //    usuarios.CURP = Console.ReadLine();

        //    Console.WriteLine("Ingrese El IdRol");
        //    usuarios.Rol = new ML.Rol();
        //    usuarios.Rol.IdRol = byte.Parse(Console.ReadLine());


        //    ML.Result result = BL.Usuarios.UpdateLinQ(usuarios);

        //    if (result.Correct)
        //    {
        //        Console.WriteLine("El Usuario se Actualizo Correctamente");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ocurrio un error al Actualizar al Usuario" + result.ErrorMessage);
        //        Console.WriteLine(result.Ex);
        //    }
        //}


        //DELETE
        public static void Delete() 
        {
            ML.Usuario usuarios = new ML.Usuario();

            Console.WriteLine("Ingrese el ID del Usuario a Eliminar:");

            usuarios.IdUsuario = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuarios.DeleteEF(usuarios);
            ML.Result result = BL.Usuarios.DeletelinQ(usuarios);

            if (result.Correct)
            {
                Console.WriteLine("El Usuario se Eliminó Correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al Eliminar al Usuario: " + result.ErrorMessage);
                Console.WriteLine(result.Ex);
            }
        }

        public static void Read()
        {
            BL.Usuarios.Read();
        }

        //GETALL
        public static void GetAll()
        {

            //RESULT
            ML.Result result = BL.Usuarios.GetAlllinQ();

            if (result.Correct)
            {
                foreach (ML.Usuario usuarios in result.Objects) //N
                {
                    Console.WriteLine(usuarios.IdUsuario);
                    Console.WriteLine(usuarios.UserName);
                    Console.WriteLine(usuarios.Nombre);
                    Console.WriteLine(usuarios.ApellidoPaterno);
                    Console.WriteLine(usuarios.ApellidoMaterno);
                    Console.WriteLine(usuarios.Email);
                    Console.WriteLine(usuarios.Password);
                    Console.WriteLine(usuarios.Sexo);
                    Console.WriteLine(usuarios.Telefono);
                    Console.WriteLine(usuarios.Celular);
                    Console.WriteLine(usuarios.FechaNacimiento);
                    Console.WriteLine(usuarios.CURP);
                    Console.WriteLine(usuarios.Rol.IdRol);
                    Console.WriteLine(usuarios.Imagen);

                }
            }
            else
            {
                Console.WriteLine("No se encontraron registros en la tabla Usuario. Detalle: " + result.ErrorMessage);

            }



        }

        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el Id del Usuario que desea obtener");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            ML.Result result = BL.Usuarios.GetByIdlinQ(usuario.IdUsuario);

            if (result.Correct)
            {
                ML.Usuario usuarios = (ML.Usuario)result.Object;  //1 

                Console.WriteLine(usuarios.IdUsuario);
                Console.WriteLine(usuarios.UserName);
                Console.WriteLine(usuarios.Nombre);
                Console.WriteLine(usuarios.ApellidoPaterno);
                Console.WriteLine(usuarios.ApellidoMaterno);
                Console.WriteLine(usuarios.Email);
                Console.WriteLine(usuarios.Password);
                Console.WriteLine(usuarios.Sexo);
                Console.WriteLine(usuarios.Telefono);
                Console.WriteLine(usuarios.Celular);
                Console.WriteLine(usuarios.FechaNacimiento);
                Console.WriteLine(usuarios.CURP);
                Console.WriteLine(usuarios.Rol.IdRol);
            }
            else
            {
                Console.WriteLine("No se encontraron registros en la tabla Usuario. Detalle: " + result.ErrorMessage);
            }
        }

     

        
    }

}
