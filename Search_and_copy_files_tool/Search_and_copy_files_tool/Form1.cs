using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace Search_and_copy_files_tool
{
    public partial class frm_Seach_And_Copy_Files_Tool : Form
    {
        public frm_Seach_And_Copy_Files_Tool()
        {
            InitializeComponent();
        }

        private void cmdGetSourcePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            folderBrowserDlg.ShowNewFolderButton = true;
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if (dlgResult.Equals(DialogResult.OK))
            {
                txtSourcePath.Text = folderBrowserDlg.SelectedPath;
                Environment.SpecialFolder rootFolder = folderBrowserDlg.RootFolder;
            }
        }

        private void cmdGetDestinationPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            folderBrowserDlg.ShowNewFolderButton = true;
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if (dlgResult.Equals(DialogResult.OK))
            {
                txtDestinationPath.Text = folderBrowserDlg.SelectedPath;
                Environment.SpecialFolder rootFolder = folderBrowserDlg.RootFolder;
            }
        }

        public string FileSearching(string sDir, string sfileName)
        {
            string s1 = ""; bool b1 = false;
            try
            {
                s1 = Path.Combine(sDir, sfileName);
                b1 = File.Exists(s1);
                if (b1 == true)
                {
                    return s1;
                }
                else
                {
                    s1 = "";
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                        statusStrip1.Invoke(new MethodInvoker(delegate()
                        {
                            toolStripStatusLabel1.Text = "Searching " + sfileName + " in: " + d;
                        }));

                        s1 = FileSearching(d, sfileName);
                        if (!s1.Equals("")) { return s1; }
                    }
                }
            }
            catch
            {
                return "";
            }
            return s1;
        }

        private void cmdCopyFiles_Click(object sender, EventArgs e)
        {
            Thread thrGenerating = new Thread(new ThreadStart(CreateOutputFile));
            thrGenerating.Start();

            thrGenerating = new Thread(new ThreadStart(CopyFiles));
            thrGenerating.Start();
        }

        private void CopyFiles()
        {
            //DateTime DateTime1 = DateTime.Now;
            //if (DateTime1.Year >= 2016 && DateTime1.Month >= 9 && DateTime1.Day >= 30)
            //{
            //    MessageBox.Show("Trial version expired!");
            //    return;
            //}
            string sourcePath = txtSourcePath.Text;
            string destinationPath = txtDestinationPath.Text;

            if (sourcePath.Equals("")) { return; }
            if (destinationPath.Equals("")) { return; }
            DirectoryInfo dir = new DirectoryInfo(sourcePath);
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourcePath);
            }

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            string string1 = txtFilesList.Text;
            if (string1.Equals("")) { MessageBox.Show("Please enter files list to copy"); return; }
            string[] lines1 = string1.Split('\r');

            int j1 = 0; int j2 = 0;
            statusStrip1.Invoke(new MethodInvoker(delegate()
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                    toolStripProgressBar1.Maximum = lines1.Length;
                    toolStripProgressBar1.Value = 0;
                }));
            string OutputFileName1 = Path.Combine(destinationPath, "Copy_Status.xls");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel._Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing); Excel.Range rng;
            int sheetIndex = 0; Excel.Worksheet excelSheet = new Excel.Worksheet();
            excelSheet = (Excel.Worksheet)excelWorkbook.Sheets.Add(
                      excelWorkbook.Sheets.get_Item(++sheetIndex),
                      Type.Missing, 1, Excel.XlSheetType.xlWorksheet);
            excelSheet.Name = "Data_ouput";
            excelSheet.Cells[1, 1] = "No"; excelSheet.Cells[1, 2] = "Files Name"; excelSheet.Cells[1, 3] = "Status"; 
            rng = (Excel.Range)excelSheet.get_Range(excelSheet.Cells[1, 1], excelSheet.Cells[1, 3]);
            rng.Font.Bold = true;
            rng.Borders.Color = System.Drawing.Color.Black.ToArgb();

            string msg1 = "";
            foreach (string file1 in lines1)
            {
                j1 = j1 + 1;

                statusStrip1.Invoke(new MethodInvoker(delegate()
                {
                    toolStripProgressBar1.Value = j1;
                }));

                string[] string_array1 = file1.Replace("\n", "").Split(new char[] { ';' });
                string file2 = string_array1[0];
                if (!file2.Equals(""))
                {
                    string s1 = FileSearching(sourcePath, file2);
                    string d1 = Path.Combine(destinationPath, file2);

                    statusStrip1.Invoke(new MethodInvoker(delegate()
                    {
                        toolStripStatusLabel1.Text = "Copying: " + s1;
                    }));

                    excelSheet.Cells[j1 + 1, 1] = j1; excelSheet.Cells[j1 + 1, 2] = file2;

                    if (!file2.Equals(""))
                    {
                        try
                        {
                            bool b1 = File.Exists(s1);
                            bool b2 = File.Exists(d1);
                            if (b1 == false)
                            {
                                msg1 = msg1 + "Could not be found " + s1 + "\r\n";
                                excelSheet.Cells[j1 + 1, 3] = "Could not found";
                                rng = (Excel.Range)excelSheet.get_Range(excelSheet.Cells[j1 + 1, 1], excelSheet.Cells[j1 + 1, 3]);
                                rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                rng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            }
                            else if (b1 == true && b2 == false)
                            {
                                File.Copy(s1, d1);
                                j2 = j2 + 1;
                                excelSheet.Cells[j1 + 1, 3] = "Copied successfull";
                            }
                            else if (b1 == true && b2 == true)
                            {
                                excelSheet.Cells[j1 + 1, 3] = "Already exited in destination folder";
                                rng = (Excel.Range)excelSheet.get_Range(excelSheet.Cells[j1 + 1, 1], excelSheet.Cells[j1 + 1, 3]);
                                rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                                rng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            }
                        }
                        catch (Exception ex1)
                        {
                            excelSheet.Cells[j1 + 1, 3] = "Error: " + ex1.ToString();
                            rng = (Excel.Range)excelSheet.get_Range(excelSheet.Cells[j1 + 1, 1], excelSheet.Cells[j1 + 1, 3]);
                            rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            rng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        }
                    }
                }
            }
            statusStrip1.Invoke(new MethodInvoker(delegate()
            {
                toolStripStatusLabel1.Text = "Ready";
            }));
            statusStrip1.Invoke(new MethodInvoker(delegate()
            {
                toolStripProgressBar1.Value = lines1.Length;
            }));

            rng = (Excel.Range)excelSheet.get_Range(excelSheet.Cells[1, 1], excelSheet.Cells[lines1.Length, 3]);
            rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
            excelSheet.Columns.AutoFit();
            excelSheet.Application.ActiveWindow.SplitRow = 1;
            excelSheet.Application.ActiveWindow.SplitColumn = 0;
            excelSheet.Application.ActiveWindow.FreezePanes = true;
            //save file
            excelWorkbook.SaveAs(OutputFileName1, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            excelWorkbook.Close(true, Type.Missing, Type.Missing);
            excelWorkbook = null;
            excelApp.Quit();
            excelApp = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Process process1 = Process.Start(OutputFileName1);
        }

        private void CreateOutputFile()
        {
            string destinationPath = txtDestinationPath.Text;
            if (destinationPath.Equals("")) { return; }
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            string string1 = txtFilesList.Text;
            if (string1.Equals("")) { MessageBox.Show("Please input data into textbox first!"); return; }
            string[] lines1 = string1.Split('\r');

            int j1 = 0; int j2 = 0;
            statusStrip1.Invoke(new MethodInvoker(delegate()
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                toolStripProgressBar1.Maximum = lines1.Length;
                toolStripProgressBar1.Value = 0;
            }));

            string msg1 = ""; string OutputFileName1 = Path.Combine(destinationPath, "Data_Output.xls");
            string Code1 = ""; string Code1_StartChar = ""; string Code1_Set1 = ""; string Code1_Set2 = ""; string Code1_Set3 = ""; string NewCode1 = ""; int No1 = 0; string Type1 = "";
            string Item1 = ""; string Location1 = ""; double H1 = 0; double W1 = 0; double D1 = 0;
            int Qty1 = 0; string Note1 = ""; string Dimension1 = ""; string Dimension2 = ""; string Dimension3 = "";
            if (File.Exists(OutputFileName1))
            {
                File.Delete(OutputFileName1);
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel._Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Add(Type.Missing); Excel.Range rng;
            int sheetIndex = 0; Excel.Worksheet excelSheet = new Excel.Worksheet();
            excelSheet = (Excel.Worksheet)excelWorkbook.Sheets.Add(
                      excelWorkbook.Sheets.get_Item(++sheetIndex),
                      Type.Missing, 1, Excel.XlSheetType.xlWorksheet);
            excelSheet.Name = "Data_ouput";

            //FORMAT HEADER
            excelSheet.Cells[1, 1] = "Location"; excelSheet.Cells[1, 2] = "Item"; excelSheet.Cells[1, 3] = "Code";
            excelSheet.Cells[1, 4] = "W"; excelSheet.Cells[1, 5] = "H"; excelSheet.Cells[1, 6] = "D";
            excelSheet.Cells[1, 7] = "Qty"; excelSheet.Cells[1, 8] = "Type"; excelSheet.Cells[1, 9] = "Note"; 
            rng = (Excel.Range)excelSheet.get_Range(excelSheet.Cells[1, 1], excelSheet.Cells[1, 9]);
            rng.Font.Bold = true;
            rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
            //if (Data1.Columns[col].ColumnName.Contains("Amount"))
            //{
            //    rng.NumberFormat = "_(* #,##0_);_(* (#,##0);_(* \" - \"_);_(@_)";
            //}
            foreach (string file1 in lines1)
            {
                j1 = j1 + 1;
                statusStrip1.Invoke(new MethodInvoker(delegate() { toolStripStatusLabel1.Text = "Creating output file: " + file1; }));
                statusStrip1.Invoke(new MethodInvoker(delegate() { toolStripProgressBar1.Value = j1; }));
                string[] string_array1 = file1.Replace("\n", "").Split(new char[] { ';' });
                if (string_array1.Length < 4) { break; }
               
                Code1 = Path.GetFileNameWithoutExtension(string_array1[0].Trim());
                No1 = Convert.ToByte(string_array1[1].Trim());
                Item1 = string_array1[2].Trim();
                Note1 = string_array1[3].Trim();

                Location1 = No1.ToString(); Qty1 = 1; ;;

                if (Code1.Length >= 12) { Type1 = Code1.Substring(0, Code1.Length - 12); } else { Type1 = ""; }
                if (Code1.Length >= 12) { Dimension1 = Code1.Substring(Code1.Length - 12, 4); } else { Dimension1 = ""; }
                if (Code1.Length >= 12) { Dimension2 = Code1.Substring(Code1.Length - 8, 4); } else { Dimension2 = ""; }
                if (Code1.Length >= 12) { Dimension3 = Code1.Substring(Code1.Length - 4, 4); } else { Dimension3 = ""; }

                W1 = ConvertToDouble(Dimension1) / 100;
                H1 = ConvertToDouble(Dimension2) / 100;
                D1 = ConvertToDouble(Dimension3) / 100;

                if (Code1.Length >= 12) { Code1_StartChar = Code1.Substring(0, 1); } else { Code1_StartChar = ""; }
                 Code1_Set1 = Type1; Code1_Set2 = Math.Round(W1).ToString(); Code1_Set3 = Math.Round(H1).ToString();
                 if (Code1_Set2.Length == 1) { Code1_Set2 = "0" + Code1_Set2; }
                 if (Code1_Set3.Length == 1) { Code1_Set3 = "0" + Code1_Set3; }
                 if (Code1_StartChar.ToUpper().Equals("W"))
                 {
                     NewCode1 = Code1_Set1 + Code1_Set2 + Code1_Set3;
                 }
                 else
                 {
                     NewCode1 = Code1_Set1 + Code1_Set2;
                 }
                excelSheet.Cells[j1 + 1, 1] = Location1;
                excelSheet.Cells[j1 + 1, 2] = Item1;
                excelSheet.Cells[j1 + 1, 3] = NewCode1;
                excelSheet.Cells[j1 + 1, 4] = W1;
                excelSheet.Cells[j1 + 1, 5] = H1;
                excelSheet.Cells[j1 + 1, 6] = D1;
                excelSheet.Cells[j1 + 1, 7] = Qty1;
                excelSheet.Cells[j1 + 1, 8] = Type1;
                excelSheet.Cells[j1 + 1, 9] = Note1;
            }
            rng = (Excel.Range)excelSheet.get_Range(excelSheet.Cells[1, 1], excelSheet.Cells[lines1.Length, 9]);
            rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
            excelSheet.Columns.AutoFit();
            excelSheet.Rows.AutoFit();
            excelSheet.Application.ActiveWindow.SplitRow = 1;
            excelSheet.Application.ActiveWindow.SplitColumn = 0;
            excelSheet.Application.ActiveWindow.FreezePanes = true;
            //save file
            excelWorkbook.SaveAs(OutputFileName1, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            excelWorkbook.Close(true, Type.Missing, Type.Missing);
            excelWorkbook = null;
            excelApp.Quit();
            excelApp = null;
            if (!msg1.Equals(""))
            {
                MessageBox.Show(msg1);
            }
            statusStrip1.Invoke(new MethodInvoker(delegate()
            {
                toolStripStatusLabel1.Text = "Ready";
            }));
            statusStrip1.Invoke(new MethodInvoker(delegate()
            {
                toolStripProgressBar1.Value = lines1.Length;
            }));
        }

        public static double ConvertToDouble(object value1)
        {
            try
            {
                return Convert.ToDouble(value1);
            }
            catch
            {
                return 0;
            }
        }

        private void cmdCreateFile_Click(object sender, EventArgs e)
        {
            string sourcePath = txtSourcePath.Text;
            string string1 = "file_.xlsx"; string string2 = ""; int j1 = 0;
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar1.Maximum = 100000;
            toolStripProgressBar1.Value = 0;

            for (int i = 1; i <= 100000; i++)
            {
                toolStripProgressBar1.Value = i;
                string2 = "file_" + i.ToString() + ".xlsx";
                toolStripStatusLabel1.Text = string2;
                string s1 = Path.Combine(sourcePath, string1);
                string d1 = Path.Combine(sourcePath, string2);
                if (File.Exists(s1) && !File.Exists(d1))
                {
                    File.Copy(s1, d1);
                }
            }
            toolStripStatusLabel1.Text = "Ready";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void frm_Seach_And_Copy_Files_Tool_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://biframeworks.com/");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string FileName1 = openFileDialog1.FileName;

            Thread thread = new Thread(() => ImportExcel(FileName1));
            thread.Start();

        }

        private void ImportExcel(string FileName1)
        {

            DataTable dataTable1 = default(DataTable);

            string SelectedFolderPath1 = FileName1.Replace(@"\" + Path.GetFileName(FileName1), "");
            bool b1 = (FileName1.ToUpper().LastIndexOf(".XLS") > 0);

            statusStrip1.Invoke(new MethodInvoker(delegate()
            {
                toolStripStatusLabel1.Text = "Reading : " + FileName1;
            }));

            if (b1)
            {
                dataTable1 = ReadExcelFile(FileName1, "");
            }
            else
            {
                b1 = (FileName1.ToUpper().LastIndexOf(".XLSX") > 0);
                if (b1)
                {
                    dataTable1 = ReadExcelFile(FileName1, "");
                }
            }

            if (dataTable1 != null)
            {

                statusStrip1.Invoke(new MethodInvoker(delegate()
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                    toolStripProgressBar1.Maximum = dataTable1.Rows.Count;
                    toolStripProgressBar1.Value = 0;
                }));

                string string1 = ""; string Extension1 = ""; string FileName2 = ""; string Code1 = ""; string No1 = ""; string Note1 = ""; string Item1 = ""; 
                for (int i = 0; i <= dataTable1.Rows.Count - 1; i++)
                {
                    No1 = dataTable1.Rows[i]["No"].ToString();
                    Item1 = dataTable1.Rows[i]["Item"].ToString();
                    Code1 = dataTable1.Rows[i]["Code"].ToString();
                    Note1 = dataTable1.Rows[i]["Note"].ToString();
                    
                    if (!Code1.Equals(""))
                    {
                        FileName1 = Code1;
                        Extension1 = Path.GetExtension(Code1);
                        if (Extension1.Equals("")) { FileName2 = Code1 + ".pdf"; }
                        string1 += FileName2 + "; " + No1 + "; " + Item1 + "; " + Note1 + "\r\n";
                    }
                    statusStrip1.Invoke(new MethodInvoker(delegate()
                    {
                        toolStripProgressBar1.Value = i;
                    }));
                }


                txtFilesList.Invoke(new MethodInvoker(delegate()
                    {
                        txtFilesList.Text = string1;
                    }));
                statusStrip1.Invoke(new MethodInvoker(delegate()
                {
                    toolStripStatusLabel1.Text = "Ready";
                }));
                statusStrip1.Invoke(new MethodInvoker(delegate()
                {
                    toolStripProgressBar1.Value = dataTable1.Rows.Count;
                }));

                //string msg1 = "Import " + dataTable1.Rows.Count.ToString() + " rows completed!";
                //MessageBox.Show(msg1);
            }
        }

        public static DataTable ReadExcelFile(string filePath, string sheetName)
        {
            OleDbConnection oleDbConnection1 = default(OleDbConnection);
            OleDbDataAdapter oleDbDataAdapter1 = default(OleDbDataAdapter);
            DataTable dataTable3 = default(DataTable);
            string string1 = default(string);
            object[] objectArray1 = default(object[]);
            DataTable dataTable2 = new DataTable();
            string prevous_sheetName = "";
            try
            {
                string1 = "Provider=Microsoft.ACE.OLEDB.12.0;data source={0}; Extended Properties=\"Excel 12.0;HDR=YES;\"";
                oleDbConnection1 = new OleDbConnection(string.Format(string1, filePath));
                oleDbConnection1.Open();
                DataTable dt1 = new DataTable();
                objectArray1 = new object[] { null, null, null, "Table" };
                dataTable3 = oleDbConnection1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objectArray1);
                for (int i = 0; i <= dataTable3.Rows.Count - 1; i++)
                {
                    sheetName = dataTable3.Rows[i]["TABLE_NAME"].ToString();
                    if (!sheetName.ToLower().Contains("filterdatabase"))
                    {
                        oleDbDataAdapter1 = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", sheetName), oleDbConnection1);
                        dt1 = new DataTable();
                        int i1 = oleDbDataAdapter1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            dataTable2.Merge(dt1);
                        }
                        prevous_sheetName = sheetName;
                    }

                }
                oleDbConnection1.Close();
            }
            catch (Exception)
            {
                try
                {
                    string1 = "Provider=Microsoft.Jet.OLEDB.4.0;data source={0}; Extended Properties=\"Excel 8.0;HDR=YES;\"";
                    oleDbConnection1 = new OleDbConnection(string.Format(string1, filePath));
                    oleDbConnection1.Open();
                    DataTable dt1 = new DataTable();
                    objectArray1 = new object[] { null, null, null, "Table" };
                    dataTable3 = oleDbConnection1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objectArray1);
                    for (int i = 0; i <= dataTable3.Rows.Count - 1; i++)
                    {
                        sheetName = dataTable3.Rows[i]["TABLE_NAME"].ToString();
                        if (!sheetName.ToLower().Contains("filterdatabase"))
                        {
                            oleDbDataAdapter1 = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", sheetName), oleDbConnection1);
                            dt1 = new DataTable();
                            int i1 = oleDbDataAdapter1.Fill(dt1);
                            if (dt1.Rows.Count > 0)
                            {
                                dataTable2.Merge(dt1);
                            }
                            prevous_sheetName = sheetName;
                        }

                    }
                    oleDbConnection1.Close();
                }
                catch (Exception exception2)
                {
                    oleDbConnection1.Close();
                    MessageBox.Show(exception2.ToString());
                }
            }
            return dataTable2;
        }

        private void toolStripProgressBar1_RightToLeftChanged(object sender, EventArgs e)
        {
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
