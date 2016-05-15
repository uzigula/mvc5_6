using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMusica.Logica
{
    public class ReporteSimple
    {
        private const string ruta = @"C:\Downloads";
        public string Reporte()
        {
            HSSFWorkbook libro = new HSSFWorkbook();
            var hoja = libro.CreateSheet("Ejemplo reporte");
            var fila = hoja.CreateRow(1);
            var celda = fila.CreateCell(1);

            celda.SetCellValue("Reporte de Ejemplo");

            for (var i=3; i <= 6; i++)
            {
                var filan = hoja.CreateRow(i);
                var celda1 = filan.CreateCell(1);
                celda1
              .SetCellValue($"Presentacion del Proyecto de Final de Curso Alumno {i}");
                celda1.CellStyle.WrapText = true;
                var celda2 = filan.CreateCell(2);
                celda2.SetCellValue(
                    DateTime
                    .Now
                    .AddDays(i)
                    .ToLongDateString());
            }
            var nombreArchivo = NombreArchivo();
            var fileStream = new FileStream(
                nombreArchivo, 
                FileMode.CreateNew
                );
            libro.Write(fileStream);
            fileStream.Flush();
            fileStream.Close();
            return nombreArchivo;
        }

        public ArchivoDescarga TraerArchivo(string tipoArchivo)
        {
            var files = Directory.GetFiles(ruta, $"*.{tipoArchivo}");
                return new ArchivoDescarga(files[0]);

        }

        private string NombreArchivo()
        {
            var ruta = Path.GetTempFileName();
            File.Delete(ruta);
            return Path.ChangeExtension(ruta, "xls");
        }
    }


    public class ArchivoDescarga
    {
        public ArchivoDescarga(string fileName)
        {
            Ruta = fileName;
            Nombre = Path.GetFileName(Ruta);
        }

        public string Nombre { get; private set; }
        public string Ruta { get; private set; }
    }
}
