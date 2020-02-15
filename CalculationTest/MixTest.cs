using System;
using CalculationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationTest
{
	[TestClass]
	public class MixTest
	{
		[TestMethod]
		public void MixTest1()
		{
			string input = "1-2*3+4";
			double expected = -1;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest2()
		{
			string input = "1*2*(3*4)+(5-6)";
			double expected = 23;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}


		[TestMethod]
		public void MixTest3()
		{
			string input = "1-2*3+(4+5)*6+7-8/4";
			double expected = 54;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest4()
		{
			string input = "1*2*(3*4)+(5-6)";
			double expected = 23;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest5()
		{
			string input = "1+2+3+(4+5)+6+7+8*9*10*(11*12)+(13-14)";
			double expected = 95067;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest6()
		{
			string input = "1+2+3+(4+5)+6+7+8*9*10*(11*12)+(13-14)";
			double expected = 95067;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest7()
		{
			string input = "2 - 5 - 6 / 3 + 2";
			double expected = -3;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest8()
		{
			string input = "2 * (3-4) - 5 - 6 / 3 +0.5";
			double expected = -8.5;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest9()
		{
			string input = "0.5 * 8 - 5 - 6 / 3 * 5 - 3 + 5";
			double expected = -9;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest10()
		{
			string input = "8 / 2 - 5 - 6 * 3 / 9 - 3 + 5";
			double expected = -1;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest11()
		{
			string input = "1 - 2 - 3 + 4 + 5";
			double expected = 5;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest12()
		{
			string input = "- 2 - (-3) - 4 + 5";
			double expected = 2;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest13()
		{
			string input = "1 + ((2 - 3) * (4 / 2)) * 2";
			double expected = -3;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest14()
		{
			string input = "2 * -2";
			double expected = -4;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest15()
		{
			string input = "(2+3) * 2 ^(2+1)";
			double expected = 40;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}

		[TestMethod]
		public void MixTest16()
		{
			string input = "(2-3*4/6+7+(8))";
			double expected = 15;

			Formula testFormula = new Formula(input);
			double? result = testFormula.GetValue();

			Assert.AreEqual(result.Value, expected, 0.001, $"Expect {expected}");
		}
	}
}
