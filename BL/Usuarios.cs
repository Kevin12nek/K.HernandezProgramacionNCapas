using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuarios
    {
        public static ML.Result AddSPP(ML.Usuario usuarios)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    //SqlCommand cmd = new SqlCommand("EXEC AddSPP @UserName,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Email,@Password,@Sexo,@Telefono,@Celular,@FechaNacimiento,@CURP,@IdRol", conn);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UsuarioAdd";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", usuarios.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuarios.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuarios.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuarios.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Email", usuarios.Email);
                    cmd.Parameters.AddWithValue("@Password", usuarios.Password);
                    cmd.Parameters.AddWithValue("@Sexo", usuarios.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuarios.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuarios.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuarios.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@CURP", usuarios.CURP);
                    cmd.Parameters.AddWithValue("@IdRol", usuarios.Rol.IdRol);


                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un Error al insertar un Usuario" + usuarios.Nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        //UPDATE
        public static ML.Result UpdateSP(ML.Usuario usuarios)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    //SqlCommand cmd = new SqlCommand("EXEC UpdateSP @IdUsuario, @UserName,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Email,@Password,@Sexo,@Telefono,@Celular,@FechaNacimiento,@CURP,@IdRol", conn);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UsuarioUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //SqlCommand cmd = new SqlCommand("UPDATE [Usuario] SET [UserName] =@UserName [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno, [ApellidoMaterno] = @ApellidoMaterno, [Email] = @Email,[Password]=@Password,[Sexo] = @Sexo,[Telefono] =@Telefono,[Celular]=@Celular,[FechaNacimiento] = @FechaNacimiento,[Curp]=@Curp,[IdRol]=@IdRol WHERE IdUsuario = @IdUsuario", conn);
                    cmd.Parameters.AddWithValue("@IdUsuario", usuarios.IdUsuario);
                    cmd.Parameters.AddWithValue("@UserName", usuarios.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuarios.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuarios.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuarios.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Email", usuarios.Email);
                    cmd.Parameters.AddWithValue("@Password", usuarios.Password);
                    cmd.Parameters.AddWithValue("@Sexo", usuarios.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuarios.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuarios.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuarios.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@CURP", usuarios.CURP);
                    cmd.Parameters.AddWithValue("@IdRol", usuarios.Rol.IdRol);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un Error al insertar un Usuario" + usuarios.Nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //DELETE
        public static ML.Result DeleteSP(ML.Usuario usuarios)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    //SqlCommand cmd = new SqlCommand("EXEC DeleteSP @IdUsuario", conn);
                    // SqlCommand cmd = new SqlCommand("DELETE FROM [Usuarios] WHERE IdUsuarios = @IdUsuario", conn);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UsuarioDelete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", usuarios.IdUsuario);



                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró ningún registro con el ID";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //DATAREADER

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
            {
                SqlCommand cmd = new SqlCommand("SELECT [Nombre],[ApellidoPaterno],[ApellidoMaterno],[Edad],[Correo] FROM Usuarios", conn);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString() + "\t");
                    Console.WriteLine(reader[1].ToString() + "\t");
                    Console.WriteLine(reader[2].ToString() + "\t");
                    Console.WriteLine(reader[3].ToString() + "\t");
                    Console.WriteLine(reader[4].ToString() + "\t");
                }

            }

        }
        //DATAREADER FINAL

        //GETALL
        //public static ML.Result GetAllSP()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {

        //            //SqlCommand cmd = new SqlCommand("EXEC GetAllSP @IdUsuario", context);
        //            //SqlCommand cmd = new SqlCommand("EXEC GetAllSP");
        //            SqlCommand cmd = new SqlCommand();

        //            //cmd.CommandText = "SELECT [IdUsuarios],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Edad],[Correo] FROM Usuarios";

        //            cmd.Connection = context;
        //            cmd.CommandText = "UsuarioGetAll";
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlDataAdapter da = new SqlDataAdapter(cmd); //Puente Base de datos

        //            DataTable tablaUsuarios = new DataTable();///????

        //            da.Fill(tablaUsuarios);

        //            if (tablaUsuarios.Rows.Count > 0)
        //            {
        //                result.Objects = new List<object>();

        //                foreach (DataRow row in tablaUsuarios.Rows)
        //                {
        //                    ML.Usuario usuarios = new ML.Usuario();
        //                    usuarios.IdUsuario = byte.Parse(row[0].ToString());
        //                    usuarios.UserName = row[1].ToString();
        //                    usuarios.Nombre = row[2].ToString();
        //                    usuarios.ApellidoPaterno = row[3].ToString();
        //                    usuarios.ApellidoMaterno = row[4].ToString();
        //                    usuarios.Email = row[5].ToString();
        //                    usuarios.Password = row[6].ToString();
        //                    usuarios.Sexo = row[7].ToString();
        //                    usuarios.Telefono = row[8].ToString();
        //                    usuarios.Celular = row[9].ToString();
        //                    usuarios.FechaNacimiento = DateTime.Parse(row[10].ToString());
        //                    usuarios.CURP = row[11].ToString();
        //                    usuarios.Rol.IdRol = byte.Parse(row[12].ToString());

        //                    result.Objects.Add(usuarios);

        //                    result.Correct = true;

        //                }
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Tabla no tiene Informacion";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //        result.Correct = false;
        //    }
        //    return result;
        //}
        //GETALL

        //GETBYID
        //public static ML.Result GetByIdSP(int IdUsuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {

        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            //SqlCommand cmd = new SqlCommand("EXEC GetByIdSP @IdUsuario");

        //            //cmd.CommandText = "SELECT [IdUsuarios],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Edad],[Correo] FROM Usuarios WHERE IdUsuarios = @IdUsuarios";

        //            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

        //            cmd.Connection = context;
        //            cmd.CommandText = "UsuarioGetById";
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable tablaUsuarios = new DataTable();

        //            da.Fill(tablaUsuarios);

        //            if (tablaUsuarios.Rows.Count > 0)
        //            {
        //                DataRow row = tablaUsuarios.Rows[0];

        //                ML.Usuario usuarios = new ML.Usuario();
        //                usuarios.IdUsuario = byte.Parse(row[0].ToString());
        //                usuarios.UserName = row[1].ToString();
        //                usuarios.Nombre = row[2].ToString();
        //                usuarios.ApellidoPaterno = row[3].ToString();
        //                usuarios.ApellidoMaterno = row[4].ToString();
        //                usuarios.Email = row[5].ToString();
        //                usuarios.Password = row[6].ToString();
        //                usuarios.Sexo = row[7].ToString();
        //                usuarios.Telefono = row[8].ToString();
        //                usuarios.Celular = row[9].ToString();
        //                usuarios.FechaNacimiento = DateTime.Parse(row[10].ToString());
        //                usuarios.CURP = row[11].ToString();
        //                usuarios.Rol.IdRol = byte.Parse(row[12].ToString());

        //                result.Object = usuarios;

        //                result.Correct = true;

        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Tabla no contiene información";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //        result.Correct = false;
        //    }
        //    return result;
        //}
        //GETBYID


        ////ADD
        //public static ML.Result Add(ML.Usuarios usuarios)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand("INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Edad],[Correo]) VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Edad,@Correo)", conn);
        //            cmd.Parameters.AddWithValue("@Nombre", usuarios.Nombre);
        //            cmd.Parameters.AddWithValue("@ApellidoPaterno", usuarios.ApellidoPaterno);
        //            cmd.Parameters.AddWithValue("@ApellidoMaterno", usuarios.ApellidoMaterno);
        //            cmd.Parameters.AddWithValue("@Edad", usuarios.Edad);
        //            cmd.Parameters.AddWithValue("@Correo", usuarios.Correo);

        //            conn.Open();

        //            int rowsAffected = cmd.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Ocurrio un Error al insertar un Usuario" + usuarios.Nombre;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}

        //UPDATE
        //public static ML.Result Update(ML.Usuarios usuarios)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand("UPDATE [Usuarios] SET [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno, [ApellidoMaterno] = @ApellidoMaterno, [Edad] = @Edad WHERE IdUsuarios = @IdUsuario", conn);

        //            cmd.Parameters.AddWithValue("@IdUsuario", usuarios.IdUsuarios);

        //            cmd.Parameters.AddWithValue("@Nombre", usuarios.Nombre);
        //            cmd.Parameters.AddWithValue("@ApellidoPaterno", usuarios.ApellidoPaterno);
        //            cmd.Parameters.AddWithValue("@ApellidoMaterno", usuarios.ApellidoMaterno);
        //            cmd.Parameters.AddWithValue("@Edad", usuarios.Edad);
        //            cmd.Parameters.AddWithValue("@Correo", usuarios.Correo);

        //            conn.Open();

        //            int rowsAffected = cmd.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Ocurrio un Error al insertar un Usuario" + usuarios.Nombre;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}

        ////DELETE
        //public static ML.Result Delete(ML.Usuarios usuarios)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand("DELETE FROM [Usuarios] WHERE IdUsuarios = @IdUsuario", conn);
        //            cmd.Parameters.AddWithValue("@IdUsuario", usuarios.IdUsuarios);

        //            conn.Open();

        //            int rowsAffected = cmd.ExecuteNonQuery();

        //            if (rowsAffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se encontró ningún registro con el ID";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}

        ////GETALL
        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand();

        //            cmd.CommandText = "SELECT [IdUsuarios],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Edad],[Correo] FROM Usuarios";

        //            cmd.Connection = context;

        //            SqlDataAdapter da = new SqlDataAdapter(cmd); //Puente Base de datos y Programa ObtenerDatos
        //            DataTable tablaUsuarios = new DataTable();///????

        //            da.Fill(tablaUsuarios);

        //            if (tablaUsuarios.Rows.Count > 0)
        //            {
        //                result.Objects = new List<object>();

        //                foreach (DataRow row in tablaUsuarios.Rows)
        //                {
        //                    ML.Usuarios usuarios = new ML.Usuarios();
        //                    usuarios.IdUsuarios = byte.Parse(row[0].ToString());
        //                    usuarios.Nombre = row[1].ToString();
        //                    usuarios.ApellidoPaterno = row[2].ToString();
        //                    usuarios.ApellidoMaterno = row[3].ToString();
        //                    usuarios.Edad = byte.Parse(row[4].ToString());
        //                    usuarios.Correo = row[5].ToString();
        //                    result.Objects.Add(usuarios);

        //                    result.Correct = true;

        //                }
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Tabla no tiene Informacion";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //        result.Correct = false;
        //    }
        //    return result;
        //}
        ////GETALL
        ///

        //GETBYID
        //public static ML.Result GetById(byte IdUsuarios)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {

        //        using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.CommandText = "SELECT [IdUsuarios],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Edad],[Correo] FROM Usuarios WHERE IdUsuarios = @IdUsuarios";

        //            cmd.Parameters.AddWithValue("@IdUsuarios", IdUsuarios);

        //            cmd.Connection = context;

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable tablaUsuarios = new DataTable();

        //            da.Fill(tablaUsuarios);

        //            if (tablaUsuarios.Rows.Count > 0)
        //            {
        //                DataRow row = tablaUsuarios.Rows[0];

        //                ML.Usuarios usuarios = new ML.Usuarios();

        //                usuarios.IdUsuarios = byte.Parse(row[0].ToString());
        //                usuarios.Nombre = row[1].ToString();
        //                usuarios.ApellidoPaterno = row[2].ToString();
        //                usuarios.ApellidoMaterno = row[3].ToString();
        //                usuarios.Edad = byte.Parse(row[4].ToString());
        //                usuarios.Correo = row[5].ToString();
        //                result.Object = usuarios;

        //                result.Correct = true;

        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Tabla no contiene información";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //        result.Correct = false;
        //    }
        //    return result;
        //}
        ////GETBYID

        //PRUEBA
        //public static ML.Result AddEF(ML.Direccion direccion)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
        //        {
        //            ObjectParameter output = new ObjectParameter("IdDireccion", typeof(int));

        //            var resultQuery = context.DireccionAdd(direccion.Calle, direccion.NumeroExterior, direccion.NumeroInterior, direccion.Colonia.IdColonia, output);
        //            if (resultQuery > 1)
        //            {
        //                result.Correct = true;
        //                result.Object = Convert.ToInt32(output.Value);
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Ocurrio un error al momento de insertat la direccion";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //PRUEBA


        public static ML.Result AddEF(ML.Usuario usuarios)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                {

                    //MODIFY
                    ObjectParameter DireccionIdUsuario = new ObjectParameter("IdUsuario",typeof(int));
                    
                    //MODIFY

                    var resultQuery = context.UsuarioAdd(usuarios.UserName, usuarios.Nombre, usuarios.ApellidoPaterno, usuarios.ApellidoMaterno, usuarios.Email, 
                        usuarios.Password, usuarios.Sexo, usuarios.Telefono, usuarios.Celular,usuarios.FechaNacimiento,
                        usuarios.CURP, usuarios.Imagen, usuarios.Rol.IdRol, DireccionIdUsuario);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                        result.Object = Convert.ToInt32(DireccionIdUsuario.Value);
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo añadir el registro de usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        //UPDATE EF
        public static ML.Result UpdateEF(ML.Usuario usuarios)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                {

                    var resultQuery = context.UsuarioUpdate(usuarios.IdUsuario, usuarios.UserName, usuarios.Nombre, usuarios.ApellidoPaterno, usuarios.ApellidoMaterno, usuarios.Email,
                        usuarios.Password, usuarios.Sexo, usuarios.Telefono, usuarios.Celular, usuarios.FechaNacimiento,
                        usuarios.CURP, usuarios.Imagen, usuarios.Rol.IdRol, usuarios.Direccion.Calle,usuarios.Direccion.NumeroInterior,usuarios.Direccion.NumeroExterior,usuarios.Direccion.Colonia.IdColonia);


                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo añadir el registro de usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result DeleteEF(ML.Usuario usuarios)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                {
                    var resultQuery = context.UsuarioDelete(usuarios.IdUsuario);
                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo añadir el registrp de usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //GETALLEF
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                {
                    var Usuario = context.UsuarioGetAll().ToList();
                    result.Objects = new List<object>();

                    if (Usuario != null)
                    {
                        foreach (var obj in Usuario)
                        {
                            ML.Usuario usuarios = new ML.Usuario();

                            usuarios.IdUsuario = (byte)obj.IdUsuario;
                            usuarios.UserName = obj.UserName;
                            usuarios.Nombre = obj.Nombre;
                            usuarios.ApellidoPaterno = obj.ApellidoPaterno;
                            usuarios.ApellidoMaterno = obj.ApellidoMaterno;
                            usuarios.Email = obj.Email;
                            usuarios.Password = obj.Password;
                            usuarios.Sexo = obj.Sexo;
                            usuarios.Telefono = obj.Telefono;
                            usuarios.Celular = obj.Celular;
                            usuarios.FechaNacimiento = obj.FechaNacimiento.Value.ToString("ddMMyyyy");
                            usuarios.CURP = obj.CURP;
                            usuarios.Rol = new ML.Rol();
                            usuarios.Rol.IdRol = (byte)obj.IdRol;

                            result.Objects.Add(usuarios);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        //GETBYIDEF
        public static ML.Result GetByIdEF(byte IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                {

                    var objUsuario = context.UsuarioGetById(IdUsuario).FirstOrDefault();

                    if (objUsuario != null)
                    {

                        ML.Usuario usuarios = new ML.Usuario();

                        usuarios.IdUsuario = (byte)objUsuario.IdUsuario;
                        usuarios.UserName = objUsuario.UserName;
                        usuarios.Nombre = objUsuario.Nombre;
                        usuarios.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuarios.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuarios.Email = objUsuario.Email;
                        usuarios.Password = objUsuario.Password;
                        usuarios.Sexo = objUsuario.Sexo;
                        usuarios.Telefono = objUsuario.Telefono;
                        usuarios.Celular = objUsuario.Celular;
                        usuarios.FechaNacimiento = objUsuario.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                        usuarios.CURP = objUsuario.CURP;
                        usuarios.Imagen = objUsuario.Imagen;
                        usuarios.Rol = new ML.Rol();
                        usuarios.Rol.IdRol = (byte)objUsuario.IdRol;

                        usuarios.Direccion = new ML.Direccion();
                        usuarios.Direccion.Colonia = new ML.Colonia();
                        usuarios.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuarios.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuarios.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                        usuarios.Direccion.Calle = objUsuario.Calle;
                        usuarios.Direccion.NumeroExterior = objUsuario.NumeroExterior;
                        usuarios.Direccion.NumeroInterior = objUsuario.NumeroInterior;


                        usuarios.Direccion.Colonia.IdColonia = objUsuario.IdColonia;
                        usuarios.Direccion.Colonia.Nombre = objUsuario.NombreColonia;

                        usuarios.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio;
                        usuarios.Direccion.Colonia.Municipio.Nombre = objUsuario.NombreMunicipio;

                        usuarios.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado;
                        usuarios.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.NombreEstado;

                        usuarios.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais;
                        usuarios.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.NombrePais;







                        result.Object = usuarios;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Departamento";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        ////ADDLINQ
        //public static ML.Result AddLinQ(ML.Usuario usuarios)

        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
        //        {
        //            DL_EF.Usuario usuariolinq = new DL_EF.Usuario();

        //            usuariolinq.UserName = usuarios.UserName;
        //            usuariolinq.Nombre = usuarios.Nombre;
        //            usuariolinq.ApellidoPaterno = usuarios.ApellidoPaterno;
        //            usuariolinq.ApellidoMaterno = usuarios.ApellidoMaterno;
        //            usuariolinq.Email = usuarios.Email;
        //            usuariolinq.Password = usuarios.Password;
        //            usuariolinq.Sexo = usuarios.Sexo;
        //            usuariolinq.Telefono = usuarios.Telefono;
        //            usuariolinq.Celular = usuarios.Celular;
        //            usuariolinq.FechaNacimiento = usuarios.FechaNacimiento.ToString();
        //            usuariolinq.CURP = usuarios.CURP;


        //            usuariolinq.IdRol = usuarios.Rol.IdRol;
        //            context.Usuarios.Add(usuariolinq);
        //            int RowAffected = context.SaveChanges();

        //            if (RowAffected > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "El registro no se pudo insertar";
        //            }

        //            context.SaveChanges();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;

        //}

        //UPDATELINQ

        public static ML.Result UpdateLinQ(ML.Usuario usuarios)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuariolinq = new DL_EF.Usuario();

                    var query = (from usuariol in context.Usuarios

                                 //join Direccion in context.Direccions on usuariol equals Direccion.IdDireccion

                                 where usuariol.IdUsuario == usuarios.IdUsuario
                                 select usuariol).Single();

                    if (usuariolinq != null)
                    {
                        usuariolinq.UserName = usuarios.UserName;
                        usuariolinq.Nombre = usuarios.Nombre;
                        usuariolinq.ApellidoPaterno = usuarios.ApellidoPaterno;
                        usuariolinq.ApellidoMaterno = usuarios.ApellidoMaterno;
                        usuariolinq.Email = usuarios.Email;
                        usuariolinq.Password = usuarios.Password;
                        usuariolinq.Sexo = usuarios.Sexo;
                        usuariolinq.Telefono = usuarios.Telefono;
                        usuariolinq.Celular = usuarios.Celular;
                        usuariolinq.FechaNacimiento = Convert.ToDateTime(usuarios.FechaNacimiento);
                        usuariolinq.CURP = usuarios.CURP;
                        usuariolinq.IdRol = usuarios.Rol.IdRol;
                      
                    }

                    context.Usuarios.Add(usuariolinq);
                    int RowAffected = context.SaveChanges();

                    if (RowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El registro no se pudo insertar";
                    }

                    context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        //DELETELINQ

        public static ML.Result DeletelinQ(ML.Usuario usuarios)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())

                {
                    var query = (from usuariolinq in context.Usuarios
                                 where usuariolinq.IdUsuario == usuarios.IdUsuario
                                 select usuariolinq).SingleOrDefault();

                    if (query != null)
                    {
                        context.Usuarios.Remove(query);
                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se econtro el registro para borrar";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        //GETALLLINQ

        //DELETELINQ

        public static ML.Result GetAlllinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())

                {
                    //var query = (from usuariolinq in context.Usuarios
                    //             select usuariolinq).ToList();

                    var query = (from objUsuario in context.Usuarios
                                 join Rol in context.Rols on objUsuario.IdRol equals Rol.IdRol
                                 select new { objUsuario, RolName = Rol.Nombre });


                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var objUsuario in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = (byte)objUsuario.objUsuario.IdUsuario;
                            usuario.Nombre = objUsuario.objUsuario.Nombre;
                            usuario.UserName = objUsuario.objUsuario.UserName;
                            usuario.ApellidoPaterno = objUsuario.objUsuario.ApellidoPaterno;
                            usuario.ApellidoMaterno = objUsuario.objUsuario.ApellidoMaterno;
                            usuario.Email = objUsuario.objUsuario.Email;
                            usuario.Password = objUsuario.objUsuario.Password;
                            usuario.Sexo = objUsuario.objUsuario.Sexo;
                            usuario.Telefono = objUsuario.objUsuario.Telefono;
                            usuario.Celular = objUsuario.objUsuario.Celular;
                            usuario.FechaNacimiento = objUsuario.objUsuario.FechaNacimiento.Value.ToString("dd-MM-yyyy");
                            usuario.CURP  = objUsuario.objUsuario.CURP;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (byte)objUsuario.objUsuario.IdRol.Value;
                            usuario.Rol.Nombre = objUsuario.RolName;
                            usuario.Imagen = objUsuario.objUsuario.Imagen;


                           



                            //usuario.Rol.IdRol = (objUsuario.IdRol != null) ? byte.Parse(objUsuario.IdRol.Value.ToString()) : byte.Parse("0");

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se econtro el registro para borrar";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        //GETALLLINQ
        public static ML.Result GetByIdlinQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())

                {
                    var query = (from usuariolinq in context.Usuarios
                                 where usuariolinq.IdUsuario == IdUsuario
                                 select usuariolinq).Single();

                    //result.Object = new List<Object>();

                    if (query != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = (byte)query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.FechaNacimiento = query.FechaNacimiento.Value.ToString("ddMMyyyy");
                        usuario.CURP = query.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = (byte)query.IdRol.Value;

                        result.Object = usuario;
                        result.Correct = true;

                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro para borrar";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}











