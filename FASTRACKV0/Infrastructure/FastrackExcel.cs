using FASTrack.ViewModel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Linq;

/// <summary>
/// 
/// </summary>
namespace FASTrack.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class ExportExcel
    {
        private const string nameDashboard = "Dashboard";
        private string _pathRoot = String.Empty;
        private object misValue = System.Reflection.Missing.Value;

        private Excel.Application excelApp;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheetDashboard;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathRoot"></param>
        public ExportExcel(string pathRoot)
        {
            try
            {
                _pathRoot = pathRoot;
                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Add(Type.Missing);
                //
                workSheetDashboard = workBook.Sheets.Add(misValue, misValue, 1, misValue);
                workSheetDashboard.Name = nameDashboard;

                //Delete sheet default
                for (int i = excelApp.ActiveWorkbook.Worksheets.Count; i > 0; i--)
                {
                    Excel.Worksheet wkSheet = (Excel.Worksheet)excelApp.ActiveWorkbook.Worksheets[i];
                    if (wkSheet.Name.Contains("Sheet"))
                    {
                        wkSheet.Delete();
                    }
                }
                excelApp.Calculation = Excel.XlCalculation.xlCalculationManual;
                excelApp.Application.ScreenUpdating = false;
                excelApp.DisplayAlerts = false;
            }
            catch (Exception ex)
            {
                NAR(workSheetDashboard);
                NAR(workBook);
                excelApp.Quit();
                NAR(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();

                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateHeader()
        {
            var cell1 = workSheetDashboard.Cells[2, 2];
            var cell2 = workSheetDashboard.Cells[2, 16];
            Excel.Range rangeHeader = workSheetDashboard.Range[cell1, cell2] as Excel.Range;
            FormatHeader(rangeHeader, nameDashboard.ToUpper());
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateTitle()
        {
            var cell1 = workSheetDashboard.Cells[4, 2];
            var cell2 = workSheetDashboard.Cells[4, 16];
            Excel.Range rangeTitle = workSheetDashboard.Range[cell1, cell2] as Excel.Range;
            WriteTitle(rangeTitle);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateContent()
        {
            WriteContent(workSheetDashboard);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <param name="title"></param>
        private void FormatHeader(Excel.Range range, string title)
        {
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.Value2 = title;
            range.RowHeight = 35;
            range.Font.Name = "Arial Unicode MS";
            range.Font.Bold = true;
            range.Font.Size = 20;
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        private void WriteTitle(Excel.Range range)
        {
            int startCol = 1;
            int startRow = 1;

            range.EntireRow.AutoFit();
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range.Font.Bold = true;
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            //
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "FA Number";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 10;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Reference No";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 15;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Requested by";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 25;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Priority";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 7;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Overall" + Environment.NewLine + " FA In-charge";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 15;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Status";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 10;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "BU";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 15;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Product";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 15;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Last" + Environment.NewLine + "Update";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 10;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Last" + Environment.NewLine + "updated by";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 25;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Current" + Environment.NewLine + "Process";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 20;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Comment";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 50;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Overall CT";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 10;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Current" + Environment.NewLine + "Process CT";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 10;
            //
            startCol++;
            (range.Cells[startRow, startCol] as Excel.Range).Value2 = "Submission" + Environment.NewLine + "Status";
            (range.Cells[startRow, startCol] as Excel.Range).ColumnWidth = 20;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="items"></param>
        private void WriteContent(Excel.Worksheet sheet)
        {
            int startRow = 4;
            int startCol = 2;
            sheet.EnableCalculation = false;

            foreach (var item in Content)
            {
                startCol = 2;
                startRow++;
                Excel.Range rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.FARNumber;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.RefNo;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.RequestBy;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.Priority;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.OverallFAInCharge;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.Status;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.BU;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.Product;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.LastUpdate;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.LastUpdatedBy;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.CurrentProcess;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value2 = item.Comment;

                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value = item.OverallCT;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value = item.CurrentProcessCT;
                //
                startCol++;
                rangeContent = (sheet.Cells[startRow, startCol] as Excel.Range);
                rangeContent.NumberFormat = "@";
                rangeContent.Value = item.SubmissionOrStatus;
            }
            var cell1 = sheet.Cells[4, 2];
            var cell2 = sheet.Cells[startRow, startCol];
            Excel.Range range = sheet.Range[cell1, cell2];
            SetBorder(range, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="range"></param>
        /// <param name="color"></param>
        private void SetBorder(Excel.Range range, int color)
        {
            Excel.Borders borders = range.Borders;
            borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            borders.Color = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string SaveFile()
        {
            string fileName = String.Empty;
            try
            {
                fileName = Guid.NewGuid().ToString() + ".xlsx";
                string folderReport = Path.Combine(_pathRoot, "Reports");
                if (!Directory.Exists(folderReport))
                    Directory.CreateDirectory(folderReport);

                string filePath = System.IO.Path.Combine(folderReport, fileName);
                workBook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch
            {
                fileName = String.Empty;
            }

            finally
            {
                NAR(workSheetDashboard);
                workBook.Close(false);
                NAR(workBook);
                excelApp.Quit();
                NAR(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return fileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void NAR(object obj)
        {
            try
            {
                while (System.Runtime.InteropServices.Marshal.FinalReleaseComObject(obj) > 0) ;
            }
            catch { }
            finally
            {
                obj = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<ExcelViewModel> Content { get; set; }
    }
}