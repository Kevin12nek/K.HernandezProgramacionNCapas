using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAlllinQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())

                {

                    var query = (from painslinq in context.Pais
                                 select painslinq).ToList();


                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var objPais in query)
                        {
                            ML.Pais pais = new ML.Pais();

                            pais.IdPais = (byte)objPais.IdPais;
                            pais.Nombre = objPais.Nombre;
                           
                            result.Objects.Add(pais);
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
    }
}
