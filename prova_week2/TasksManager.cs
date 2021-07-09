using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static prova_week2.Task;

namespace prova_week2
{
    class TasksManager
    {
       static List<Task> tasks = new List<Task>();
        static string path = @"C:\Users\Laura Martines\Desktop\progetti\Prove\prova_week2\listaTasks.txt";

        
        public static void VisualizzaTask()
        {
           if (tasks.Count==0)
            {
                Console.WriteLine("Non sono presenti task da gestire!");
                Console.WriteLine();
            }
            else
            {
                //StampaTasks(); // questo non tabula bene, ma le proprietà sono in ordine
                StampaTasksTab(); // questo tabula bene, ma le proprietà sono in disordine
            }
        }

        // questo non tabula bene, ma le proprietà sono in ordine
        public static void StampaTasks()
        {
            StampaTasks(tasks);
        }

        public static void StampaTasks(List<Task> tasksDaStampare)
        {
            int counter = 1;
            Console.WriteLine("     Descrizione \t\t Data Scadenza \t\t livello priorità");
            foreach (Task task in tasksDaStampare)
            {
                Console.WriteLine($"{counter} --> {task.Descrizione} \t\t {task.DataScadenza.ToString("dd/MM/yyyy")} \t\t {task.livelloPriorità}");
                counter++;
            }
        }

        // questo tabula bene, ma le proprietà sono in disordine
        public static void StampaTasksTab()
        {
            StampaTasksTab(tasks);
        }

        public static void StampaTasksTab(List<Task> tasksDaStampare)
        {

                int counter = 1;
                Console.WriteLine("      Data Scadenza \t\t livello priorità\t\t Descrizione ");
                foreach (Task task in tasksDaStampare)
                {
                    Console.WriteLine($"{counter} --> {task.DataScadenza.ToString("dd/MM/yyyy")} \t\t {task.livelloPriorità}\t\t\t\t {task.Descrizione}");
                    counter++;
                }          
        }


        // questo non tabula bene, ma le proprietà sono in ordine
        internal static void SalvaTasksSuFile()
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Descrizione \t\t Data Scadenza \t\t livello priorità");
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Task task in tasks)
                {
                    sw.WriteLine($"{task.Descrizione} \t\t {task.DataScadenza} \t\t {task.livelloPriorità}");
                }
            }
        }

        // questo tabula bene, ma le proprietà sono in disordine
        internal static void SalvaTasksSuFileTab()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Data Scadenza \t\t\t livello priorità \t Descrizione");
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Task task in tasks)
                {
                    sw.WriteLine($"{task.DataScadenza} \t\t {task.livelloPriorità} \t\t\t {task.Descrizione}");
                }
            }
        }

        internal static void EliminaTask()
        {
            int idTaskDaEliminare = 0;
            Console.WriteLine("Hai scelto di eliminare un task");
            Console.WriteLine();
            //StampaTasks();
            StampaTasksTab();
            Console.WriteLine();
            Console.WriteLine("Scegliere l'indice del task da eliminare:");
            while(!(int.TryParse(Console.ReadLine(), out idTaskDaEliminare) && idTaskDaEliminare>0 && idTaskDaEliminare<=tasks.Count))
            {
                Console.WriteLine("L'indice inserito non è corretto, inserirne un altro");
            }
            tasks.RemoveAt(idTaskDaEliminare-1);

        }

        public static void AggiungiTask()
        {
            Task newTask = new Task();
            Console.WriteLine("Hai scelto di aggiungere un task");

            Console.WriteLine("Inserisci la descrizione del task:");
            newTask.Descrizione = Console.ReadLine();

            newTask.DataScadenza = InserisciDataScadenza();

            Console.WriteLine("Scegli il livello di priorità del task");
            newTask.livelloPriorità = ScegliLivelloPriorità();

            tasks.Add(newTask);
        }

        public static DateTime InserisciDataScadenza()
        {
            DateTime newDataScadenza = new DateTime();
            Console.WriteLine("Inserisci la data di scadenza del task:");
            Console.WriteLine("!!! La data di scadenza deve essere posteriore alla data di inserimento del task");
            while (!(DateTime.TryParse(Console.ReadLine(), out newDataScadenza) && newDataScadenza > DateTime.Now.Date))
            {
                Console.WriteLine("La data di scadenza inserita non è valida, inserirne un'altra");
            }
            return newDataScadenza;
        }

        public static Priorità ScegliLivelloPriorità()
        {
            int sceltaPriorità = -1;
            Console.WriteLine($"Premi {(int)Priorità.Alto} per selezionare {Priorità.Alto}");
            Console.WriteLine($"Premi {(int)Priorità.Medio} per selezionare {Priorità.Medio}");
            Console.WriteLine($"Premi {(int)Priorità.Basso} per selezionare {Priorità.Basso}");
            while (!(int.TryParse(Console.ReadLine(), out sceltaPriorità) && sceltaPriorità >= (int)Priorità.Alto && sceltaPriorità <= (int)Priorità.Basso))
            {
                Console.WriteLine("Il valore scelto non è valido, inserirne un altro:");
            }
            return (Priorità)sceltaPriorità;
        }

        public static void FiltraTasks()
        {
            List<Task> tasksDaFiltrare = new List<Task>();
            Console.WriteLine("Scegli il livello di priorità dei task da mostrare");
            Priorità livPrioritàDaFiltrare = ScegliLivelloPriorità();
            foreach(Task task in tasks)
            {
                if(task.livelloPriorità == livPrioritàDaFiltrare)
                {
                    tasksDaFiltrare.Add(task);
                }
            }
            if(tasksDaFiltrare.Count>0)
            {
                //StampaTasks(tasksDaFiltrare);
                StampaTasksTab(tasksDaFiltrare);
            }
            else 
            {
                Console.WriteLine($"Non sono presenti task con livello di priorità {livPrioritàDaFiltrare}");
            }
        }

       


    }
}
