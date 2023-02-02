using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
                Console.WriteLine("1 - Aggiungi elemento all'array in coda");
                Console.WriteLine("2 - Stampa degli elementi caricati");
                Console.WriteLine("3 - Visualizzazione dell'array in file html");
                Console.WriteLine("4 - Ricerca un numero nell'array");
                Console.WriteLine("5 - Cancella un elemento dell'array");
                Console.WriteLine("6 - Inserisci un elemento nell'array");
                Console.WriteLine("7 - Caricamento di un array di n numeri random compresi tra X e Y");
                Console.WriteLine("8 - Troncamento di un array data una dimensione Z");
                Console.WriteLine("9 - Aggiunta ordinata di numeri in un array");
                Console.WriteLine("0 - Uscita dal programma");
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
                    case 4:
                        Console.WriteLine("\nInserire il carattere da ricercare: ");
                        el = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nPosizione: " + RicercaArray(dim, array, el));
                        break;
                    case 5:
                        Console.WriteLine("\nInserire la posizione del carattere da cancellare: ");
                        int pos = int.Parse(Console.ReadLine());
                        if (pos < dim)
                        {
                            CancellaArray(array, pos, ref dim);
                            Console.WriteLine("Cancellazione effettuata correttamente");
                        }
                        else
                        {
                            Console.WriteLine("Posizione non utilizzata");
                        }
                        break;
                    case 6:
                        Console.WriteLine("\nInserire la posizione in cui si vuole inserire il carattere: ");
                        pos = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nInserire il carattere: ");
                        el = int.Parse(Console.ReadLine());
                        if (pos < dim)
                        {
                            InserisciArray(array, pos, ref dim, el);
                            Console.WriteLine("Carattere inserito correttamente");
                        }
                        else
                        {
                            Console.WriteLine("Posizione non utilizzata");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Inserire n: ");
                        int num = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire X: ");
                        int X = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire Y: ");
                        int Y = int.Parse(Console.ReadLine());
                        array = ArrayRandom(array, num, X, Y, ref dim);
                        Console.WriteLine("Array generato correttamente");
                        break;
                    case 8:
                        Console.WriteLine("Inserire Z: ");
                        int Z = int.Parse(Console.ReadLine());
                        TroncaArray(ref dim, Z);
                        Console.WriteLine("Array troncato correttamente");
                        break;
                    case 9:
                        Console.WriteLine("Inserire il numero: ");
                        el = int.Parse(Console.ReadLine());
                        PosizionamentoCorretto(array, ref dim, el);
                        Console.WriteLine("Elemento inserito correttamente");
                        break;
                }
                Console.WriteLine("Premere un tasto per continuare...");
                Console.ReadLine();
            } while (scelta != 0);
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
            //se l'array è pieno
            else
            {
                ins = false;
            }
            return ins;
        }

        static void StampaArray(int[] array, int dimensione)
        {
            //ciclo di stampa dell'array
            for (int i = 0; i < dimensione; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static string GenerazioneHTML(int dimensione, ref string html, int[] array)
        {
            //ciclo di generazione del codice html in una stringa
            string td = "";
            for (int i = 0; i < dimensione; i++)
            {  
                td = td + "<td>" + array[i] + "</td>";
            }
            html = "<html><head><title>Array</title><style>html {font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;}td {border: 2px black solid;padding: 20px;font-size: 30px;}</style></head><body><h1>Stampa dell'array</h1><table><tr>" + td +"</tr></table></body></html>";
            return html;
        }

        static int RicercaArray(int dimensione, int[] array, int el)
        {
            int i = 0;
            //ciclo di ricerca dell'elemento
            for (i = 0; i < dimensione; i++)
            {
                if (array[i] == el)
                {
                    break;
                }
            }
            //se l'elemento è presente
            if (array[i] == el)
            {
                return i;
            }
            //se l'elemento non è presente
            else
            {
                return -1;
            }
        }

        static void CancellaArray(int[] array, int posizione, ref int dimensione)
        {
            //ciclo di spostamento degli elementi nelle celle di una posizione indietro
            for (int i = posizione; i < dimensione; i++)
            {
                array[i] = array[i + 1];
            }
            dimensione--;
        }

        static void InserisciArray(int[] array, int posizione, ref int dimensione, int el)
        {
            //ciclo di spostamento degli elementi nelle celle di una posizione avanti
            int f = dimensione;
            for (int i = posizione; i < dimensione; i++)
            {
                array[f] = array[f - 1];
                f--;
            }
            //inserimento dell'elemento desiderato nella posizione indicata
            array[posizione] = el;
            dimensione++;
        }

        static int[] ArrayRandom(int[] array, int numero, int x, int y, ref int dim)
        {
            //assegno a dim il valore di numero
            dim = numero;
            //dichiarazioni
            Random random = new Random();
            //ciclo di caricamento dell'array con numeri casuali compresi tra X e Y
            for (int i = 0; i < dim; i++)
            {
                array[i] = random.Next(x, y + 1);
            }
            return array;
        }

        static void TroncaArray(ref int dim, int Z)
        {
            //riduco l'array alla dimensione Z
            dim = dim - Z;   
        }

        static void PosizionamentoCorretto(int[] array, ref int dimensione, int el)
        {
            //dichiarzioni
            int x, y, temp;
            //aggiunge l'elemento
            if (AggiungiElementoArray(array, el, ref dimensione))
            {
                Console.WriteLine("Elemento inserito correttamente");
            }
            else
            {
                Console.WriteLine("Array pieno");
            }
            //ciclo per tutti i numeri
            for (x = 0; x < dimensione - 1; x++)
            {
                //per confrontare tutte le coppie
                for (y = 0; y < dimensione - 1 - x; y++)
                {
                    //se la coppia è da scambiare
                    if (array[y] > array[y + 1])
                    {
                        temp = array[y];
                        //avviene lo scambio
                        array[y] = array[y + 1];
                        array[y + 1] = temp;
                    }
                }
            }
        }
    }
}
