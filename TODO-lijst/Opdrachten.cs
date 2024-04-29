﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace TODO_lijst
{
    internal class Opdrachten
    {
		private DateTime datum;

		public DateTime Datum
		{
			get { return datum; }
			set { datum = value; }
		}

		private string lijst;

		public string Lijst
		{
			get { return lijst; }
			set { lijst = value.ToUpper(); }
		}

		public string Toevoegen()
		{
			return $"-{lijst} : {datum}";
		}
	}
}
