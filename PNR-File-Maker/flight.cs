using System.Collections.Generic;
using System;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;

namespace PNR_File_Maker
{
    partial class frmMain
    {
        string nType;
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


            int i=1;

            //FirstClassRows
            if (firstRows > 0)
            {
                i = defineSeatClass(lblFirstClass.Text, firstRows, 0, i);
            }
            else
            {
                setUndefinedClass(0);
            }

            //BusinessClassRows
            if (businessRows > 0)
            {
                i = defineSeatClass(lblBusinessClass.Text, businessRows, 1, i);
            }
            else
            {
                setUndefinedClass(1);
            }

            //PremiumClassRows
            if (premiumRows > 0)
            {
                i = defineSeatClass(lblPremiumClass.Text, premiumRows, 2, i);
            }
            else
            {
                setUndefinedClass(2);
            }

            //EconomyClassRows
            if (economyRows > 0)
            {
                i = defineSeatClass(lblEconomyClass.Text, economyRows, 3, i);
            }
            else
            {
                setUndefinedClass(3);
            }


            /*

            //PremiumClassRows
            if (premiumRows > 0)
            {

                int premStart = i;
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
                }
            }
        
        */


        }

        private string getRowSeats(string rowLayout)
        {
            string seates = Regex.Replace(rowLayout, "[^A-Z]", "");
            return seates;
        }

        private string getRowDigits(string rowLayout)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;

            foreach (char c in rowLayout)
            {
                if (c == '-')
                {
                    sb.Append(i);
                    sb.Append(c);
                    i = 0;
                }
                else
                {
                    i++;
                }
                
            }
            sb.Append(i);



            string digits = sb.ToString();
            return digits;
        }



        private int defineSeatClass(string rowLayout, int rowCount, int rowType, int i)
        {
            
            int start = i;
            int end = start + rowCount - 1;
            string seates = getRowSeats(rowLayout);
            int rowSize = seates.Length;

            //Rows, StartingRow, EndingRow, Seats
            seatArray[rowType, 0] = rowCount;
            seatArray[rowType, 1] = start;
            seatArray[rowType, 2] = end;
            seatArray[rowType, 3] = rowCount * rowSize;

            for (i = start; i <= end; i++)
            {
                foreach (char s in seates)
                {
                    unUsedSeates.Add(i.ToString() + s);
                }
            }

            return i;
        }

        private void setUndefinedClass(int rowType)
        {
            //Rows, StartingRow, EndingRow, Seats
            seatArray[rowType, 0] = 0;
            seatArray[rowType, 1] = 0;
            seatArray[rowType, 2] = 0;
            seatArray[rowType, 3] = 0;
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
        int[,] seatArray = {    { 0, 0, 0 ,0 }, //First
                                { 0, 0, 0 ,0 }, //Business
                                { 0, 0, 0 ,0 }, //Premium
                                { 0, 0, 0 ,0 }  //Economy
        };

        int firstRows;
        int businessRows;
        int premiumRows;
        int economyRows;

        private void calcSeats()
        {


            if (txtNoOfFirstClassRows.Text.Trim() == "")
            {
                firstRows = 0;
                lblFirstClass.Visible = false;
            }
            else
            {
                firstRows = Int32.Parse(txtNoOfFirstClassRows.Text.Trim());
                if (firstRows>0)
                {
                    lblFirstClass.Visible = true;
                }
                else
                {
                    lblFirstClass.Visible = false;
                }
            }


            if (txtNoOfBusinessClassRows.Text.Trim() == "")
            {
                businessRows = 0;
                lblBusinessClass.Visible = true;
            }
            else
            {
                businessRows = Int32.Parse(txtNoOfBusinessClassRows.Text.Trim());
                if (businessRows > 0)
                {
                    lblBusinessClass.Visible = true;
                }
                else
                {
                    lblBusinessClass.Visible = false;
                }
            }


            if (txtNoOfPremiumClassRows.Text.Trim() == "")
            {
                premiumRows = 0;
                lblPremiumClass.Visible = true;
            }
            else
            {
                premiumRows = Int32.Parse(txtNoOfPremiumClassRows.Text.Trim());
                if (premiumRows > 0)
                {
                    lblPremiumClass.Visible = true;
                }
                else
                {
                    lblPremiumClass.Visible = false;
                }
            }

            if (txtNoOfEconomyClassRows.Text.Trim() == "")
            {
                economyRows = 0;
                lblEconomyClass.Visible = true;
            }
            else
            {
                economyRows = Int32.Parse(txtNoOfEconomyClassRows.Text.Trim());
                if (economyRows > 0)
                {
                    lblEconomyClass.Visible = true;
                }
                else
                {
                    lblEconomyClass.Visible = false;
                }
            }


            int totSeats = (firstRows * getRowSeats(lblFirstClass.Text).Length)
                + (businessRows * getRowSeats(lblBusinessClass.Text).Length)
                + (premiumRows * getRowSeats(lblPremiumClass.Text).Length)
                + (economyRows * getRowSeats(lblEconomyClass.Text).Length);



            txtNoofSeatofFlight.Text = totSeats.ToString();
        }

        private void setFlight()
        {
            
            nFlight = txtFlightPrefix.Text + txtFlightNumber.Text;
            nArrivalTime = txtArrivalDate.Text + "T" + dtArrivalTime.Text.ToString();
            nDepartureTime = txtDepartureDate.Text + "T" + dtDepartureTime.Text.ToString();
            nCloseDate = txtArrivalDate.Text;
        }

        private void setAircraft()
        {
            DataRow[] result = dtAircrafts.Select("aID = '" + cmbAircraftType.SelectedIndex + "'");

            nType = result[0]["Aircraft"] as string;

            txtNoOfFirstClassRows.Text = result[0]["FirstClassRows"] as string;
            txtNoOfBusinessClassRows.Text = result[0]["BusinessRows"] as string;
            txtNoOfPremiumClassRows.Text = result[0]["PremiumRows"] as string;
            txtNoOfEconomyClassRows.Text = result[0]["EconomyRows"] as string;

            lblFirstClass.Text = result[0]["FirstClassLayout"] as string;
            lblBusinessClass.Text = result[0]["BusinessLayout"] as string;
            lblPremiumClass.Text = result[0]["PremiumLayout"] as string;
            lblEconomyClass.Text = result[0]["EconomyLayout"] as string;
        }

    }
}
