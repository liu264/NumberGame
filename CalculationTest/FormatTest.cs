using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculationLib;

namespace CalculationTest
{
	[TestClass]
	public class FormatTest
	{
		[TestMethod]
		public void FormatTest1()
		{
			string input = "asfas";
			bool expected = false;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest2()
		{
			string input = " (1+2-3 *1/2)";
			bool expected = true;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest3()
		{
			string input = "(1+2-3*1/2";
			bool expected = false;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest4()
		{
			string input = "+2-3*1/2";
			bool expected = true;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest5()
		{
			string input = "1+2-3*1/";
			bool expected = false;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest6()
		{
			string input = "-(1)";
			bool expected = true;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest7()
		{
			string input = "(1.5)-";
			bool expected = false;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest8()
		{
			string input = "(1.5)-5";
			bool expected = true;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest9()
		{
			string input = "+(1)/";
			bool expected = false;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest10()
		{
			string input = "/(1.5)";
			bool expected = false;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest11()
		{
			string input = "1 * (1.5) / 5";
			bool expected = true;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest12()
		{
			string input = "2 * *2";
			bool expected = false;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest13()
		{
			string input = "2 * -2";
			bool expected = true;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest14()
		{
			string input = "2 - -2";
			bool expected = false;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}

		[TestMethod]
		public void FormatTest15()
		{
			string input = "(1 + 5)-6";
			bool expected = true;

			bool result = Formula.IsValidStr(input);
			Assert.AreEqual(result, expected, $"Expect {expected}");
		}
	}
}
