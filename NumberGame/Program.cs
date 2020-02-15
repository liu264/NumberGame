using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculationLib;

namespace NumberGame
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Debug
			string input = "(2-3*4/5+6+(7))";

			bool result1 = Formula.IsValidStr(input);

			if (result1)
			{
				Formula testFormula = new Formula(input);
				double? result = testFormula.GetValue();

				Console.WriteLine($"{testFormula.ToString()} = {result.Value}");

			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Calculator());
		}
	}
}
