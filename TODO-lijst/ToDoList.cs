using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_lijst
{
    internal class ToDoList
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

        public virtual string Toevoegen()
        {
            //Alleen de datum moet erop komen en niet de tijd
            string datum1 = datum.ToShortDateString();

            return $"-{lijst} : {datum1}";
        }
    }
}
