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
            //struttura menù
            do
            {
                //stampa delle opzioni
                Console.Clear();
                Console.WriteLine("1 - Aggiungi elemento all'array");
                Console.WriteLine("2 - Stampa degli elementi caricati");
                Console.WriteLine("3 - Uscita dal programma");
                //scelta'dell'opzione
                Console.WriteLine("Inserisci la scelta");
                scelta = int.Parse(Console.ReadLine());
                //esecuzione dell'opzione
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserire il carattere: ");
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
                        StampaArray(array, dim);
                        break;
                }
                Console.WriteLine("Premere un tasto per continuare...");
                Console.ReadLine();
            } while (scelta != 3);
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
    }
}
