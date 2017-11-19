﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Validators
{
    public class Validator : IValidator
    {
        public string NIP { get; set; }

        public static bool IsValid(string nip)
        {
            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            bool result = false;
            if (nip.Length == 10)
            {
                int controlSum = CalculateControlSum(nip, weights);
                int controlNum = controlSum % 11;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(nip[nip.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;

        }

        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }
    }
}
