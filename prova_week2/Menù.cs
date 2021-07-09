using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_week2
{
    class Menù
    {
        public static void Start()
        {
            Console.WriteLine("Benvenuto in Tasks!");
            int scelta = -1;
            while (scelta != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Inserisci il codice relativo all'azione da compiere");
                Console.WriteLine("Premi 1 per visualizzare i tasks");
                Console.WriteLine("Premi 2 per aggiungere nuovi tasks");
                Console.WriteLine("Premi 3 per eliminare un task");
                Console.WriteLine("Premi 4 per filtrare i task per importanza");
                Console.WriteLine("Premi 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Il codice inserito non è valido, inserire un intero:");
                }

                switch (scelta)
                {
                    case 0:
                        //TasksManager.SalvaTasksSuFile();
                        TasksManager.SalvaTasksSuFileTab();
                        break;
                    case 1:
                        TasksManager.VisualizzaTask();
                        break;
                    case 2:
                        TasksManager.AggiungiTask();
                        break;
                    case 3:
                        TasksManager.EliminaTask();
                        break;
                    case 4:
                        TasksManager.FiltraTasks();
                        break;
                    default:
                        Console.WriteLine("Il codice inserito non è collegato a nessuna opzione!");
                        break;

                }


            }
        }
    }
}
