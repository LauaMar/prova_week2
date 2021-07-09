using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_week2
{
    class Task
    {
        public string Descrizione { get; set; }

        public DateTime DataScadenza { get; set; }

        public Priorità livelloPriorità { get; set; }


        public enum Priorità
        {
            Alto,
            Medio,
            Basso
        }

        //costruttore
        public Task()
        {

        }
    }
}
