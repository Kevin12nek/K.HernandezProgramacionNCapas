using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
                public static ML.Result GetByIdMunicipio(int IdMunicipio)
                {
                    ML.Result result = new ML.Result();

                    try
                    {
                        using (DL_EF.KHernandezProgramacionNCapasEntities context = new DL_EF.KHernandezProgramacionNCapasEntities())
                        {
                            var ColoniaList = context.ColoniaGetbyIdMunicipio(IdMunicipio).ToList();
                            result.Objects = new List<object>();

                            if (ColoniaList != null)
                            {
                                foreach (var obj in ColoniaList)
                                {
                                    ML.Colonia colonia = new ML.Colonia();

                                    colonia.IdColonia = obj.IdColonia;
                                    colonia.Nombre = obj.Nombre;


                                    result.Objects.Add(colonia);
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

