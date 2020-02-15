namespace NumberGame
{
	partial class Calculator
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtFormula = new System.Windows.Forms.TextBox();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.labelFormula = new System.Windows.Forms.Label();
			this.labelResult = new System.Windows.Forms.Label();
			this.btnRandomFormula = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtFormula
			// 
			this.txtFormula.Location = new System.Drawing.Point(67, 65);
			this.txtFormula.Name = "txtFormula";
			this.txtFormula.Size = new System.Drawing.Size(192, 21);
			this.txtFormula.TabIndex = 0;
			// 
			// txtResult
			// 
			this.txtResult.Location = new System.Drawing.Point(86, 127);
			this.txtResult.Name = "txtResult";
			this.txtResult.ReadOnly = true;
			this.txtResult.Size = new System.Drawing.Size(105, 21);
			this.txtResult.TabIndex = 1;
			// 
			// btnCalculate
			// 
			this.btnCalculate.Location = new System.Drawing.Point(100, 175);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(75, 23);
			this.btnCalculate.TabIndex = 2;
			this.btnCalculate.Text = "Calculate";
			this.btnCalculate.UseVisualStyleBackColor = true;
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
			// 
			// labelFormula
			// 
			this.labelFormula.AutoSize = true;
			this.labelFormula.Location = new System.Drawing.Point(86, 33);
			this.labelFormula.Name = "labelFormula";
			this.labelFormula.Size = new System.Drawing.Size(119, 12);
			this.labelFormula.TabIndex = 3;
			this.labelFormula.Text = "Enter Math Formula:";
			// 
			// labelResult
			// 
			this.labelResult.AutoSize = true;
			this.labelResult.Location = new System.Drawing.Point(117, 112);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(47, 12);
			this.labelResult.TabIndex = 4;
			this.labelResult.Text = "Result:";
			// 
			// btnRandomFormula
			// 
			this.btnRandomFormula.Location = new System.Drawing.Point(3, 64);
			this.btnRandomFormula.Name = "btnRandomFormula";
			this.btnRandomFormula.Size = new System.Drawing.Size(58, 23);
			this.btnRandomFormula.TabIndex = 5;
			this.btnRandomFormula.Text = "Random";
			this.btnRandomFormula.UseVisualStyleBackColor = true;
			this.btnRandomFormula.Click += new System.EventHandler(this.btnRandomFormula_Click);
			// 
			// Calculator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.btnRandomFormula);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.labelFormula);
			this.Controls.Add(this.btnCalculate);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.txtFormula);
			this.Name = "Calculator";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtFormula;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.Label labelFormula;
		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.Button btnRandomFormula;
	}
}

