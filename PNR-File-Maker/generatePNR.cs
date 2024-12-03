using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PNR_File_Maker
{
    partial class frmMain
    {
        string pnrFilePath;
        


        private void writePNR(DataRow row)
        {
            
           
            //DataRow row = dtPNR.Rows[rowID];

            //pnrFilePath = fileSavePath + "\\" + nFlight + "_" + nArrivalTime.Replace(":", "") + "_" + row["BookingReferenceId"].ToString();

            string flightNatDocNo = nFlight + "_" + nArrivalTime.Replace(":", "") + "_" + row["Nationality"].ToString() + "_" + row["DocumentNo"].ToString();

            pnrFilePath = fileSavePath + "\\" + flightNatDocNo;

            createFolder(pnrFilePath);

            //pnrFilePath = pnrFilePath + "\\" + row["BookingReferenceId"].ToString();

            pnrFilePath = pnrFilePath + "\\" + flightNatDocNo;


            pnrOpen(row, "01_PNR_CREATION", C_PNR_CREATION, "PNR_CREATION");
            pnrBase(row, "02_TICKETING", C_PNR_TICKERTING, "TKT");
            pnrBase(row, "03_PAX_DATA_UPDATE", C_PNR_PAX_DATA_UPDATE, "PAX_DATA_UPDATE");
            pnrBase(row, "04_ITINERARY_UPDATE", C_PNR_ITINERARY_UPDATE, "ITINERARY_UPDATE");
            pnrBase(row, "05_PAYMENT", C_PNR_PAYMENT, "PAYMENT");
            pnrBase(row, "06_CHECK_IN", C_PNR_CHECKIN, "CHECK_IN");
            pnrBase(row, "07_BOARDING", C_PNR_BOARDING, "BOARDING");
            pnrBase(row, "08_FLIGHT_STATUS_UPDATE", C_PNR_FLIGHT_STATUS_UPDATE, "FLIGHT_STATUS_UPDATE");
            pnrBase(row, "09_DEPARTURE", C_PNR_DEPARTURE, "DEPARTURE");
            pnrBase(row, "10_ARRIVAL", C_PNR_ARRIVAL, "ARRIVAL");
            pnrBase(row, "11_TRANSFER", C_PNR_TRANSFER, "TRANSFER");
            pnrBase(row, "12_BAGGAGE_HANDLING", C_PNR_BAGGAGE_HANDLING, "BAGGAGE_HANDLING");
            pnrBase(row, "13_CHANGES_CANX", C_PNR_CHANGES, "CHANGES");
            pnrBase(row, "14_WAIT_LIST_CLEARANCE", C_PNR_WAIT_LIST_CLEARANCE, "WAIT_LIST_CLEARANCE");
            pnrBase(row, "15_NO_SHOW", C_PNR_NOSHOW, "NOSH");
            pnrBase(row, "16_UPGRADE_DOWNGRADE", C_PNR_UPGRADE_DOWNGRADE, "UPGRADE");
            pnrBase(row, "17_SPECIAL_SERVICE_REQUEST", C_PNR_SPECIAL_SERVICE_REQUEST, "SSR");
            pnrBase(row, "18_FREQUENT_FLYER_CREDIT", C_PNR_FREQUENT_FLYER_CREDIT, "FREQUENT_FLYER_CREDIT");
            pnrBase(row, "19_REMARK", C_PNR_REMARK, "REMARK");
            pnrBase(row, "20_PNR_CLOSURE", C_PNR_CLOSURE, "PNR_CLOSURE");

        }


        private void writePNR()
        {

            if (cbPNR.Checked)
            {
                foreach (DataRow row in dtExcel.Rows)
                {
                    writePNR(row);
                }

            }
            else
            {
                foreach (DataRow row in dtExcel.Rows)
                {
                    if (row["PNR"].ToString() == "Y")
                    {
                        writePNR(row);
                    }
                }
            }

        }



        private void pnrBase(DataRow row, string pnrType, string[] pnrTemplate, string pnrEvent)
        {
            string newFilename = pnrFilePath + "_"+ pnrType + ".xml";

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
                writer.WriteString(pnrEvent);
                writer.WriteEndElement();


                foreach (string column in pnrTemplate)  //loop through the columns. 
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


        private void pnrOpen(DataRow row, string pnrType, string[] pnrTemplate, string pnrEvent)
        {
            string newFilename = pnrFilePath + "_" + pnrType + ".xml";

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
                writer.WriteElementString("FlightNumber", nFlight);
                writer.WriteElementString("NoofSeatofFlight", txtNoofSeatofFlight.Text);
                writer.WriteElementString("NoofPassengers", txtNoofPassengers.Text);
                writer.WriteElementString("OriginPort", txtOriginPort.Text);
                writer.WriteElementString("DestinationPort", txtDestinationPort.Text);
                writer.WriteElementString("DepartureDateTime", nDepartureTime);
                writer.WriteElementString("ArrivalDateTime", nArrivalTime);
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
                writer.WriteString(pnrEvent);
                writer.WriteEndElement();

                foreach (string column in pnrTemplate)  //loop through the columns. 
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


        private void createFolder(string folderName)
        {
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(folderName))
                {
                    Directory.Delete(folderName,true);
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(folderName);
                
                                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


    }
}
