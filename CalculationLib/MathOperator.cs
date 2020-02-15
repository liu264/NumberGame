using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationLib
{
	public class MathOperator : IElement
	{
		public enum OperatorType
		{
			NONE,
			PLUS,
			MINUS,
			TIMES,
			DIVIDE,
			POWER
		};

		public MathOperator(string input)
		{
			ParseString(input);
		}

		public bool IsValid()
		{
			return Value != OperatorType.NONE;
		}

		//does operator need prefix value for calculation
		public bool NeedPrefixValue()
		{
			return Value != OperatorType.NONE && Value != OperatorType.MINUS;
		}

		//check operator priority. > 0：priority; = 0: equal; < 0: of less priority 
		public static int Compare(MathOperator opt, MathOperator compareTo)
		{
			
			return opt.Value - compareTo.Value;
		}

		//use operator to calcualate with left and right value
		public double Calculate(double left, double right)
		{
			switch (_operator)
			{
			case OperatorType.PLUS:
				return left + right;
			case OperatorType.MINUS:
				return left - right;
			case OperatorType.TIMES:
				return left * right;
			case OperatorType.DIVIDE:
				return left / right;
			case OperatorType.POWER:
				return Math.Pow(left, right);
			}
			return left + right;
		}

		public bool ParseString(string str)
		{
			_operator = StrToOperator(str);
			return _operator != OperatorType.NONE;
		}

		public string ToString()
		{
			return OperatorToStr(Value);
		}

		static public OperatorType StrToOperator(string str)
		{
			if (str == "+")
			{
				return OperatorType.PLUS;
			}
			if (str == "-")
			{
				return OperatorType.MINUS;
			}
			if (str == "*")
			{
				return OperatorType.TIMES;
			}
			if (str == "/")
			{
				return OperatorType.DIVIDE;
			}
			if (str == "^")
			{
				return OperatorType.POWER;
			}
			return OperatorType.NONE;
		}

		static public string OperatorToStr(OperatorType opt)
		{
			if (opt == OperatorType.PLUS)
			{
				return "+";
			}
			if (opt == OperatorType.MINUS)
			{
				return "-";
			}
			if (opt == OperatorType.TIMES)
			{
				return "*";
			}
			if (opt == OperatorType.DIVIDE)
			{
				return "/";
			}
			if (opt == OperatorType.POWER)
			{
				return "^";
			}
			return "";
		}

		private OperatorType _operator;
		public OperatorType Value { get { return _operator; } }
	}
}
