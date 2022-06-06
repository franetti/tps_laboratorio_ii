using System;
using System.IO;
using static System.Environment;

namespace Servicios
{
    public class Archivos
    {
        public static void ExportarListaTxt( string texto) 
        {
            string path = GetFolderPath(SpecialFolder.Desktop) + @"\ServicioTecnico.txt";            
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(texto);
                }                
            }
            catch (UnauthorizedAccessException ex) 
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public static string ImportarListaTxt()
        {
            string path = GetFolderPath(SpecialFolder.Desktop) + @"\ServicioTecnico.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path)) 
                { 
                    return sr.ReadToEnd();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
