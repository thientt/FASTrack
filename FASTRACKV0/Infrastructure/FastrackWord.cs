using System;
using System.IO;
using System.Linq;

using Word = Microsoft.Office.Interop.Word;

namespace FASTrack.Infrastructure
{
    /// <summary>
    /// Convert data to word file
    /// </summary>
    public class FastrackWord
    {
        private Word.Application wordApp = null;
        private Word.Document wordDoc = null;

        private const string fileTemplate1 = "Templates\\IFAR_Template_01.docx";
        private const string fileTemplate2 = "Templates\\IFAR_Template_02.docx";
        private const string folderExport = "Reports";

        private object fileName = String.Empty;
        private ExportType exportType = ExportType.TEMP1;

        private object missing = Type.Missing;
        private object saveMissing = true;

        private const int BottomPadding = 1;
        private const int TopPadding = 1;
        private const int LeftPadding = 5;
        private const int RightPadding = 5;

        public FastrackWord(string filePath)
        {
            this.folderPath = filePath;
            wordApp = new Word.Application();

            wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            wordApp.DisplayScrollBars = false;
            wordApp.ScreenUpdating = false;
            wordApp.Application.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            wordApp.Visible = false;
        }

        private string folderPath = String.Empty;
        public string FolderPath
        {
            get
            {
                return folderPath;
            }
        }

        private FASTrack.ViewModel.FARReportGeneratorViewModel dataSource = null;

        public FASTrack.ViewModel.FARReportGeneratorViewModel DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                dataSource = value;

                if (dataSource == null)
                    throw new Exception("Datasource not null");
            }
        }

        public FASTrack.Model.DTO.SYSUsersDto User1 { get; set; }
        public FASTrack.Model.DTO.SYSUsersDto User2 { get; set; }
        public FASTrack.Model.DTO.SYSUsersDto User3 { get; set; }
        public FASTrack.Model.DTO.SYSUsersDto Requestor { get; set; }

        public System.Collections.Generic.List<FASTrack.Model.DTO.MSTProcessTypesDto> ProcessTypes { get; set; }

        public string Execute()
        {
            if (String.IsNullOrEmpty(folderPath))
                throw new FileNotFoundException("File path not valiable");
            try
            {
                FindTables();
            }

            catch (Exception ex)
            {
                fileName = String.Empty;
            }

            finally
            {
                if (wordDoc != null)
                    wordDoc.Close(true);

                if (wordApp != null)
                    wordApp.Quit();

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wordApp);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wordDoc);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            return (string)fileName;
        }

        private void FindTables()
        {
            if (wordApp != null)
            {
                object readOnly = false;
                object isVisible = true;

                object missing = System.Reflection.Missing.Value;

                //Check object has how many device/samples object
                if (dataSource == null)
                    throw new ArgumentNullException("Datasource not null");

                var report = dataSource;
                if (report.DeviceDetails != null)
                {
                    if (report.DeviceDetails.Count > 1)
                    {
                        fileName = CopyFile(ExportType.TEMP2);
                        exportType = ExportType.TEMP2;
                    }
                    else
                    {
                        fileName = CopyFile(ExportType.TEMP1);
                        exportType = ExportType.TEMP1;
                    }
                }

                if (String.IsNullOrEmpty((string)fileName))
                    return;

                wordDoc = wordApp.Documents.Open(ref fileName, ref missing,
                                                     ref readOnly, ref missing, ref missing, ref missing,
                                                     ref missing, ref missing, ref missing, ref missing,
                                                     ref missing, ref isVisible, ref missing, ref missing, ref missing,
                                                     ref missing);

            }

            int tablecount = wordDoc.Tables.Count;
            for (int i = 1; i <= tablecount; i++)
            {
                Word.Table wTable = wordDoc.Tables[i];
                switch (i)
                {
                    case 1:
                        ExeFullGenerate(wTable, dataSource.DeviceDetails.FirstOrDefault());
                        break;
                    case 2:
                        ExeTableDetail(wTable, dataSource.DeviceDetails.FirstOrDefault());
                        break;
                    case 3:
                        ExeTableInfo(wTable, dataSource);
                        break;
                }
            }



            bool IsNotBreak = false;
            foreach (var device in dataSource.DeviceDetails)
            {
                wordDoc.Range().InsertParagraphAfter();
                ExeTableProcess(device.ProcessHis);
            }
        }

        private void ExeFullGenerate(Word.Table pTable, FASTrack.Model.DTO.FARDeviceDetailsDto device)
        {
            int iMaxRow = 6; int iMaxXol = 3;
            for (int iRow = 1; iRow <= iMaxRow; iRow++)
            {
                for (int iCol = 1; iCol <= iMaxXol; iCol++)
                {
                    Word.Cell wCell = pTable.Cell(iRow, iCol);
                    string sValue = wCell.Range.Text;

                    if (sValue.Contains(KeyWord.FAR_REF))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.FAR_REF, device.Master.Number);
                        continue;
                    }

                    if (sValue.Contains(KeyWord.CUSTOMER))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.CUSTOMER, device.Master.Customer);
                        continue;
                    }

                    if (sValue.Contains(KeyWord.FAILURE_RATE))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.FAILURE_RATE, device.Master.FailureRate + "");
                        continue;
                    }

                    if (sValue.Contains(KeyWord.REQUEST_DATE))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.REQUEST_DATE, device.Master.RequestDate.ToString("dd MMM yyyy"));
                        continue;
                    }

                    if (sValue.Contains(KeyWord.REQUESTOR))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.REQUESTOR, Requestor.FullName);//TODO:get full name
                        continue;
                    }

                    if (sValue.Contains(KeyWord.PRODUCT_LINE))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.PRODUCT_LINE, device.Master.Product);
                        continue;
                    }


                    if (sValue.Contains(KeyWord.REQUESTOR_EMAIL))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.REQUESTOR_EMAIL, Requestor.Email);
                        continue;
                    }

                    if (exportType == ExportType.TEMP1)
                    {

                        if (sValue.Contains(KeyWord.DATE_CODE))
                        {
                            wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.DATE_CODE, device.DateCode);
                            continue;
                        }

                        if (sValue.Contains(KeyWord.PART_NUMBER))
                        {
                            wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.PART_NUMBER, device.MfgPartNo);
                            continue;
                        }

                        if (sValue.Contains(KeyWord.PACK_TYPE))
                        {
                            wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.PACK_TYPE, device.PackageType.Name);
                            continue;
                        }

                        if (sValue.Contains(KeyWord.ASSEMBLY_SITE))
                        {
                            wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.ASSEMBLY_SITE, device.AssemblySites.Name);
                            continue;
                        }

                        if (sValue.Contains(KeyWord.LOT_NUMBER))
                        {
                            wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.LOT_NUMBER, device.LotNo);
                            continue;
                        }

                        if (sValue.Contains(KeyWord.SAMPLES_QTY))
                        {
                            wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.SAMPLES_QTY, device.Quantity + "");
                            continue;
                        }
                    }
                }
            }
        }

        private void ExeTableDetail(Word.Table pTable, FASTrack.Model.DTO.FARDeviceDetailsDto device)
        {
            for (int iRow = 1; iRow <= pTable.Rows.Count; iRow++)
            {
                Word.Cell wCell = pTable.Cell(iRow, 1);
                string sValue = wCell.Range.Text;

                if (sValue.Contains(KeyWord.FA_DETAILS_DESCRIPTION))
                {
                    wCell.Range.Text = device.Master.FailureDesc;
                    continue;
                }

                if (sValue.Contains(KeyWord.PROCESSES) && exportType == ExportType.TEMP1)
                {
                    if (ProcessTypes == null)
                        continue;

                    int iCount = ProcessTypes.Count;

                    int iNumRowOfProcess = (int)Math.Ceiling(iCount / 2d);

                    Word.Table wParent = wCell.Range.Tables.Add(wCell.Range, 1, 2);
                    Word.Cell wCell1 = wParent.Cell(1, 1);
                    Word.Cell wCell2 = wParent.Cell(1, 2);
                    ReportProcessTypeCell(wCell1, (iCount % 2 == 1) ? iNumRowOfProcess - 1 : iNumRowOfProcess, 1, device.ProcessHis);
                    ReportProcessTypeCell(wCell2, iNumRowOfProcess, 2, device.ProcessHis);

                    continue;
                }

                if (sValue.Contains(KeyWord.PROCESSES_COMMENT) && exportType == ExportType.TEMP1)
                {
                    int wCount = device.ProcessHis.Count;
                    object missing = Type.Missing;
                    wCell.Range.Text = String.Empty;
                    Word.Paragraph pText = null;

                    for (int i = 0; i < device.ProcessHis.Count; i++)
                    {
                        var item = device.ProcessHis[i];
                        if (i == 0)
                        {
                            wCell.Range.Bold = 1;
                            wCell.Range.Text = item.ProcessType.Name;
                        }
                        else
                        {
                            pText = wCell.Range.Paragraphs.Add(missing);
                            pText.Range.Bold = 1;
                            pText.Range.Text = item.ProcessType.Name;
                        }
                        pText = wCell.Range.Paragraphs.Add(missing);
                        pText.Range.Bold = 0;
                        pText.Range.Text = item.Comment;

                        wCell.Range.InsertParagraphAfter();
                    }
                }
            }
        }

        private void ExeTableInfo(Word.Table pTable, FASTrack.ViewModel.FARReportGeneratorViewModel master)
        {
            for (int iRow = 1; iRow <= pTable.Rows.Count; iRow++)
            {
                for (int iCol = 1; iCol <= 2; iCol++)
                {
                    Word.Cell wCell = pTable.Cell(iRow, iCol);
                    string sValue = wCell.Range.Text;

                    //[Analyst/User who will generate the Report]
                    if (sValue.Contains(KeyWord.USER_GEN_RE))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.USER_GEN_RE, User1.FullName);//Get full name of user login current
                        continue;
                    }

                    //Phone number of Analyst
                    if (sValue.Contains(KeyWord.PHONE_1))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.PHONE_1, User1.Phone);
                        continue;
                    }

                    //[FA Overall Incharge]
                    if (sValue.Contains(KeyWord.FA_OVERALL_INCHARGE))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.FA_OVERALL_INCHARGE, User2.FullName);
                        continue;
                    }

                    //Phone number of Reviewed by
                    if (sValue.Contains(KeyWord.PHONE_2))
                    {
                        wCell.Range.Text = wCell.Range.Text.Replace(KeyWord.PHONE_2, User2.Phone);
                        continue;
                    }
                }
            }
        }

        private void ExeTableProcess(System.Collections.Generic.List<FASTrack.Model.DTO.FARProcessHistoryDto> processes)
        {
            object missing = Type.Missing;
            //object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            Word.Range wrdRng = wordDoc.Paragraphs.Add(missing).Range;//.Bookmarks.get_Item(ref oEndOfDoc).Range;

            Word.Table wTable = wordDoc.Tables.Add(wrdRng, 1, 2);
          
            wTable.BottomPadding = 1;
            wTable.TopPadding = 1;
            wTable.LeftPadding = 5;
            wTable.RightPadding = 5;

            int iRowImage = 1;

            foreach (var process in processes)
            {
                if (process.SelectPhoto != "Yes")
                    continue;

                wTable.Rows.Add(missing);
                Word.Cell wCell1 = wTable.Cell(iRowImage, 1);
                Word.Cell wCell2 = wTable.Cell(iRowImage, 2);
                wCell1.Merge(wCell2);

                wCell1.Range.Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                wCell1.Range.Borders[Word.WdBorderType.wdBorderLeft].ColorIndex = Word.WdColorIndex.wdBlack;
                wCell1.Range.Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                wCell1.Range.Borders[Word.WdBorderType.wdBorderRight].ColorIndex = Word.WdColorIndex.wdBlack;
                wCell1.Range.Borders[Word.WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                wCell1.Range.Borders[Word.WdBorderType.wdBorderTop].ColorIndex = Word.WdColorIndex.wdBlack;
                wCell1.Range.Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                wCell1.Range.Borders[Word.WdBorderType.wdBorderBottom].ColorIndex = Word.WdColorIndex.wdBlack;

                wCell1.Shading.BackgroundPatternColorIndex = Word.WdColorIndex.wdGray25;

                Word.Paragraph pText = wCell1.Range.Paragraphs.Add(ref missing);
                pText.Range.Bold = 1;
                pText.Format.SpaceAfter = 5f;
                pText.Range.Text = process.ProcessType.Name;

                if (process.Photos != null && process.Photos.Count > 0)
                {
                    wTable.Rows.Add(missing);
                    AddPicture(wTable, process.Photos, ref iRowImage);
                }

                iRowImage++;
            }
        }

        private void AddPicture(Word.Table wTable, System.Collections.Generic.List<string> photos, ref int row)
        {
            int iCountImage = (int)Math.Ceiling(photos.Count / 2d);
            int iRowImage = row;
            int iColImage = 1;

            foreach (var photo in photos)
            {
                int iCol = (iColImage % 2) == 0 ? 2 : 1;
                if (iCol == 1)
                    iRowImage++;

                Word.Cell wCell = wTable.Cell(iRowImage, iCol);
                wCell.BottomPadding = 5;
                wCell.TopPadding = 5;
                wCell.RightPadding = 5;
                wCell.LeftPadding = 5;

                wCell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wCell.Shading.BackgroundPatternColorIndex = Word.WdColorIndex.wdWhite;
                Word.Range range = wCell.Range;
                range.Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                range.Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                range.Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;

                range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Word.InlineShape pic = range.InlineShapes.AddPicture(photo);
                pic.Width = wCell.Width - 10;
                //range.InsertAfter("SN1");

                iColImage++;
            }

            if (photos.Count % 2 == 1)
            {
                Word.Cell wCell = wTable.Cell(iRowImage, 2);
                wCell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wCell.Shading.BackgroundPatternColorIndex = Word.WdColorIndex.wdWhite;
                Word.Range range = wCell.Range;
                range.Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                range.Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
                range.Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            }

            row += iCountImage;
        }

        private void ReportProcessTypeCell(Word.Cell wCell, int row, int col, System.Collections.Generic.List<FASTrack.Model.DTO.FARProcessHistoryDto> processes)
        {
            Word.Paragraph pTable = wCell.Range.Paragraphs.Add(missing);
            Word.Table wTable = pTable.Range.Tables.Add(wCell.Range, row, 1);

            wTable.BottomPadding = BottomPadding;
            wTable.TopPadding = TopPadding;
            wTable.LeftPadding = LeftPadding;
            wTable.RightPadding = RightPadding;
            wTable.Spacing = 10;

            for (int i = 1; i <= row; i++)
            {
                //get process by ID
                int index = i - 1 + ((col - 1) * row);
                var pro = ProcessTypes[index];

                Word.Range range = wTable.Cell(i, 1).Range;
                range.Font.Name = "Verdana";
                range.Font.Size = 10;
                Word.FormField checkBox = range.FormFields.Add(wTable.Cell(i, 1).Range, Word.WdFieldType.wdFieldFormCheckBox);

                checkBox.CheckBox.Default = false;
                checkBox.CheckBox.Size = 15;
                checkBox.CalculateOnExit = true;
                checkBox.Enabled = true;

                if (processes.Exists(x => x.ProcessTypeId == pro.Id))
                    checkBox.CheckBox.Value = true;
                else
                    checkBox.CheckBox.Value = false;

                checkBox.Enabled = false;

                range.InsertAfter(pro.Name);
            }
        }

        private string CopyFile(ExportType pType)
        {
            try
            {
                string fileSource = String.Empty;

                switch (pType)
                {
                    case ExportType.TEMP1:
                        fileSource = Path.Combine(FolderPath, fileTemplate1);
                        break;
                    case ExportType.TEMP2:
                        fileSource = Path.Combine(FolderPath, fileTemplate2);
                        break;
                }
                if (String.IsNullOrEmpty(fileSource))
                    return String.Empty;

                string fileDest = Path.Combine(FolderPath, folderExport, Guid.NewGuid().ToString() + ".docx");
                File.Copy(fileSource, fileDest);

                return fileDest;
            }
            catch
            {
                return String.Empty;
            }
        }

        protected internal enum ExportType
        {
            TEMP1 = 1,
            TEMP2 = 2
        }

        protected internal class KeyWord
        {
            public const string FAR_REF = "[FAR#/REF#]";
            public const string CUSTOMER = "[CUSTOMER]";
            public const string DATE_CODE = "[DATE_CODE]";
            public const string FAILURE_RATE = "[FAILURE_RATE]";
            public const string REQUEST_DATE = "[REQUEST_DATE]";
            public const string REQUESTOR = "[REQUESTOR]";
            public const string PRODUCT_LINE = "[PRO_LINE]";
            public const string PART_NUMBER = "[PART_NUM]";
            public const string PACK_TYPE = "[PACK_TYPE]";
            public const string ASSEMBLY_SITE = "[ASS_SITE]";
            public const string REQUESTOR_EMAIL = "[REQ_EMAIL]";
            public const string LOT_NUMBER = "[LOT_NUM]";
            public const string SAMPLES_QTY = "[SAMPLE_QTY]";

            public const string FA_DETAILS_DESCRIPTION = "[FA_DES]";
            public const string PROCESSES = "[PROCESSES]";
            public const string PROCESSES_COMMENT = "[PROCESSES_COMMENT]";

            public const string USER_GEN_RE = "[USER_GEN_RE]";
            public const string PHONE_1 = "[PHONE_1]";
            public const string FA_OVERALL_INCHARGE = "[FA_OVERALL_INCHARGE]";
            public const string PHONE_2 = "[PHONE_2]";
            public const string APPROVED_BY = "APPROVED_BY";
            public const string PHONE_3 = "[PHONE_3]";

            public const string PROCESS_IMAGES = "[Processes from FA Process Flow and the attached photos per process]";
        }
    }
}
