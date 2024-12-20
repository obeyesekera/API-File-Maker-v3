using System.Data;
using System.Text;
using System.Xml;

namespace PNR_File_Maker
{
    partial class frmMain
    {

        private void writeAPI(string flight, string arrivalTime, string departureTime)
        {
            string newFilename = fileSavePath + "\\" + flight + "_" + arrivalTime.Replace(":", "") + ".xml";
            writeAPI(newFilename, flight, arrivalTime, departureTime);
        }


        private void writeAPI()
        {
            string flight = txtFlightPrefix.Text + txtFlightNumber.Text;
            string arrivalTime = txtArrivalDate.Text + "T" + dtArrivalTime.Text.ToString();
            string departureTime = txtDepartureDate.Text + "T" + dtDepartureTime.Text.ToString();
            string newFilename = fileSavePath + "\\" + flight + "_" + arrivalTime.Replace(":", "") + ".xml";
            writeAPI(newFilename, flight, arrivalTime, departureTime);
        }


        private void writeAPI(string newFilename, string flight, string arrivalTime, string departureTime)
        {
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
                writer.WriteElementString("AircraftType", nType);
                writer.WriteEndElement();

                writer.WriteStartElement("SeatDetails");

                writer.WriteStartElement("FirstClass");
                writer.WriteElementString("Type", getRowDigits(lblFirstClass.Text));
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[0, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[0, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[0, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[0, 2].ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("BusinessClass");
                writer.WriteElementString("Type", getRowDigits(lblBusinessClass.Text));
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[1, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[1, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[1, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[1, 2].ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("PremiumClass");
                writer.WriteElementString("Type", getRowDigits(lblPremiumClass.Text));
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[2, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[2, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[2, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[2, 2].ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("EconomyClass");
                writer.WriteElementString("Type", getRowDigits(lblEconomyClass.Text));
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[3, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[3, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[3, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[3, 2].ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("Passengers");

                foreach (DataRow row in dtExcel.Rows)
                {
                    writer.WriteStartElement("Passenger");

                    foreach (string column in C_API_CREATION)  //loop through the columns. 
                    {
                        writer.WriteStartElement(column);
                        writer.WriteString(row[column].ToString());
                        writer.WriteFullEndElement();

                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Flush();
            }
        }



    }
}
