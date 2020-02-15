using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculationLib;

namespace NumberGame
{
	public partial class Calculator : Form
	{
		public Calculator()
		{
			InitializeComponent();
			CenterToParent();
			StartPosition = FormStartPosition.CenterParent;

			txtFormula.KeyPress += txtFormula_KeyPress;
		}

		#region Calculation
		//Generate random math formula
		private void btnRandomFormula_Click(object sender, EventArgs e)
		{
			txtFormula.Text = FormulaGenerator.Inst().GenerateFormula();
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			try
			{
				string formulaInput = txtFormula.Text;

				bool bIsValid = Formula.IsValidStr(formulaInput);
				if (!bIsValid)
				{
					txtResult.Text = "Format Error";
					return;
				}

				Formula formula = new Formula(formulaInput);
				double? result = formula.GetValue();
				if (result == null)
				{
					txtResult.Text = "Calculation Error";
					return;
				}

				txtResult.Text = result.Value.ToString();
			}
			catch (Exception ex)
			{
				ShowError(ex.Message);
			}
		}

		//limit formula key input
		private void txtFormula_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (Int32)Keys.Enter)
			{
				btnCalculate.PerformClick();
				return;
			}

			string entered = e.KeyChar.ToString();
			if (!char.IsControl(e.KeyChar) && !Regex.IsMatch(entered, @"[ 0-9+\-()*/^.]"))
			{
				e.Handled = true;
			}
		}
		#endregion

		#region UI Popup
		//Error Message
		public void ShowError(string message)
		{
			MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		//Message Display
		public void ShowInfo(string status)
		{
			MessageBox.Show(this, status, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		#endregion

	}
}
