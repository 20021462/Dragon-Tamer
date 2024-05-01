using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AbbreviationUtility
{
    private static readonly SortedDictionary<int, string> abbrevations = new SortedDictionary<int, string>
    {
        {1000,"K"},
        {1000000, "M" },
        {1000000000, "B" },
    };

    public static string AbbreviateNumber(int number)
    {
        for (int i = abbrevations.Count - 1; i >= 0; i--)
        {
            KeyValuePair<int, string> pair = abbrevations.ElementAt(i);
            if (Mathf.Abs(number) >= pair.Key)
            {
                float roundedNumber = (float)number / pair.Key;
                //return roundedNumber.ToString("n2") + pair.Value;
                return Math.Round(roundedNumber, 2, MidpointRounding.AwayFromZero) + pair.Value;
            }
        }
        return number.ToString();
    }
}