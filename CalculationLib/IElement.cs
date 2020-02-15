﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationLib
{
	interface IElement
	{
		bool IsValid();
		bool ParseString(string str);
		string ToString();
	}
}
