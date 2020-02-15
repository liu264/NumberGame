using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculationLib
{
	public class Digit : IMathValue
	{
		public Digit(string input)
		{
			ParseString(input);
		}

		public bool IsValid()
		{
			return _digit != null;
		}

		//get digit from string
		public bool ParseString(string str)
		{
			string cleanedStr = Regex.Replace(str, "[() ]", "");
			double temp;
			if (Double.TryParse(cleanedStr, out temp))
			{
				_digit = temp;
				return true;
			}
			return false;
		}
		public string ToString()
		{
			return IsValid() ? _digit.ToString() : "";
		}
		public double? GetValue()
		{
			return _digit;
		}

		private double? _digit;
	}
}
