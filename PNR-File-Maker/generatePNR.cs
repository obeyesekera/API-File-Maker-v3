using System.Data;
using System.Data.Common;
using System.Text;
using System.Xml;

namespace PNR_File_Maker
{
    partial class frmMain
    {
        private void writePNR(string flight, string arrivalTime, string departureTime, int rowID )
        {
            DataRow row = dtExcel.Rows[rowID];

            string newFilename = fileSavePath + "\\" + flight + "_" + arrivalTime.Replace(":", "") + "_" + row["BookingReferenceId"].ToString();
                     
            pnrOpen(newFilename, flight, arrivalTime, departureTime, row);
            pnrTicketing(newFilename, flight, row);
            pnrPaxDataUpdate(newFilename, row);
            pnrItineraryUpdate(newFilename, arrivalTime, departureTime, row);

        }


        private void writePNR()
        {
            string flight = txtFlightPrefix.Text + txtFlightNumber.Text;
            string arrivalTime = txtArrivalDate.Text + "T" + dtArrivalTime.Text.ToString();
            string departureTime = txtDepartureDate.Text + "T" + dtDepartureTime.Text.ToString();

            writePNR(flight, arrivalTime, departureTime, 0);
        }



        //1_PNR Creation (Booking Creation)
        private void pnrOpen(string filePath, string flight, string arrivalTime, string departureTime, DataRow row)
        {
            string newFilename = filePath + "_01_PNR_CREATION.xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = false;

            using (XmlWriter writer = XmlWriter.Create(newFilename, settings))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("root");

                writer.WriteStartElement("FlightDetails");
                writer.WriteElementString("FlightNumber", flight);
                writer.WriteElementString("NoofSeatofFlight", txtNoofSeatofFlight.Text);
                writer.WriteElementString("NoofPassengers", txtNoofPassengers.Text);
                writer.WriteElementString("OriginPort", txtOriginPort.Text);
                writer.WriteElementString("DestinationPort", txtDestinationPort.Text);
                writer.WriteElementString("DepartureDateTime", departureTime);
                writer.WriteElementString("ArrivalDateTime", arrivalTime);
                writer.WriteElementString("AircraftType", txtAircraftType.Text);
                writer.WriteEndElement();

                writer.WriteStartElement("SeatDetails");

                writer.WriteStartElement("FirstClass");
                writer.WriteElementString("Type", "1-2-1");
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[0, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[0, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[0, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[0, 2].ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("BusinessClass");
                writer.WriteElementString("Type", "2-2-2");
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[1, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[1, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[1, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[1, 2].ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("EconomyClass");
                writer.WriteElementString("Type", "3-4-3");
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[2, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[2, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[2, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[2, 2].ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("Passengers");
                
                writer.WriteStartElement("Passenger");

                writer.WriteStartElement("Event");
                writer.WriteString("PNR_CREATION");
                writer.WriteEndElement();

                foreach (string column in colPnrOpen)  //loop through the columns. 
                {
                    writer.WriteStartElement(column);
                    writer.WriteString(row[column].ToString());
                    writer.WriteFullEndElement();

                }

                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Flush();
            }
        }


        //2_Ticketing (TKT)
        private void pnrTicketing(string filePath, string flight, DataRow row)
        {

            string newFilename = filePath + "_02_TICKETING.xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = false;

            using (XmlWriter writer = XmlWriter.Create(newFilename, settings))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("root");

                writer.WriteStartElement("Passengers");

                writer.WriteStartElement("Passenger");

                writer.WriteStartElement("Event");
                writer.WriteString("TKT");
                writer.WriteEndElement();


                writer.WriteStartElement("BookingReferenceId");
                writer.WriteString(row["BookingReferenceId"].ToString());
                writer.WriteFullEndElement();

                writer.WriteStartElement("DocumentNo");
                writer.WriteString(row["DocumentNo"].ToString());
                writer.WriteFullEndElement();

                writer.WriteStartElement("TicketNumber");
                writer.WriteString("TK"+ row["BookingReferenceId"].ToString());
                writer.WriteFullEndElement();

                writer.WriteStartElement("TicketIssueDate");
                writer.WriteString(row["BookingDate"].ToString());
                writer.WriteFullEndElement();

                writer.WriteStartElement("TicketingCarrier");
                writer.WriteString(flight.Substring(0,2));
                writer.WriteFullEndElement();

                writer.WriteStartElement("FareBasis");
                writer.WriteString("FLEX");
                writer.WriteFullEndElement();


                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Flush();
            }

        }


        //3_ Passenger Data Updates
        private void pnrPaxDataUpdate(string filePath, DataRow row)
        {

            string newFilename = filePath + "_03_PAX_DATA_UPDATE.xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = false;

            using (XmlWriter writer = XmlWriter.Create(newFilename, settings))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("root");

                writer.WriteStartElement("Passengers");

                writer.WriteStartElement("Passenger");

                writer.WriteStartElement("Event");
                writer.WriteString("PAX_DATA_UPDATE");
                writer.WriteEndElement();


                foreach (string column in colPnrPaxDataUpdate)  //loop through the columns. 
                {
                    writer.WriteStartElement(column);
                    writer.WriteString(row[column].ToString());
                    writer.WriteFullEndElement();

                }


                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Flush();
            }

        }


        //4_Itinerary Updates
        private void pnrItineraryUpdate(string filePath, string arrivalTime, string departureTime, DataRow row)
        {

            string newFilename = filePath + "_04_ITINERARY_UPDATE.xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = false;

            using (XmlWriter writer = XmlWriter.Create(newFilename, settings))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("root");

                writer.WriteStartElement("Passengers");

                writer.WriteStartElement("Passenger");

                writer.WriteStartElement("Event");
                writer.WriteString("ITINERARY_UPDATE");
                writer.WriteEndElement();


                foreach (string column in colPnrItineraryUpdate)  //loop through the columns. 
                {
                    writer.WriteStartElement(column);
                    writer.WriteString(row[column].ToString());
                    writer.WriteFullEndElement();

                }

                writer.WriteStartElement("NewDepartureDateTime");
                writer.WriteString(departureTime);
                writer.WriteFullEndElement();

                writer.WriteStartElement("NewArrivalDateTime");
                writer.WriteString(arrivalTime);
                writer.WriteFullEndElement();


                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Flush();
            }

        }





        //5_Payment (PYMT)
        //6_Changes/Cancellations (CHNG/CANX)
        //7_Check-In (CKIN)
        //8_Baggage Handling (BAG)
        //9_Boarding (BRD)
        //10_Flight Status Updates (FLT)
        //11_Departure (DEP)
        //12_Arrival (ARR)
        //13_Transfer or Connection (TRF/CONN)
        //14_Waitlist Clearance (WLCL)
        //15_No-Show (NOSH)
        //16_Upgrade/Downgrade (UPG/DWG)
        //17_Special Service Request (SSR)
        //18_Frequent Flyer Credit (FFR)
        //19_Remark or Note (RMK)
        //20_PNR Closure (PNRCL)


    }
}
