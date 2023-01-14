using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RipassoArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dichiarazioni
            int[] array = new int[100];
            int n = 0, el = 0, dim = 0, scelta = 0;
            string html = "";
            //struttura menù
            do
            {
                //stampa delle opzioni
                Console.Clear();
                Console.WriteLine("1 - Aggiungi elemento all'array");
                Console.WriteLine("2 - Stampa degli elementi caricati");
                Console.WriteLine("3 - Visualizza dell'array in file html");
                Console.WriteLine("4 - Ricerca un numero nell'array");
                Console.WriteLine("5 - Cancella un elemento dell'array");
                Console.WriteLine("6 - Inserisci un elemento nell'array");
                Console.WriteLine("7 - Uscita dal programma");
                //scelta'dell'opzione
                Console.WriteLine("\nInserisci la scelta");
                scelta = int.Parse(Console.ReadLine());
                //esecuzione dell'opzione
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("\nInserire il carattere: ");
                        el = int.Parse(Console.ReadLine());
                        if(AggiungiElementoArray(array, el, ref dim))
                        {
                            Console.WriteLine("Elemento inserito correttamente");
                        }
                        else
                        {
                            Console.WriteLine("Array pieno");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nStampa dell'array: ");
                        StampaArray(array, dim);
                        break;
                    case 3:
                        GenerazioneHTML(dim, ref html, array);
                        Console.WriteLine(html);
                        break;
                }
                Console.WriteLine("Premere un tasto per continuare...");
                Console.ReadLine();
            } while (scelta != 7);
        }

        static bool AggiungiElementoArray(int[] array, int elem, ref int i)
        {
            bool ins = true;
            //controllo dimensione massima
            if (i < array.Length)
            {
                //inserisce l'elemento nell'array
                array[i] = elem;
                //incrementare l'indice i
                i++;

            }
            else
            {
                ins = false;
            }
            return ins;
        }

        static void StampaArray(int[] array, int dimensione)
        {
            for (int i = 0; i < dimensione; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static string GenerazioneHTML(int dimensione, ref string html, int[] array)
        {
            string td = "";
            for (int i = 0; i < dimensione; i++)
            {  
                td = td + "<td>" + array[i] + "</td>";
            }
            html = "<html><head><title>Array</title><style>html {font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;}td {border: 2px black solid;padding: 20px;font-size: 30px;}</style></head><body><h1>Stampa dell'array</h1><table><tr>" + td +"</tr></table></body></html>";
            return html;
        }
    }
}
