
using System.Data;
using System;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

namespace PNR_File_Maker
{
    partial class frmMain
    {

        private readonly Random _random = new Random();
        private Random gen = new Random();

        private void SetDateFormat()
        {
            foreach (DataRow row in dtExcel.Rows)
            {
                DateTime dtDateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString());
                row["DateOfBirth"] = dtDateOfBirth.ToString("dd/MM/yyyy");

                DateTime dtExpireDate = DateTime.Parse(row["ExpireDate"].ToString());
                row["ExpireDate"] = dtExpireDate.ToString("dd/MM/yyyy");

                DateTime dtBookingDate = DateTime.Parse(row["BookingDate"].ToString());
                row["BookingDate"] = dtBookingDate.ToString("dd/MM/yyyy");

                DateTime dtVisaExpiryDate = DateTime.Parse(row["VisaExpiryDate"].ToString());
                row["VisaExpiryDate"] = dtVisaExpiryDate.ToString("dd/MM/yyyy");

                DateTime dtPaymentExpirationDate = DateTime.Parse(row["PaymentExpirationDate"].ToString());
                row["PaymentExpirationDate"] = dtPaymentExpirationDate.ToString("dd/MM/yyyy");

                DateTime dtPaymentDatePaid = DateTime.Parse(row["PaymentDatePaid"].ToString());
                row["PaymentDatePaid"] = dtPaymentDatePaid.ToString("dd/MM/yyyy");
            }
        }

        public static string generateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        public static string generatePhone(int len)
        {
            Random r = new Random();
            string[] realNos = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] zeroNos = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string phoneNo = "";
            phoneNo += realNos[r.Next(realNos.Length)].ToUpper();
            phoneNo += zeroNos[r.Next(zeroNos.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                phoneNo += realNos[r.Next(realNos.Length)];
                b++;
                phoneNo += zeroNos[r.Next(zeroNos.Length)];
                b++;
            }

            return phoneNo;
        }

        private DataRow rndCountry()
        {

            Random r = new Random();
            int rInt = r.Next(1, dtCountry.Rows.Count);

            DataRow countryRow = dtCountry.Rows[rInt];

            return countryRow;
        }



        public int randomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }


        private string rndDOB()
        {
            DateTime start = new DateTime(1945, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private string rndExpiryDate()
        {
            DateTime start = DateTime.Today;
            int range = 100;
            return start.AddDays(gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private string rndBookingDate()
        {
            DateTime start = DateTime.Today;
            int range = 100;
            return start.AddDays(-gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private string rndBookingRef(string prefix)
        {
            var refBuilder = new StringBuilder();
            refBuilder.Append(prefix);
            refBuilder.Append(randomNumber(10000, 99999));

            return refBuilder.ToString();
        }

        private string rndTravelDoc(string prefix)
        {
            var tdBuilder = new StringBuilder();
            tdBuilder.Append(prefix);
            tdBuilder.Append(randomNumber(10000, 99999));

            return tdBuilder.ToString();
        }

        private string rndVisa(string prefix)
        {
            var visaBuilder = new StringBuilder();
            visaBuilder.Append(prefix);
            visaBuilder.Append(randomNumber(10000, 99999));

            return visaBuilder.ToString();
        }

        private string rndCardNo()
        {
            var cardBuilder = new StringBuilder();
            cardBuilder.Append(randomNumber(1000, 9999));
            cardBuilder.Append(randomNumber(1000, 9999));
            return cardBuilder.ToString();
        }

        private string paxPhoneNo(string prefix)
        {
            int digits = 11 - prefix.Length;
            var phoneBuilder = new StringBuilder();
            phoneBuilder.Append("+");
            phoneBuilder.Append(prefix);
            phoneBuilder.Append(generatePhone(digits));

            return phoneBuilder.ToString();
        }

        private string paxEmail(string givenName, string surName)
        {
            var emailBuilder = new StringBuilder();
            emailBuilder.Append(givenName.ToLower() + "." + surName.ToLower());
            emailBuilder.Append(randomNumber(100, 999));
            emailBuilder.Append("@example.com");

            return emailBuilder.ToString();
        }



        private string paxAddress1(string country)
        {
            var addBuilder = new StringBuilder();
            addBuilder.Append(randomNumber(100, 999));
            addBuilder.Append("/");
            addBuilder.Append(randomNumber(10, 99));
            addBuilder.Append(", ");
            int streetNo = randomNumber(1, 9);
            string streetNos = "";
            switch (streetNo)
            {
                case 1:
                    streetNos = "st";
                    break;
                case 2:
                    streetNos = "nd";
                    break;
                case 3:
                    streetNos = "rd";
                    break;
                default:
                    streetNos = "th";
                    break;
            }
            addBuilder.Append(streetNo + streetNos + " Cross Street, ");
            addBuilder.Append(generateName(8));
            return addBuilder.ToString();
        }

        private string rndGender()
        {
            string[] genders = { "M", "F" };

            int rNo = randomNumber(0, 1000);
            int index = rNo % 2;
            return genders[index];
        }

        private string rndPayMetod()
        {
            string[] payMethods = { "CARD", "CASH" };

            int rNo = randomNumber(0, 1000);
            int index = rNo % 2;

            return payMethods[index];
        }

        private string agentID(string country, int code)
        {
            var idBuilder = new StringBuilder();
            idBuilder.Append(country);
            idBuilder.Append(code);

            return idBuilder.ToString();
        }

        private string agentEmail(string agentID)
        {
            var emailBuilder = new StringBuilder();
            emailBuilder.Append("agent");
            emailBuilder.Append("." + agentID.ToLower());
            emailBuilder.Append("@example.com");

            return emailBuilder.ToString();
        }

        private string agentPhoneNo(string prefix, int code)
        {
            double digits = 9 - prefix.Length;
            int rndStart = Convert.ToInt32(Math.Pow(10, digits));
            var phoneBuilder = new StringBuilder();
            phoneBuilder.Append("+");
            phoneBuilder.Append(prefix);
            phoneBuilder.Append(rndStart);
            phoneBuilder.Append(code);

            return phoneBuilder.ToString();
        }

        private string hotelName(string country, int code)
        {
            var hotelBuilder = new StringBuilder();
            hotelBuilder.Append("Grand ");
            hotelBuilder.Append(country);
            hotelBuilder.Append(" Hotel ");
            hotelBuilder.Append(code);

            return hotelBuilder.ToString();
        }

        private string hotelAddress1(int code)
        {
            var addBuilder = new StringBuilder();
            addBuilder.Append(code);
            addBuilder.Append(", Capital City");

            return addBuilder.ToString();
        }


        private void fileDuper()
        {

            int startFlifht = int.Parse(txtFlightNumber.Text);
            int flightCount = int.Parse(txtFileCount.Text);
            int endFlight = startFlifht + flightCount;
            int delayTime = int.Parse(txtDelayTime.Text);

            DateTime newArrivalTime = dtArrivalTime.Value;
            DateTime newDepartureTime = dtDepartureTime.Value;

            int completedFlights = 0;

            for (int i = startFlifht; i < endFlight; i++)
            {
                if (i > startFlifht)
                {
                    newArrivalTime = newArrivalTime.AddMinutes(delayTime);
                    newDepartureTime = newDepartureTime.AddMinutes(delayTime);
                }

                string newFlight = txtFlightPrefix.Text + i;
                string newArrivalTimeString = newArrivalTime.ToString("yyyy-MM-dd") + "T" + newArrivalTime.ToString("HH:mm:ss");
                string newDepartureTimeString = newDepartureTime.ToString("yyyy-MM-dd") + "T" + newDepartureTime.ToString("HH:mm:ss");

                generatePaxData();
                writeAPI(newFlight, newArrivalTimeString, newDepartureTimeString);
                //writePNR(newFlight, newArrivalTimeString, newDepartureTimeString, 0);

                completedFlights++;

                txtFileCount.Text = completedFlights + " / " + flightCount;
            }
        }

        private string duplicateRow()
        {
            string msg = "";

            try
            {
                DataRowView currentDataRowView = (DataRowView)dataGridView.CurrentRow.DataBoundItem;
                DataRow row = currentDataRowView.Row;
                DataRow newrow = dtExcel.NewRow();

                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    newrow[i] = row.ItemArray[i];
                }

                dtExcel.Rows.Add(newrow);
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
            }

            return msg;
        }


        private Tuple<string, string> autoGenerate(string fileCount)
        {
            string msg = "";
            string typ = "I";

            try
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.Description = "Save API Files to path";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    fileSavePath = folderDialog.SelectedPath;
                    fileDuper();

                    msg = fileCount + " files Generated";
                    typ = "I";

                    dataGridView.DataSource = null;
                    txtFileCount.Text = fileCount;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message.ToString();
                typ = "E";
            }


            return new Tuple<string, string>(msg, typ);
            
        }

    }
}
