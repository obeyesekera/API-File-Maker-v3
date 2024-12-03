using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace PNR_File_Maker
{
    partial class frmMain
    {

        //Create COM Objects.
        ExcelApp.Application excelApp = new ExcelApp.Application();
        DataRow myNewRow;
        DataTable myTable;

        private DataTable dtExcel;
        private DataTable dtCountry;
        private DataTable dtConfig;
        //private DataTable dtPNR;
        private DataTable dtSSR;

        private DataTable ReadExcel(string fileName)
        {
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(fileName);

            try
            {
                //Open Excel file
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                ExcelApp.Range excelRange = excelSheet.UsedRange;

                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;

                //Set DataTable Name and Columns Name
                myTable = new DataTable(excelSheet.Name);

                //first row using for heading
                for (int i = 1; i <= cols; i++)
                {
                    myTable.Columns.Add(excelRange.Cells[1, i].Value2.ToString(), typeof(string));
                }

                if (rows > 1)
                {
                    //first row using for heading, start second row for data
                    for (int r = 2; r <= rows; r++)
                    {
                        myNewRow = myTable.NewRow();
                        for (int c = 1; c <= cols; c++)
                        {
                            string cellVal = "";

                            /* Commented on 2024-Dec-02
                            if (myTable.Columns[c - 1].ColumnName.Contains("Date"))
                            {
                                DateTime conv = DateTime.FromOADate(excelRange.Cells[r, c].Value2);
                                cellVal = conv.ToShortDateString();
                            }
                            else
                            {
                                cellVal = Convert.ToString(excelRange.Cells[r, c].Value2);
                            }
                            */

                            cellVal = Convert.ToString(excelRange.Cells[r, c].Value2); //Added on 2024-Dec-02

                            myNewRow[c - 1] = cellVal;


                        }
                        myTable.Rows.Add(myNewRow);
                    }
                }
                else
                {
                    DataRow newrow = myTable.NewRow();

                    for (int i = 0; i < cols; i++)
                    {
                        newrow[i] = "";
                    }

                    myTable.Rows.Add(newrow);
                }
                return myTable;
            }
            finally
            {
                if (excelBook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excelBook);
                excelApp.Quit();
            }
        }


        private void initializeDataset()
        {
            try
            {
                var GetDirectory = AppContext.BaseDirectory;

                dtExcel = ReadExcel(GetDirectory + "\\API_Template.xlsx"); //read excel file
                dataGridView.Visible = true;
                dataGridView.DataSource = dtExcel;
                updatePaxCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
        private void initializeDataset2()
        {
            try
            {
                var GetDirectory = AppContext.BaseDirectory;

                dtPNR = ReadExcel(GetDirectory + "\\PNR_Template.xlsx"); //read excel file
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        private void loadCountries()
        {
            try
            {
                var GetDirectory = AppContext.BaseDirectory;

                dtCountry = ReadExcel(GetDirectory + "\\Countries.xlsx"); //read excel file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadSSR()
        {
            try
            {
                var GetDirectory = AppContext.BaseDirectory;

                dtSSR = ReadExcel(GetDirectory + "\\SSR.xlsx"); //read excel file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadConfig()
        {
            try
            {
                var GetDirectory = AppContext.BaseDirectory;

                dtConfig = ReadExcel(GetDirectory + "\\Config.xlsx"); //read excel file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Tuple<string, string> loadExcelFile()
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
            file.CheckFileExists = true;
            file.Title = "Open Excel Files";
            file.Filter = "Excel files (*.xls)|*.xls|Excel XML files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            file.FilterIndex = 3;

            string msg;
            string typ;

            if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
            {
                string fileExt = Path.GetExtension(file.FileName); //get the file extension

                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        dtExcel = ReadExcel(file.FileName); //read excel file
                        dataGridView.Visible = true;
                        dataGridView.DataSource = dtExcel;
                        updatePaxCount();
                        defineSeats();

                        msg = txtNoofPassengers.Text + " records loaded.";
                        typ = "I";
                    }
                    catch (Exception ex)
                    {
                        msg = ex.Message.ToString();
                        typ = "E";
                    }
                }
                else
                {
                    msg = "Please choose .xls or .xlsx file only.";
                    typ = "W";
                }
            }
            else
            {
                msg = "Please choose .xls or .xlsx file only.";
                typ = "W";
            }

            return new Tuple<string, string>(msg,typ);
        }


    }
}
