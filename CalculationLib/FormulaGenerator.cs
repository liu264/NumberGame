using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationLib
{
	public class FormulaGenerator
	{
		#region Singleton
		private static FormulaGenerator _formulaGenerator;
		public static FormulaGenerator Inst()
		{
			if (_formulaGenerator == null)
			{
				_formulaGenerator = new FormulaGenerator();
			}
			return _formulaGenerator;
		}
		#endregion

		private Random _random;

		private FormulaGenerator()
		{
			_random = new Random();
		}

		//Generate random math formula
		public string GenerateFormula()
		{
			string formula = "";
			int numberDigitRemain = _random.Next(2, 7);
			int quoteCounter = 0;

			int previousType = 1; //0: digit; 1: operator; 2: '('; 3: ')'
			while (numberDigitRemain > 0 || quoteCounter > 0)
			{
				int chance = _random.Next(101);
				//if previous is digit or ')'
				if (previousType == 0 || previousType == 3)
				{
					//follow with operator
					if (numberDigitRemain > 0 && (chance < 70 || quoteCounter > 2))
					{
						formula += GenerateRandomOperator();
						previousType = 1;
					}
					//can ')'
					else if (quoteCounter > 0)
					{
						formula += ")";
						quoteCounter--;
						previousType = 3;
					}
				}
				//if previous is operator
				else if (previousType == 1 && numberDigitRemain > 0)
				{
					//follow with digit
					if(chance < 85)
					{
						formula += GenerateRandomDigit();
						numberDigitRemain--;
						previousType = 0;
					}
					//or '('
					else
					{
						formula += "(";
						quoteCounter++;
						previousType = 2;
					}
				}
				//if previous is '('
				else if (previousType == 2 && numberDigitRemain > 0)
				{
					//chance follow with digit
					if (chance < 90 && numberDigitRemain > 0)
					{
						formula += GenerateRandomDigit();
						numberDigitRemain--;
						previousType = 0;
					}
					//or follow with '-'
					else if (chance > 95)
					{
						formula += "-";
						previousType = 1;
					}
					//or follow with '('
					else
					{
						formula += "(";
						quoteCounter++;
						previousType = 2;
					}
				}
			}

			return formula;
		}

		//Generate random digit
		public string GenerateRandomDigit()
		{
			int digit = _random.Next(0, 11);
			return digit.ToString();
		}

		//Generate random math operator
		public string GenerateRandomOperator()
		{
			int numOperator = (int) MathOperator.OperatorType.DIVIDE;
			int opt = _random.Next(1, numOperator + 1);
			return MathOperator.OperatorToStr((MathOperator.OperatorType)opt);
		}
	}
}
