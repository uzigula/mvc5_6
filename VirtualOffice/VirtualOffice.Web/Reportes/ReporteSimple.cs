using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace VirtualOffice.Web.Reportes
{
    public class SimpleReport<TDataSource> : IDisposable
    {
        const int MaximumNumberOfRowsPerSheet = 65500;
        const int MaximumSheetNameLength = 25;
        protected HSSFWorkbook Workbook { get; set; }

        public SimpleReport()
        {
            this.Workbook = new HSSFWorkbook();
        }

        protected string EscapeSheetName(string sheetName)
        {
            var escapedSheetName = sheetName
                                        .Replace("/", "-")
                                        .Replace("\\", " ")
                                        .Replace("?", string.Empty)
                                        .Replace("*", string.Empty)
                                        .Replace("[", string.Empty)
                                        .Replace("]", string.Empty)
                                        .Replace(":", string.Empty);

            if (escapedSheetName.Length > MaximumSheetNameLength)
                escapedSheetName = escapedSheetName.Substring(0, MaximumSheetNameLength);

            return escapedSheetName;
        }

        protected ISheet CreateExportDataTableSheetAndHeaderRow(DataTable exportData, string sheetName, ICellStyle headerRowStyle)
        {
            var sheet = this.Workbook.CreateSheet(EscapeSheetName(sheetName));

            // Create the header row
            var row = sheet.CreateRow(0);

            for (var colIndex = 0; colIndex < exportData.Columns.Count; colIndex++)
            {
                var cell = row.CreateCell(colIndex);
                cell.SetCellValue(exportData.Columns[colIndex].ColumnName);

                if (headerRowStyle != null)
                    cell.CellStyle = headerRowStyle;
            }

            return sheet;
        }

        public void ExportDataTableToWorkbook(IList<TDataSource> data, Dictionary<string, string> columns, string sheetName)
        {
            // Create the header row cell style
            var exportData = CreateDataSet(data, columns);
            var headerLabelCellStyle = this.Workbook.CreateCellStyle();
            headerLabelCellStyle.BorderBottom = BorderStyle.Thin;
            var headerLabelFont = this.Workbook.CreateFont();
            headerLabelFont.Boldweight = (short)FontBoldWeight.Bold;
            headerLabelCellStyle.SetFont(headerLabelFont);

            var sheet = CreateExportDataTableSheetAndHeaderRow(exportData, sheetName, headerLabelCellStyle);
            var currentNPOIRowIndex = 1;
            var sheetCount = 1;

            for (var rowIndex = 0; rowIndex < exportData.Rows.Count; rowIndex++)
            {
                if (currentNPOIRowIndex >= MaximumNumberOfRowsPerSheet)
                {
                    sheetCount++;
                    currentNPOIRowIndex = 1;

                    sheet = CreateExportDataTableSheetAndHeaderRow(exportData,
                                                                   sheetName + " - " + sheetCount,
                                                                   headerLabelCellStyle);
                }

                var row = sheet.CreateRow(currentNPOIRowIndex++);

                for (var colIndex = 0; colIndex < exportData.Columns.Count; colIndex++)
                {
                    var cell = row.CreateCell(colIndex);
                    cell.SetCellValue(exportData.Rows[rowIndex][colIndex].ToString());
                }
            }
        }

        private DataTable CreateDataSet(IList<TDataSource> dataList, Dictionary<string, string> columns)
        {
            var dataTable = new DataTable("ExcelReport");

            var myType = typeof(TDataSource);

            foreach (var col in columns)
            {
                var propType = myType.GetProperty(col.Key).PropertyType;
                var dataColumn = new DataColumn(col.Value);
                this.SetColumnType(dataColumn, propType);
                dataTable.Columns.Add(dataColumn);
            }

            var set = new DataSet("Reports");
            set.Tables.Add(dataTable);

            this.PopulateDataTable(dataList, dataTable, columns);

            return dataTable;
        }

        private void SetColumnType(DataColumn column, Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
            {
                column.DataType = Nullable.GetUnderlyingType(type);
                return;
            }

            column.DataType = type;
        }

        private void PopulateDataTable(IList<TDataSource> data, DataTable dataTable, Dictionary<string, string> columns)
        {
            foreach (var item in data)
            {
                var dataRow = dataTable.NewRow();
                foreach (var col in columns)
                {
                    var val = item.GetType().GetProperty(col.Key).GetValue(item, null);
                    this.SetRowValue(dataRow, col.Value, val);
                }

                dataTable.Rows.Add(dataRow);
            }
        }

        private void SetRowValue(DataRow row, string map, object val)
        {
            if (val == null) return;
            row[map] = val;
        }


        public byte[] GetBytes()
        {
            using (var buffer = new MemoryStream())
            {
                this.Workbook.Write(buffer);
                return buffer.GetBuffer();
            }
        }


        public void Dispose()
        {
            if (this.Workbook != null)
                this.Workbook = null;
        }
    }
}