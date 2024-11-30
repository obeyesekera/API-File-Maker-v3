using System.Collections.Generic;
using System;
using System.Reflection;

namespace PNR_File_Maker
{
    partial class frmMain
    {
        string nFlight;
        string nArrivalTime;
        string nDepartureTime;
        string nCloseDate;


        private string flyMiles()
        {
            string nMiles = randomNumber(1000, 9999).ToString();

            return nMiles;
        }



        List<string> unUsedSeates;

        private void defineSeats()
        {
            unUsedSeates = new List<string>();

            int i;
            //int premiumRows = Int32.Parse(txtNoOfPremiumClassRows.Text);
            //int businessRows = Int32.Parse(txtNoOfBusinessClassRows.Text);
            //int economyRows = Int32.Parse(txtNoOfEconomyClassRows.Text);

            //PremiumClassRows


            if (premiumRows > 0)
            {
                int premStart = 1;
                int premEnd = premStart + premiumRows - 1;

                //Rows, StartingRow, EndingRow, Seats
                seatArray[0, 0] = premiumRows;
                seatArray[0, 1] = premStart;
                seatArray[0, 2] = premEnd;
                seatArray[0, 3] = premiumRows * 4;

                for (i = premStart; i <= premEnd; i++)
                {
                    unUsedSeates.Add(i + "A");
                    unUsedSeates.Add(i + "E");
                    unUsedSeates.Add(i + "F");
                    unUsedSeates.Add(i + "J");
                    //MessageBox.Show("PremiumClassRows" + i);
                }
            }
            else
            {
                i = 0;
            }


            //BusinessClassRows
            if (businessRows > 0)
            {
                int busiStart = i;
                int busiEnd = busiStart + businessRows - 1;

                //Rows, StartingRow, EndingRow, Seats
                seatArray[1, 0] = businessRows;
                seatArray[1, 1] = busiStart;
                seatArray[1, 2] = busiEnd;
                seatArray[1, 3] = businessRows * 6;

                for (i = busiStart; i <= busiEnd; i++)
                {
                    unUsedSeates.Add(i + "A");
                    unUsedSeates.Add(i + "B");
                    unUsedSeates.Add(i + "E");
                    unUsedSeates.Add(i + "F");
                    unUsedSeates.Add(i + "I");
                    unUsedSeates.Add(i + "J");
                    //MessageBox.Show("BusinessClassRows" + i);
                }
            }

            //EconomyClassRows
            if (economyRows > 0)
            {
                int ecoStart = i;
                int ecoEnd = ecoStart + economyRows - 1;

                //Rows, StartingRow, EndingRow, Seats
                seatArray[2, 0] = economyRows;
                seatArray[2, 1] = ecoStart;
                seatArray[2, 2] = ecoEnd;
                seatArray[2, 3] = economyRows * 10;

                for (i = ecoStart; i <= ecoEnd; i++)
                {
                    unUsedSeates.Add(i + "A");
                    unUsedSeates.Add(i + "B");
                    unUsedSeates.Add(i + "C");
                    unUsedSeates.Add(i + "D");
                    unUsedSeates.Add(i + "E");
                    unUsedSeates.Add(i + "F");
                    unUsedSeates.Add(i + "G");
                    unUsedSeates.Add(i + "H");
                    unUsedSeates.Add(i + "I");
                    unUsedSeates.Add(i + "J");
                    //MessageBox.Show("EconomyClassRows" + i);
                }
            }
            //MessageBox.Show(unUsedSeates.Count.ToString());
        }

        private string allocateSeat()
        {
            int index = randomNumber(0, unUsedSeates.Count);
            string seatNo = unUsedSeates[index];

            unUsedSeates.RemoveAt(index);

            return seatNo;
        }

        private string getOldSeat(string newSeat)
        {
            string oldSeat;

            if (unUsedSeates.Count > 0)
            {
                oldSeat = unUsedSeates[0];
            }
            else
            {
                oldSeat = newSeat;
            }

            return oldSeat;
        }


        //Rows, StartingRow, EndingRow, Seats
        int[,] seatArray = {    { 0, 0, 0 ,0 }, //Premium
                                { 0, 0, 0 ,0 }, //Business
                                { 0, 0, 0 ,0 }  //Economy
        };

        int premiumRows;
        int businessRows;
        int economyRows;

        private void calcSeats()
        {


            if (txtNoOfPremiumClassRows.Text == "")
            {
                premiumRows = 0;
            }
            else
            {
                premiumRows = Int32.Parse(txtNoOfPremiumClassRows.Text);
            }


            if (txtNoOfBusinessClassRows.Text == "")
            {
                businessRows = 0;
            }
            else
            {
                businessRows = Int32.Parse(txtNoOfBusinessClassRows.Text);
            }


            if (txtNoOfEconomyClassRows.Text == "")
            {
                economyRows = 0;
            }
            else
            {
                economyRows = Int32.Parse(txtNoOfEconomyClassRows.Text);
            }


            int totSeats = (premiumRows * 4)
                + (businessRows * 6)
                + (economyRows * 10);

            txtNoofSeatofFlight.Text = totSeats.ToString();
        }

        private void setFlight()
        {
            nFlight = txtFlightPrefix.Text + txtFlightNumber.Text;
            nArrivalTime = txtArrivalDate.Text + "T" + dtArrivalTime.Text.ToString();
            nDepartureTime = txtDepartureDate.Text + "T" + dtDepartureTime.Text.ToString();
            nCloseDate = txtArrivalDate.Text;
        }


    }
}
