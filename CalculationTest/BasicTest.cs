using System;
using CalculationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationTest
{
	[TestClass]
	public class BasicTest
	{
		[TestMethod]
		public void BasicTest1()
		{
			string input = "1";
			double expected = 1;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void BasicTest2()
		{
			string input = "-1.1";
			double expected = -1.1;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void BasicTest3()
		{
			string input = " (-2)";
			double expected = -2;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void BasicTest4()
		{
			string input = "1+1";
			double expected = 2;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void BasicTest5()
		{
			string input = "(2-4-5.5)";
			double expected = -7.5;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void BasicTest6()
		{
			string input = "-(1-2)";
			double expected = 1;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void BasicTest7()
		{
			string input = "8/(4-2)";
			double expected = 4;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void BasicTest8()
		{
			string input = "8 * 2 ^ 2";
			double expected = 32;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}
	}
}
