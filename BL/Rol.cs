using DL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAlllinQ()
        {
            ML.Result resultRoles = new ML.Result();

            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())

                {
                    var query = (from Rol in context.Rols
                                 select Rol).ToList();

                    if (query != null)
                    {
                        resultRoles.Objects = new List<object>();

                        foreach (var objUsuario in query)
                        {
                            ML.Rol rol = new ML.Rol();

                      
                            rol = new ML.Rol();
                            rol.IdRol = (byte)objUsuario.IdRol;
                            rol.Nombre = objUsuario.Nombre;



                            resultRoles.Objects.Add(rol);
                        }
                        resultRoles.Correct = true;
                    }
                }
            }

            catch (Exception ex)
            {
                resultRoles.Correct = false;
                resultRoles.ErrorMessage = ex.Message;
            }

            return resultRoles;
        }
    }
}
