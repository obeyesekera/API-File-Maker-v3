using System;
using System.Data;
using System.Windows.Forms;

namespace PNR_File_Maker
{
    partial class frmMain
    {

        private void initialParams()
        {

            DataRow configRow = dtConfig.Rows[0];

            txtFlightPrefix.Text = configRow[0].ToString(); //"UL";
            txtFlightNumber.Text = configRow[1].ToString(); //"1000001";
            txtDelayTime.Text = configRow[2].ToString(); //"5";
            //txtNoofSeatofFlight.Text = "332";
            txtAircraftType.Text = configRow[3].ToString(); //"Boeing 777-300ER(77W) Three Class";
            txtNoOfBusinessClassRows.Text = configRow[5].ToString(); //"4";
            txtNoOfPremiumClassRows.Text = configRow[4].ToString(); //"2";
            txtNoOfEconomyClassRows.Text = configRow[6].ToString(); //"30";
            txtNoofPassengers.Text = "0";
            txtOriginPort.Text = configRow[7].ToString(); //"KUL";
            txtDestinationPort.Text = configRow[8].ToString(); //"CMB";
            txtDepartureDate.Text = "2023-10-12";
            txtArrivalDate.Text = "2023-10-12";
            txtRequiredPax.Text = "1";
            txtFileCount.Text = "1";

            localCountry = configRow[9].ToString();
            localAlpha3 = configRow[11].ToString();

            dtArrivalTime.CustomFormat = "HH:mm:ss";    //"hh:mm:ss";
            dtArrivalTime.Format = DateTimePickerFormat.Custom;
            txtArrivalDate.Text = dtArrivalTime.Value.ToString("yyyy-MM-dd");
            dtDepartureTime.CustomFormat = "HH:mm:ss";    //"hh:mm:ss";
            dtDepartureTime.Format = DateTimePickerFormat.Custom;
            txtDepartureDate.Text = dtDepartureTime.Value.ToString("yyyy-MM-dd");

            dataGridView.MultiSelect = false;
            txtNoofPassengers.ReadOnly = true;
            txtNoofSeatofFlight.ReadOnly = true;
            cbPNR.Checked = false;

        }

        private void updateConfig()
        {
            
        }

        private static void SetSetting(string key, string value)
        {

        }


        private void disbleAll()
        {
            dataGridView.Enabled = false;
            txtAircraftType.Enabled = false;
            txtArrivalDate.Enabled = false;
            txtDelayTime.Enabled = false;
            txtDepartureDate.Enabled = false;
            txtDestinationPort.Enabled = false;
            txtFileCount.Enabled = false;
            txtFlightNumber.Enabled = false;
            txtFlightPrefix.Enabled = false;
            txtNoOfBusinessClassRows.Enabled = false;
            txtNoOfEconomyClassRows.Enabled = false;
            txtNoOfPremiumClassRows.Enabled = false;
            txtOriginPort.Enabled = false;
            txtRequiredPax.Enabled = false;
            dtArrivalTime.Enabled = false;
            dtDepartureTime.Enabled = false;

            btnSave.Enabled = false;
            btnCopyPax.Enabled = false;
            btnDelPax.Enabled = false;
            btnAddPax.Enabled = false;
            btnClearPax.Enabled = false;
            btnRndPax.Enabled = false;
            btnNew.Enabled = false;
            btnLoad.Enabled = false;
            btnAutoGenerate.Enabled = false;
            cbPNR.Enabled = false;
        }

        private void enableAll()
        {
            dataGridView.Enabled = true;
            txtAircraftType.Enabled = true;
            txtArrivalDate.Enabled = true;
            txtDelayTime.Enabled = true;
            txtDepartureDate.Enabled = true;
            txtDestinationPort.Enabled = true;
            txtFileCount.Enabled = true;
            txtFlightNumber.Enabled = true;
            txtFlightPrefix.Enabled = true;
            txtNoOfBusinessClassRows.Enabled = true;
            txtNoOfEconomyClassRows.Enabled = true;
            txtNoOfPremiumClassRows.Enabled = true;
            txtOriginPort.Enabled = true;
            txtRequiredPax.Enabled = true;
            dtArrivalTime.Enabled = true;
            dtDepartureTime.Enabled = true;

            btnSave.Enabled = false;
            btnCopyPax.Enabled = false;
            btnDelPax.Enabled = false;
            btnAddPax.Enabled = false;
            btnClearPax.Enabled = false;
            btnRndPax.Enabled = true;
            btnNew.Enabled = true;
            btnLoad.Enabled = true;
            btnAutoGenerate.Enabled = true;
            cbPNR.Enabled = true;
        }

        private void setTooltip()
        {
            toolTipCtrl.SetToolTip(btnNew, "New");
            toolTipCtrl.SetToolTip(btnLoad, "Open");
            toolTipCtrl.SetToolTip(btnSave, "Save");
            toolTipCtrl.SetToolTip(btnAutoGenerate, "Auto Gen");

            toolTipCtrl.SetToolTip(btnAddPax, "Add");
            toolTipCtrl.SetToolTip(btnCopyPax, "Copy");
            toolTipCtrl.SetToolTip(btnDelPax, "Delete");
            toolTipCtrl.SetToolTip(btnRndPax, "Generate");
            toolTipCtrl.SetToolTip(btnClearPax, "Clear");
        }

        


        private void updateDepartureDate()
        {
            txtDepartureDate.Text = dtDepartureTime.Value.ToString("yyyy-MM-dd");
        }


        private void updateArrivalDate()
        {
            txtArrivalDate.Text = dtArrivalTime.Value.ToString("yyyy-MM-dd");
        }



    }
}
