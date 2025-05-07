using System;
using System.Data;
using SQL_CLI_Manager.models;

namespace SQL_CLI_Manager.views
{
    public class Anzeige
    {
        
        // String array as parameter for wählbare Optionen
        // Returns the index of the selected option as an int

        // Example for calling and initialization:
        // string[] options = { "Option_1", "Option_2", "Option_3", /* etc. */ };
        // int selectedOption = ShowMenu(options); oder Anzeige.ShowMenu(options);
        public static int ShoweMenu(string headderText, string[] options)
        {
            int selectedIndex = 0;
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine(headderText);
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($" {options[i]}");
                    }
                }

                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow && selectedIndex > 0)
                    selectedIndex--;
                else if (key == ConsoleKey.DownArrow && selectedIndex < options.Length - 1)
                    selectedIndex++;
            } while (key != ConsoleKey.Enter);

            Console.Clear();
            return selectedIndex;
        }

        public static void MainMenu()
        {
            bool s = false;
            do
            {
                string headderText = "#################\n" +
                                     "### Main Menu ###\n" +
                                     "#################";

                string[] options = { "Read All", "Read by ID", "Insert", "Update", "Delete", "Zurück" };
                int selectedOption = ShoweMenu(headderText, options);

                Console.WriteLine("[DEBUG] SELECTED OPTION: " + selectedOption);


                switch (selectedOption)
                {
                    case 0:
                        DB_Produkte.ReadAll();
                        OkConsoleStop();
                        break;
                    case 1:
                        ProduktByID();
                        OkConsoleStop();
                        break;
                    case 2:
                        PrudukteInsert();
                        break;
                    case 3:
                        DB_Produkte.ReadAll();
                        ProduktUpdate();
                        break;
                    case 4:
                        DB_Produkte.ReadAll();
                        ProduktDelete();
                        OkConsoleStop();
                        break;
                    case 5:
                        Console.WriteLine("Programm wird beendet");
                        s = true;
                        break;
                }
            } while (s == false);
 
            
            Console.WriteLine();
        }

        public static void ProduktByID()
        {
            Console.Write("Produkt ID eingebn: ");
            int produktID = Convert.ToInt32(Console.ReadLine());
            Produkt produkt = DB_Produkte.GetProdukrByID(produktID);

            Console.WriteLine($"ID: {produkt.Id} " +
                              $"Artikelnummer: {produkt.Artikelnummen} " +
                              $"Producktname: {produkt.Produktname}  " +
                              $"Preis: {produkt.Preis} " +
                              $"Berschreibung: {produkt.Beschreibung} " +
                              $"Anzahl: {produkt.Anzahl}");
        }

        public static void PrudukteInsert()
        {
            bool s = false;
            do
            {
                Console.Write("Bitte geben sie die Artikelnummer ein: ");
                int artikelnummer = Convert.ToInt32(Console.ReadLine());

                Console.Write("Bitte geben sie den Produktname ein: ");
                string produktname = Console.ReadLine();

                Console.Write("Bitte geben sie den Preis ein: ");
                double preis = Convert.ToInt32(Console.ReadLine());

                Console.Write("Bitte geben sie eine Beschreibung ein: ");
                string beschreibung = Console.ReadLine();

                Console.Write("Bitte geben sie die Anzahl ein: ");
                int anzahl = Convert.ToInt32(Console.ReadLine());

                Produkt tmpProdukt = new Produkt(artikelnummer, produktname, preis, beschreibung, anzahl);
                DB_Produkte.Insert(tmpProdukt);
                
                string h = "Weiteres Produkt hinzufügen?";
                string[] options = { "Ja", "Nein"};
                int select =ShoweMenu(h, options);
                if (select==1)
                {
                    s = true;
                }
                

            } while (s == false);
        }

        public static void ProduktUpdate()
        {
            Console.Write("Produkt ID zu Updaten eingebn: ");
            int produktID = Convert.ToInt32(Console.ReadLine());
            Produkt produkt = DB_Produkte.GetProdukrByID(produktID);

            Console.WriteLine();

            bool s = false;
            
            do
            {
                
                string headderText =
                    $"\nID: {produkt.Id} \n" +
                    $"Artikelnummer: {produkt.Artikelnummen} \n" +
                    $"Producktname: {produkt.Produktname}  \n" +
                    $"Preis: {produkt.Preis} \n" +
                    $"Berschreibung: {produkt.Beschreibung} \n" +
                    $"Anzahl: {produkt.Anzahl}\n\n" +
                    $"--------------\n" +
                    $"Wert auswählen\n" +
                    $"--------------";


                string[] options = { "Artikelnummer", "Produktname", "Preis", "Berschreibung", "Anzahl", "Zurück" };
                int selectedOption = ShoweMenu(headderText, options);

                switch (selectedOption)
                {
                    case 0:
                        Console.WriteLine($"Artikelnummer: {produkt.Artikelnummen}");
                        Console.Write($"Neue Artikelnummer: ");
                        produkt.Artikelnummen = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Artikelnummer: {produkt.Artikelnummen}");
                        DB_Produkte.UpdateProdukt(produkt);
                        break;
                    case 1:
                        Console.WriteLine($"Producktname: {produkt.Produktname}");
                        Console.Write($"Neue Producktname: ");
                        produkt.Produktname = Console.ReadLine();
                        Console.WriteLine($"Producktname: {produkt.Produktname}");
                        DB_Produkte.UpdateProdukt(produkt);
                        break;
                    case 2:
                        Console.WriteLine($"Preis: {produkt.Preis}");
                        Console.Write($"Neue Preis: ");
                        produkt.Preis = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Preis: {produkt.Preis}");
                        DB_Produkte.UpdateProdukt(produkt);
                        break;
                    case 3:
                        Console.WriteLine($"Beschreibung: {produkt.Beschreibung}");
                        Console.Write($"Neue Berschreibung: ");
                        produkt.Beschreibung = Console.ReadLine();
                        Console.WriteLine($"Beschreibung: {produkt.Beschreibung}");
                        DB_Produkte.UpdateProdukt(produkt);
                        break;
                    case 4:
                        Console.WriteLine($"Anzahl: {produkt.Anzahl}");
                        Console.Write($"Neue Anzahl: ");
                        produkt.Anzahl = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Anzahl: {produkt.Anzahl}");
                        DB_Produkte.UpdateProdukt(produkt);
                        break;
                    case 5:
                        s = true;
                        break;
                }

                
            }while (s == false) ;
        }


        public static void ProduktDelete()
        {
            Console.Write("Produkt ID zum LÖSCHEM eingebne: ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            DB_Produkte.Delete(selectedOption);
        }

        public static void OkConsoleStop()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"> OK");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}