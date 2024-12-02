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
            setFlight();
            defineSeats();
            initializeDataset();
            //initializeDataset2();
            initialiseGrid();

            int totPax = Int32.Parse(txtRequiredPax.Text);
            string origin = txtOriginPort.Text;
            string destination = txtDestinationPort.Text;

            //Last row of economy class
            string crewRow = seatArray[2, 2].ToString();


            for (int px = 1; px <= totPax; px++)
            {

                DataRow newrow = dtExcel.NewRow();
                //DataRow newrow2 = dtPNR.NewRow();
                DataRow country = rndCountry();
                string alpha2 = country[1].ToString();
                string alpha3 = country[2].ToString();
                string countryCode = country[4].ToString();
                string countryName = country[0].ToString();

                DataRow ssrRow = rndSSR();
                string ssrCode = ssrRow[0].ToString();
                string ssrDetails = ssrRow[1].ToString();

                string passengerType = "PAX";
                string tdNumber = rndTravelDoc(alpha2);  //"SG1025561";
                string tdType = "P";
                string seatNumber = allocateSeat();  //"22A";
                string oldSeat = getOldSeat(seatNumber);

                string portOfEmbark = origin;
                string portOfDisembark = destination;
                string firstTransitPorts = "";

                string transferLocation = origin;
                string nextFlightNumber = nFlight;
                string nextFlightDepartureTime = nDepartureTime;

                string newDepartureDateTime = nDepartureTime;
                string checkinTime = newDepartureDateTime;
                string boardingPass = "Yes";
                string boardingTime = checkinTime;
                string boardingGate = randomNumber(10, 99).ToString();
                string flightStatus = "Delayed";

                string changeType = "FlightChange";
                string newFlightNumber = nFlight;

                string noShowStatus = "Yes";

                string newArrivalDateTime = nArrivalTime;

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

                string givenName = generateName(5);
                string surName = generateName(7);
                string fullName = givenName + " " + surName;
                string dob = rndDOB();  //"18/06/1996";
                string gender = rndGender();
                string expiryDate = rndExpiryDate();
                string bookingRef = rndBookingRef(txtFlightPrefix.Text); //"UL12345";
                string ticketNo = "TK" + bookingRef;
                string bookingRefType = "AVF";
                string bookingDate = rndBookingDate();
                string ticketDate = bookingDate;
                string ticketCareer = nFlight.Substring(0, 2);
                string ticketFareBasis = "FLEX";
                string baggageTagNumber = "B" + bookingRef;
                string baggageStatus = "Checked-In";
                string baggageDropOffLocation = destination;
                string visaNumber = rndTravelDoc("VP");  //"VP2023048";
                string checkinLuggage = "1";
                string reservPayID = randomNumber(10000, 99999).ToString();  //"97059";
                string payAmount = "343";
                string payCardNumber = rndCardNo();  //"23118281";;
                string payAuthCode = randomNumber(100, 999).ToString();  //"877";
                string payTerminalID = randomNumber(10000, 99999).ToString();  //"70271";
                string payCurrency = "USD";
                string payMerchantID = randomNumber(10000, 99999).ToString();  //"41429";
                string payMethod = rndPayMetod();  //"CARD";
                string paxEmailAdd = paxEmail(givenName, surName); // "hana.ahmad@gmail.com";
                string paxContact = paxPhoneNo(countryCode); ; // "+94888888888";
                string paxAddLine1 = paxAddress1(alpha3); // "32/424, Main Street";
                int agentCode = randomNumber(1, 9);
                string agntID = agentID(alpha3, agentCode);
                string agentEmailAdd = agentEmail(agntID); // "agent.a@gmail.com";
                string agentContact = agentPhoneNo(countryCode, agentCode); // "+94888888888";

                if (seatNumber.Substring((seatNumber.Length - 1), 1) == "E") //Transit PAX on E seats
                {
                    hotelAlpha3 = alpha3;
                    hotelCountry = countryName;
                }

                int hotelCode = randomNumber(1, 9);
                string hotelResName = hotelName(hotelAlpha3, hotelCode); // "Cinnamon Lake";
                string hotelResAdd1 = hotelAddress1(hotelCode); // "Galle Road";

                string frequentFlyerNumber = alpha2+"-"+tdNumber;
                string ffMilesCredited = flyMiles();

                string remarkText = generateRemarks();

                string pnrClosureDate = nCloseDate;

                newrow["PassengerType"] = passengerType;
                //newrow2["PassengerType"] = passengerType;

                newrow["DocType"] = tdType;
                //newrow2["DocType"] = tdType;

                newrow["DocumentNo"] = tdNumber;
                //newrow2["DocumentNo"] = tdNumber;

                newrow["Nationality"] = alpha3;
                //newrow2["Nationality"] = alpha3;
                                
                newrow["GivenName"] = givenName;
                //newrow2["GivenName"] = givenName;

                newrow["Surname"] = surName;
                //newrow2["Surname"] = surName;

                newrow["FullName"] = fullName;
                //newrow2["FullName"] = fullName;

                newrow["DateOfBirth"] = dob;
                //newrow2["DateOfBirth"] = dob;

                newrow["Gender"] = gender;
                //newrow2["Gender"] = gender;
                                
                newrow["ExpireDate"] = expiryDate;
                //newrow2["ExpireDate"] = expiryDate;

                newrow["CountryOfResidence"] = alpha3;
                //newrow2["CountryOfResidence"] = alpha3;

                newrow["DocIssueCountry"] = alpha3;
                //newrow2["DocIssueCountry"] = alpha3;

                newrow["BookingReferenceId"] = bookingRef;
                newrow["TicketNumber"] = ticketNo;
                //newrow2["BookingReferenceId"] = bookingRef;
                //newrow2["TicketNumber"] = ticketNo;

                newrow["BookingReferenceType"] = bookingRefType;
                //newrow2["BookingReferenceType"] = bookingRefType;

                newrow["BookingDate"] = bookingDate;
                //newrow2["BookingDate"] = bookingDate;
                newrow["TicketIssueDate"] = ticketDate;
                newrow["TicketingCarrier"] = ticketCareer;
                newrow["FareBasis"] = ticketFareBasis;

                //newrow2["TicketIssueDate"] = ticketDate;
                //newrow2["TicketingCarrier"] = ticketCareer;
                //newrow2["FareBasis"] = ticketFareBasis;

                newrow["SeatNo"] = seatNumber;
                //newrow2["SeatNo"] = seatNumber;
                newrow["ClearedSeatNo"] = seatNumber;
                newrow["OldSeatNo"] = oldSeat;
                newrow["NewSeatNo"] = seatNumber;

                //newrow2["ClearedSeatNo"] = seatNumber;
                //newrow2["OldSeatNo"] = oldSeat;
                //newrow2["NewSeatNo"] = seatNumber;

                newrow["PortOfEmbark"] = portOfEmbark;
                //newrow2["PortOfEmbark"] = portOfEmbark;
                newrow["CheckInTime"] = checkinTime;
                newrow["BoardingPassIssued"] = boardingPass;
                newrow["BoardingTime"] = boardingTime;
                newrow["Gate"] = boardingGate;
                newrow["FlightStatus"] = flightStatus;

                newrow["BaggageTagNumber"] = baggageTagNumber;
                newrow["BaggageStatus"] = baggageStatus;
                newrow["BaggageDropOffLocation"] = baggageDropOffLocation;

                newrow["TransferLocation"] = transferLocation;
                newrow["NextFlightNumber"] = nextFlightNumber;
                newrow["NextFlightDepartureTime"] = nextFlightDepartureTime;

                newrow["PortOfDisembark"] = portOfDisembark;
                //newrow2["PortOfDisembark"] = portOfDisembark;

                newrow["FirstTransitPorts"] = firstTransitPorts;

                newrow["NewDepartureDateTime"] = newDepartureDateTime;
                newrow["NewDepartureTime"] = newDepartureDateTime;
                newrow["ActualDepartureTime"] = newDepartureDateTime;

                
                

                newrow["NewArrivalDateTime"] = newArrivalDateTime;
                newrow["ActualArrivalTime"] = newArrivalDateTime;

                newrow["VisaNo"] = visaNumber;
                //newrow2["VisaNo"] = visaNumber;

                newrow["VisaExpiryDate"] = expiryDate;
                //newrow2["VisaExpiryDate"] = expiryDate;

                newrow["NoofCheckingluggage"] = checkinLuggage;

                newrow["ReservationPaymentID"] = reservPayID;

                newrow["PaymentCardHolder"] = fullName;

                newrow["PaymentAmount"] = payAmount;
                //newrow2["PaymentAmount"] = payAmount;
                
                newrow["PaymentExpirationDate"] = expiryDate; 
                
                newrow["PaymentCardNumber"] = payCardNumber;

                newrow["PaymentAuthorizationcode"] = payAuthCode;

                newrow["PaymentTerminalID"] = payTerminalID;

                newrow["PaymentCurrencyPaid"] = payCurrency;
                newrow["Currency"] = payCurrency;
                
                newrow["PaymentMerchantID"] = payMerchantID;

                newrow["PaymentCountry"] = alpha3;  

                newrow["PaymentMethod"] = payMethod;
                //newrow2["PaymentMethod"] = payMethod;
                
                newrow["PaymentDatePaid"] = bookingDate;
                newrow["TransactionDate"] = bookingDate;
                
                newrow["ReservationContactFirstName"] = givenName;
                //newrow2["ReservationContactFirstName"] = givenName;

                newrow["ReservationContactLastName"] = surName;
                //newrow2["ReservationContactLastName"] = surName;

                newrow["ReservationContactGender"] = gender;
                //newrow2["ReservationContactGender"] = gender;


                newrow["PassengerEmail"] = paxEmailAdd;
                //newrow2["PassengerEmail"] = paxEmailAdd;

                newrow["PassengerContact"] = paxContact;
                //newrow2["PassengerContact"] = paxContact;

                newrow["PassengerAddressLine1"] = paxAddLine1;
                //newrow2["PassengerAddressLine1"] = paxAddLine1;

                newrow["PassengerAddressLine2"] = countryName;
                //newrow2["PassengerAddressLine2"] = countryName;



                newrow["AgentID"] = agntID;
                //newrow2["AgentID"] = agntID;

                newrow["AgentEmail"] = agentEmailAdd;
                //newrow2["AgentEmail"] = agentEmailAdd;

                newrow["AgentContact"] = agentContact;
                //newrow2["AgentContact"] = agentContact;



                newrow["PassengerHotelReservationName"] = hotelResName;
                //newrow2["PassengerHotelReservationName"] = hotelResName;

                newrow["PassengerHotelReservationAddressLine1"] = hotelResAdd1;
                //newrow2["PassengerHotelReservationAddressLine1"] = hotelResAdd1;

                newrow["PassengerHotelReservationAddressLine2"] = hotelCountry;
                //newrow2["PassengerHotelReservationAddressLine2"] = hotelCountry;

                newrow["ChangeType"] = changeType;
                newrow["NewFlightNumber"] = newFlightNumber;
                newrow["NewDepartureDateTime"] = newDepartureDateTime;

                newrow["FlightNumber"] = nFlight;
                newrow["NoShowStatus"] = noShowStatus;

                newrow["SSRCode"] = ssrCode;
                newrow["RequestDetails"] = ssrDetails;

                newrow["FrequentFlyerNumber"] = frequentFlyerNumber;
                newrow["MilesCredited"] = ffMilesCredited;

                newrow["RemarkText"] = remarkText;

                newrow["ClosureDate"] = pnrClosureDate;

                dtExcel.Rows.Add(newrow);
                //dtPNR.Rows.Add(newrow2);

                string asdfg = "";
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

                //dtPNR.Rows.RemoveAt(0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
