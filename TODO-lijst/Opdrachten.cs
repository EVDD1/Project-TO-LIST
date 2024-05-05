using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace TODO_lijst
{
	internal class Opdrachten : ToDoList
	{ 

		public override string Toevoegen()
		{
			string Toevoegen1 = base.Toevoegen();

			return Toevoegen1;
		}
	}
}
