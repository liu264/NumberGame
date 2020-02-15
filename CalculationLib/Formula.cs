using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculationLib
{
	public class Formula : IMathValue
	{
		public Formula(string input)
		{
			_operator = new MathOperator("");
			ParseString(input);
		}

		public bool IsValid()
		{
			if (_operator == null)
			{
				return false;
			}

			//operator needing prefix need to make sure has left value
			if (_operator.NeedPrefixValue() && (_leftValue == null || !_leftValue.IsValid()))
			{
				return false;
			}

			return _rightValue != null && _rightValue.IsValid();
		}

		// Parse string into formula, does not check string validation in depth
		public bool ParseString(string str)
		{
			if (String.IsNullOrEmpty(str) || !Regex.IsMatch(str, @"[ 0-9+\-()*/^.]"))
			{
				return false;
			}
			string formulaStr = str.Replace(" ", "");

			//filter outter quotation if whole formula is quoted
			int startIndex = -1;
			int closingIndex = -1;
			GetQuotationIndex(formulaStr, out startIndex, out closingIndex);
			if (startIndex == 0 && closingIndex == formulaStr.Length - 1)
			{
				formulaStr = formulaStr.Substring(startIndex + 1, closingIndex - startIndex - 1);
			}


			//find operator position to split formula
			int optIndex = -1;
			FindLastLowerLevelOperator(new MathOperator(""), formulaStr, out optIndex);
			if (optIndex < 0)
			{
				SetRightValue(formulaStr);
				return IsValid();
			}

			//split formula
			string leftStr = optIndex > 0 ? formulaStr.Substring(0, optIndex) : "";
			string optStr = formulaStr.Substring(optIndex, 1);
			string rightStr = formulaStr.Substring(optIndex + 1, formulaStr.Length - optIndex - 1);
			SetLeftValue(leftStr);
			_operator = new MathOperator(optStr);
			SetRightValue(rightStr);

			return IsValid();
		}

		//set left side formula or digit
		private void SetLeftValue(string str)
		{
			if (IsFormula(str))
				_leftValue = new Formula(str);
			else
				_leftValue = new Digit(str);
		}

		//set right side formula or digit
		private void SetRightValue(string str)
		{
			if (IsFormula(str))
				_rightValue = new Formula(str);
			else
				_rightValue = new Digit(str);
		}


		//find lowest priority operator furthest back in formula
		public static void FindLastLowerLevelOperator(MathOperator curOpt, string str, out int nextOptIndex)
		{
			nextOptIndex = -1;

			MathOperator lowestOpt = curOpt;
			//current quotation count
			int startCounter = 0;
			for (int index = 0; index < str.Length; index++)
			{
				char c = str[index];
				if (c == '(')
				{
					startCounter++;
				}
				else if (c == ')')
				{
					startCounter--;
				}
				//get operator not in quotation
				else if (startCounter == 0)
				{
					MathOperator opt = new MathOperator(c.ToString());
					//if is operator
					if (!opt.IsValid())
					{
						continue;
					}

					//if is operator is first or of lower priority
					int result = MathOperator.Compare(opt, lowestOpt);
					if (result <= 0 || lowestOpt.Value == MathOperator.OperatorType.NONE)
					{
						nextOptIndex = index;
						lowestOpt = opt;
					}

					//in case 2 operators in a row, skip the next 
					if ((index + 1) < str.Length)
					{
						MathOperator nextOpt = new MathOperator(str[index + 1].ToString());
						if (nextOpt.IsValid())
						{
							index++;
						}
					}
				}
			}
		}

		//get outter quotation position
		public static void GetQuotationIndex(string str, out int startIndex, out int closingIndex)
		{
			startIndex = -1;
			closingIndex = -1;

			int startCounter = 0;
			int index = 0;
			foreach (char c in str)
			{
				if (c == '(')
				{
					//first open quote
					if(startIndex == -1)
						startIndex = index;
					startCounter++;
				}
				else if (c == ')')
				{
					startCounter--;
					//closing of the first open quote
					if (startCounter == 0)
					{
						closingIndex = index;
						return;
					}
				}
				index++;
			}
		}

		public string ToString()
		{
			if (!IsValid())
			{
				return "(NOT_VALID)";
			}
			string leftStr = _leftValue == null ? "" : _leftValue.ToString();
			string combinedString = $"{leftStr} {_operator.ToString()} {_rightValue.ToString()}";
			return combinedString;
		}

		//calculate value of this formula
		public double? GetValue()
		{
			if (!IsValid())
			{
				return null;
			}
			double? leftValue = _leftValue == null ? 0 : _leftValue.GetValue();
			double? rightValue = _rightValue == null ? 0 : _rightValue.GetValue();

			double leftDigit = leftValue ?? 0;
			double rightDigit = rightValue ?? 0;

			double value = _operator.Calculate(leftDigit, rightDigit);
			return value;
		}

		//check if string is formula
		public static bool IsFormula(string str)
		{
			if (Regex.IsMatch(str, @"[+\-*/^]"))
			{
				return true;
			}
			return false;
		}

		//check if string is a valid formula
		public static bool IsValidStr(string str)
		{
			if (String.IsNullOrEmpty(str) || !Regex.IsMatch(str, @"[ 0-9+\-()*/^.]"))
			{
				return false;
			}
			string testStr = str.Replace(" ", "");
			string testQuotationStr = testStr;

			//check quotation validation
			while (Regex.Matches(testQuotationStr, @"[()]").Count > 0)
			{
				int startIndex = -1;
				int closingIndex = -1;
				GetQuotationIndex(testQuotationStr, out startIndex, out closingIndex);
				if (startIndex < 0)
				{
					if(closingIndex < 0)
						break;
					else
						return false;
				}
				else if (closingIndex < 0)
				{
					return false;
				}
				//both quotation marks should exist together and one after another
				if (startIndex >= 0 && startIndex < testQuotationStr.Length && closingIndex > startIndex && closingIndex > 0 &&
				    closingIndex < testQuotationStr.Length)
				{
					testQuotationStr = testQuotationStr.Remove(closingIndex, 1);
					testQuotationStr = testQuotationStr.Remove(startIndex, 1);
				}
				else
				{
					return false;
				}
			}

			char[] operatorChars = {'+', '-', '*', '/', '^'};
			while (IsFormula(testStr))
			{
				int optIndex = testStr.IndexOfAny(operatorChars);
				if (optIndex < 0)
				{
					break;
				}
				//operator can't be last letter
				if (optIndex >= testStr.Length - 1)
				{
					return false;
				}

				string optStr = testStr.Substring(optIndex, 1);
				MathOperator opt = new MathOperator(optStr);

				//operator (other than minus) can't be first symbol
				if (optIndex == 0 && opt.NeedPrefixValue())
				{
					return false;
				}

				//operator should follow a number or closing quotation
				if (optIndex > 0)
				{
					string previousStr = testStr.Substring(optIndex - 1, 1);
					//other than minus
					if (!Regex.IsMatch(previousStr, @"[0-9)]") && opt.NeedPrefixValue())
					{
						return false;
					}
				}
				//operator should be followed by a number or open quotation
				string nextStr = testStr.Substring(optIndex + 1, 1);
				MathOperator nextOpt = new MathOperator(nextStr);
				if (!Regex.IsMatch(nextStr, @"[0-9(]") && nextOpt.NeedPrefixValue())
				{
					return false;
				}

				if (opt.Value != MathOperator.OperatorType.NONE && opt.Value == nextOpt.Value)
				{
					return false;
				}
				testStr = testStr.Remove(0, optIndex + 1);
			}

			return true;
		}

		private IMathValue _leftValue;
		private IMathValue _rightValue;
		private MathOperator _operator;
	}
}
