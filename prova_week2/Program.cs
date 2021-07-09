using System;

namespace prova_week2
{
    class Program
    {
        /* Creare una Console Application che permetta di gestire i tasks di un utente.
            I tasks sono oggetti che possiedono:
            - una descrizione
            - una data di scadenza
            - un livello di priorità (Alto, Medio, Basso)
               L’utente può:
            - Visualizzare i tasks;
            - Aggiungere nuovi tasks;
            - Eliminare i tasks;
            - Filtrare i task per importanza;
            Un nuovo task può essere aggiunto solo se la sua data di scadenza è posteriore alla data di
            inserimento del task.
            Al termine delle operazioni, i task dovranno essere salvati su file.
            Requisiti:
            - Usare adeguatamente il concetto di classe
            - Mettere una nomenclatura conforme
            - Eseguire i controlli sull’input utente
            - Scrivere codice pulito
        */
        static void Main(string[] args)
        {
            Menù.Start();
        }
    }
}
