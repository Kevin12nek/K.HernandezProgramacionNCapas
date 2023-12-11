using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                {
                    var EstadoList = context.EstadoGetbyIdPais(IdPais).ToList();
                    result.Objects = new List<object>();

                    if (EstadoList != null)
                    {
                        foreach (var obj in EstadoList)
                        {
                            ML.Estado estado = new ML.Estado();

                            estado.IdEstado = obj.IdEstado;
                            estado.Nombre = obj.Nombre;


                            result.Objects.Add(estado);
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
    }
}
