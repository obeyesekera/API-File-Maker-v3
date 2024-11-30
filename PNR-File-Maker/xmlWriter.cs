using System.Windows.Forms;
using System;
using System.Data;

namespace PNR_File_Maker
{
    partial class frmMain
    {

        string fileSavePath;

        private bool validateData()
        {
            bool noBlankData = true;
            foreach (DataRow row in dtExcel.Rows)
            {
                int rowSize = 0;
                foreach (DataColumn column in row.Table.Columns)  //loop through the columns. 
                {
                    rowSize = rowSize + row[column.ColumnName].ToString().Trim().Length;
                    if (rowSize == 0)
                    {
                        noBlankData = false;
                    }
                }

            }

            return noBlankData;
        }

        private void saveAPIFile()
        {
            try
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.Description = "Save API Files to path";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    fileSavePath = folderDialog.SelectedPath;
                    writeAPI();
                    if (cbPNR.Checked) {
                        writePNR(); 
                    }

                    MessageBox.Show("Successfully Saved", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*
                SaveFileDialog file = new SaveFileDialog();
                file.Title = "Save API Files";
                file.CheckPathExists = true;
                file.DefaultExt = "xml";
                file.Filter = "API files (*.xml)|*.xml";
                file.RestoreDirectory = true;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    writeAPI(file.FileName);
                    MessageBox.Show("Successfully Saved", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
