using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {

        public static ML.Result Add(ML.Direccion direccion, int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                {
                    var resultQuery = context.DireccionAdd(direccion.Calle, direccion.NumeroInterior, direccion.NumeroExterior, direccion.Colonia.IdColonia, IdUsuario);
                    result.Objects = new List<object>();

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar la direccion";
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
