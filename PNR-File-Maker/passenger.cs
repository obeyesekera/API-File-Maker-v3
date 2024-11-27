using System.Data;
using System;
using System.Windows.Forms;

namespace PNR_File_Maker
{
    partial class frmMain
    {

        private string localCountry;
        private string localAlpha3;


        private void generatePaxData()
        {
            defineSeats();
            initializeDataset();
            initialiseGrid();

            int totPax = Int32.Parse(txtRequiredPax.Text);
            string origin = txtOriginPort.Text;
            string destination = txtDestinationPort.Text;

            //Last row of economy class
            string crewRow = seatArray[2, 2].ToString();


            for (int px = 1; px <= totPax; px++)
            {

                DataRow newrow = dtExcel.NewRow();
                DataRow country = rndCountry();
                string alpha2 = country[1].ToString();
                string alpha3 = country[2].ToString();
                string countryCode = country[4].ToString();
                string countryName = country[0].ToString();

                string passengerType = "PAX";
                string seatNumber = allocateSeat();  //"22A";

                string portOfEmbark = origin;
                string portOfDisembark = destination;
                string firstTransitPorts = "";

                string hotelAlpha3 = localAlpha3;
                string hotelCountry = localCountry;

                //Crew will be seated on last row of economy class
                if (seatNumber.Substring(0, (seatNumber.Length - 1)) == crewRow)
                {
                    passengerType = "CREW";
                }
                else
                {
                    if (seatNumber.Substring((seatNumber.Length - 1), 1) == "E") //Transit PAX on E seats
                    {
                        portOfDisembark = alpha3;
                        firstTransitPorts = destination;
                    }
                }

                newrow["PassengerType"] = passengerType;
                newrow["DocType"] = "P";

                newrow["DocumentNo"] = rndTravelDoc(alpha2);  //"SG1025561";
                newrow["Nationality"] = alpha3; //"SGP";

                string givenName = generateName(5);
                newrow["GivenName"] = givenName;

                string surName = generateName(7);
                newrow["Surname"] = surName;

                string fullName = givenName + " " + surName;
                newrow["FullName"] = fullName;

                newrow["DateOfBirth"] = rndDOB();  //"18/06/1996";

                string gender = rndGender();
                newrow["Gender"] = gender; //"M";

                string expiryDate = rndExpiryDate();
                newrow["ExpireDate"] = expiryDate;  //"15/04/2029";
                newrow["CountryOfResidence"] = alpha3;  //"SGP";
                newrow["DocIssueCountry"] = alpha3;  //"SGP";
                newrow["BookingReferenceId"] = rndBookingRef(txtFlightPrefix.Text); //"UL12345";
                newrow["BookingReferenceType"] = "AVF";

                string bookingDate = rndBookingDate();
                newrow["BookingDate"] = bookingDate;  //"05/01/2023";
                newrow["SeatNo"] = seatNumber;  //allocateSeat();  //"22A";
                newrow["PortOfEmbark"] = portOfEmbark; // origin;  //"CMB";
                newrow["PortOfDisembark"] = portOfDisembark; // destination;  //"KUL";
                newrow["FirstTransitPorts"] = firstTransitPorts; // alpha3;  //"SGP";
                newrow["VisaNo"] = rndTravelDoc("VP");  //"VP2023048";
                newrow["VisaExpiryDate"] = expiryDate;  //"24/06/2023";
                newrow["NoofCheckingluggage"] = "1";
                newrow["ReservationPaymentID"] = randomNumber(10000, 99999);  //"97059";
                newrow["PaymentCardHolder"] = givenName + " " + surName; //"HANNA AHMAD";
                newrow["PaymentAmount"] = "343";
                newrow["PaymentExpirationDate"] = expiryDate;  //"05/01/2023";
                newrow["PaymentCardNumber"] = rndCardNo();  //"23118281";
                newrow["PaymentAuthorizationcode"] = randomNumber(100, 999);  //"877";
                newrow["PaymentTerminalID"] = randomNumber(10000, 99999);  //"70271";
                newrow["PaymentCurrencyPaid"] = "USD";
                newrow["PaymentMerchantID"] = randomNumber(10000, 99999);  //"41429";
                newrow["PaymentCountry"] = alpha3;  //"LKA";
                newrow["PaymentMethod"] = rndPayMetod();  //"CARD";
                newrow["PaymentDatePaid"] = bookingDate;  //"05/01/2023";
                newrow["ReservationContactFirstName"] = givenName;  //"HANNA";
                newrow["ReservationContactLastName"] = surName;  //"AHMAD";
                newrow["ReservationContactGender"] = gender; // "M";

                newrow["PassengerEmail"] = paxEmail(givenName, surName); // "hana.ahmad@gmail.com";
                newrow["PassengerContact"] = paxPhoneNo(countryCode); ; // "+94888888888";
                newrow["PassengerAddressLine1"] = paxAddress1(alpha3); // "32/424, Main Street";
                newrow["PassengerAddressLine2"] = countryName; // "Colombo 03";

                int agentCode = randomNumber(1, 9);
                string agntID = agentID(alpha3, agentCode);
                newrow["AgentID"] = agntID; // "AG0152";
                newrow["AgentEmail"] = agentEmail(agntID); // "agent.a@gmail.com";
                newrow["AgentContact"] = agentPhoneNo(countryCode, agentCode); // "+94888888888";

                if (seatNumber.Substring((seatNumber.Length - 1), 1) == "E") //Transit PAX on E seats
                {
                    hotelAlpha3 = alpha3;
                    hotelCountry = countryName;
                }

                int hotelCode = randomNumber(1, 9);
                newrow["PassengerHotelReservationName"] = hotelName(hotelAlpha3, hotelCode); // "Cinnamon Lake";
                newrow["PassengerHotelReservationAddressLine1"] = hotelAddress1(hotelCode); // "Galle Road";
                newrow["PassengerHotelReservationAddressLine2"] = hotelCountry; // "Colombo 02";

                dtExcel.Rows.Add(newrow);
            }
        }



        private void updatePaxCount()
        {
            int paxCount = dataGridView.Rows.Count - 1;

            if (paxCount <= 0)
            {
                txtNoofPassengers.Text = "0";

                if (dataGridView.Enabled)
                {
                    btnSave.Enabled = false;
                    btnCopyPax.Enabled = false;
                    btnDelPax.Enabled = false;
                    btnAddPax.Enabled = false;
                    btnClearPax.Enabled = false;
                    btnRndPax.Enabled = true;
                    btnNew.Enabled = true;
                    btnLoad.Enabled = true;
                    btnAutoGenerate.Enabled = true;
                }
            }
            else
            {
                txtNoofPassengers.Text = paxCount.ToString();
                if (dataGridView.Enabled)
                {
                    btnSave.Enabled = true;
                    btnCopyPax.Enabled = true;
                    btnDelPax.Enabled = true;
                    btnAddPax.Enabled = true;
                    btnClearPax.Enabled = true;
                    btnRndPax.Enabled = false;
                    btnNew.Enabled = false;
                    btnLoad.Enabled = false;
                    btnAutoGenerate.Enabled = false;
                }
            }
        }

        private string addPaxRow(int cols)
        {
            string msg = "";

            try
            {
                DataRow newrow = dtExcel.NewRow();

                for (int i = 0; i < cols; i++)
                {
                    newrow[i] = "";
                }

                dtExcel.Rows.Add(newrow);
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }

            return msg;

        }

        private string delPaxRow(int rowIndex)
        {
            string msg = "";

            try
            {
                int rowCount = dataGridView.Rows.Count;
                dataGridView.Rows.RemoveAt(rowIndex);

                if (rowCount == 2)
                {
                    dataGridView.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }

            return msg;

        }

        private void initialiseGrid()
        {
            try
            {
                int rowCount = dataGridView.Rows.Count;
                dataGridView.Rows.RemoveAt(dataGridView.CurrentRow.Index);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
