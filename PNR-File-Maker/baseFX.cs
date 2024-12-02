using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace PNR_File_Maker
{
    public class baseFX
    {
        private readonly Random _random = new Random();
        //private readonly Random _gen = new Random();

        public int randomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public int randomNumber(int range)
        {
            return _random.Next(range);
        }



    }
}
