using BL;
using ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {



            ML.Result result = BL.Usuarios.GetAlllinQ();
            ML.Usuario usuario = new ML.Usuario();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(usuario);



        }

        //JSRONRESULT

        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects);
        }


        public JsonResult MunicipioGetbyIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects);
        }

        public JsonResult ColoniaGetbyIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects);
        }

        //JSRONRESULT

        public ActionResult Roles(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            return View(usuario);

        }

        [HttpGet]//MOSTRAR EL FORMULARIO
        public ActionResult Form(int? IdUsuario)
        {


            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            ML.Result resultRoles = BL.Rol.GetAlllinQ();
            usuario.Rol.Roles = resultRoles.Objects;

            ML.Result resultPaises = BL.Pais.GetAlllinQ();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

            //ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(2);
            //usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;




            if (IdUsuario == null)
            {
                return View(usuario);

            }
            else
            {
                ML.Result result = BL.Usuarios.GetByIdEF((byte)IdUsuario);


                usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                usuario.UserName = ((ML.Usuario)result.Object).UserName;
                usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                usuario.Email = ((ML.Usuario)result.Object).Email;
                usuario.Password = ((ML.Usuario)result.Object).Password;
                usuario.Sexo = ((ML.Usuario)result.Object).Sexo;
                usuario.Telefono = ((ML.Usuario)result.Object).Telefono;
                usuario.Celular = ((ML.Usuario)result.Object).Celular;
                usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                usuario.CURP = ((ML.Usuario)result.Object).CURP;
                usuario.Imagen = ((ML.Usuario)result.Object).Imagen;
                usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;


                usuario.Direccion.Calle = ((ML.Usuario)result.Object).Direccion.Calle;
                usuario.Direccion.NumeroInterior = ((ML.Usuario)result.Object).Direccion.NumeroInterior;
                usuario.Direccion.NumeroExterior = ((ML.Usuario)result.Object).Direccion.NumeroExterior;

                usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.Pais.IdPais;
                usuario.Direccion.Colonia.Municipio.Estado.IdEstado = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.IdEstado;
                usuario.Direccion.Colonia.Municipio.IdMunicipio = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.IdMunicipio;
                usuario.Direccion.Colonia.IdColonia = ((ML.Usuario)result.Object).Direccion.Colonia.IdColonia;




                usuario = FillDropDownList(usuario);


                return View(usuario);

            }
        }


        [HttpPost]//RECIBIR LA INFORMACION DEL FORMULARIO PARA ADD/UPDATE
        public ActionResult Form(ML.Usuario usuario, HttpPostedFileBase imgUsuario)
        {
            if (ModelState.IsValid)
            {



                if (imgUsuario != null)
                {
                    usuario.Imagen = this.ConvertToBytes(imgUsuario);
                }


                if (usuario.IdUsuario == 0)
                {
                    ML.Result result = BL.Usuarios.AddEF(usuario);
                    if (result.Correct)
                    {
                        //ADDDIREC
                        ML.Result resultdireccion = BL.Direccion.Add(usuario.Direccion, (int)result.Object);
                        if (resultdireccion.Correct)
                        {
                            ViewBag.Message = "Se ha ingresado correctamente el usuario";

                        }
                    }
                    else
                    {
                        ViewBag.Message = "No se ha ingresado correctamente el usuario. Error:" + result.ErrorMessage;

                    }
                }
                else
                {
                    ML.Result result = BL.Usuarios.UpdateEF(usuario);
                    if (result.Correct)

                    {
                        ViewBag.Message = "Se ha actualizado correctamente el Usuario";
                    }
                    else
                    {

                        ViewBag.Message = "No se pudo actualizar correctamente el Usuario" + result.ErrorMessage;

                    }
                }
                return PartialView("Modal");
            }
            //observa
            else
            {
                usuario = FillDropDownList(usuario);
                return View(usuario);
            }

        }

        private ML.Usuario FillDropDownList(ML.Usuario usuario) //Este método llena las listas: Pais, Estados, Municipios, Colonias y Roles
        {
            ML.Result resultPaises = new ML.Result();
            resultPaises = BL.Pais.GetAlllinQ();


            ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
            ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
            ML.Result resultColonias = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);


            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;
            usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
            usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
            usuario.Direccion.Colonia.Colonias = resultColonias.Objects;



            ML.Result resultRoles = BL.Rol.GetAlllinQ();
            usuario.Rol.Roles = resultRoles.Objects;


            return usuario;
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public ActionResult Delete(byte IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;

            ML.Result result = BL.Usuarios.DeletelinQ(usuario);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado correctamente el Usuario";
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el usuario. Error:" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }


    }

}
