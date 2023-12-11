using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {

            public static ML.Result GetByIdEstado(int IdEstado)
            {
                ML.Result result = new ML.Result();

                try
                {
                    using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                    {
                        var MunicipioList = context.MunicipioGetbyIdEstado(IdEstado).ToList();
                        result.Objects = new List<object>();

                        if (MunicipioList != null)
                        {
                            foreach (var obj in MunicipioList)
                            {
                                ML.Municipio municipio = new ML.Municipio();

                                municipio.IdMunicipio = obj.IdMunicipio;
                                municipio.Nombre = obj.Nombre;


                                result.Objects.Add(municipio);
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
