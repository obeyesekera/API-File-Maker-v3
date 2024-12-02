using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ExcelApp = Microsoft.Office.Interop.Excel;


namespace PNR_File_Maker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (excelApp == null)
            {
                MessageBox.Show("Excel is not installed!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            loadConfig();
            initialParams();
            updatePaxCount();
            setTooltip();
            loadCountries();
            loadSSR();
            
        }
        

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var results = loadExcelFile();

            switch (results.Item2)
            {
                case "E":
                    MessageBox.Show(results.Item1, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "W":
                    MessageBox.Show(results.Item1, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBox.Show(results.Item1, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                string fileTypes = "API file";

                if (cbPNR.Checked)
                {
                    fileTypes = "API and PNR Files";
                }

                DialogResult dialogResult = MessageBox.Show("Do you want to save "+ fileTypes + " ?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    setFlight();
                    saveAPIFile();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                MessageBox.Show("Incomplete Records Found !", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void btnNew_Click(object sender, EventArgs e)
        {
            initializeDataset();
            //initializeDataset2();
        }
        

        private void dtDepartureTime_ValueChanged(object sender, EventArgs e)
        {
            updateDepartureDate();
        }


        private void dtArrivalTime_ValueChanged(object sender, EventArgs e)
        {
            updateArrivalDate();
        }


        private void btnDuplicateRow_Click(object sender, EventArgs e)
        {
            string results = duplicateRow();

            if (results.Length>0)
            {
                MessageBox.Show(results, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updatePaxCount();
        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updatePaxCount();
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updatePaxCount();
        }

        

        private void btnAddPax_Click(object sender, EventArgs e)
        {
            string results = addPaxRow(dtExcel.Columns.Count);

            if (results.Length > 0)
            {
                MessageBox.Show(results, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        private void btnDelPax_Click(object sender, EventArgs e)
        {
            string results = delPaxRow(dataGridView.CurrentRow.Index);

            if (results.Length > 0)
            {
                MessageBox.Show(results, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void btnRndPax_Click(object sender, EventArgs e)
        {
            generatePaxData();
        }

        

        

        

        

        private void btnClearPax_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            //dtPNR = null;

        }

        

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //excelApp.Quit();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            calcSeats();
        }

        

        private void txtNoOfPremiumClassRows_TextChanged(object sender, EventArgs e)
        {
            calcSeats();
        }

        private void txtNoOfBusinessClassRows_TextChanged(object sender, EventArgs e)
        {
            calcSeats();
        }

        private void txtNoOfEconomyClassRows_TextChanged(object sender, EventArgs e)
        {
            calcSeats();
        }

        

        

        private void btnAutoGenerate_Click(object sender, EventArgs e)
        {
            string fileCount = txtFileCount.Text;

            DialogResult dialogResult = MessageBox.Show("Do you want to generate " + fileCount + " API files ?", "Auto Gen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                cbPNR.Checked = false;
                disbleAll();
                
                var results = autoGenerate(fileCount);

                switch (results.Item2)
                {
                    case "E":
                        MessageBox.Show(results.Item1, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show(results.Item1, "Auto Gen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                enableAll();


            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }

        

        private void frmMain_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Local Country : " + localCountry);
        }
    }
}
