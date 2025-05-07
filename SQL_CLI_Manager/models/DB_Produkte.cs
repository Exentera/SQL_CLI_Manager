using System;
using MySqlConnector;

namespace SQL_CLI_Manager.models
{
    public class DB_Produkte
    {
        // enthält die daten für serveradresse, databank name, user, password
        public static string connectionString = "Server=127.0.0.1; Database=onlineshop; User=root; Password=;";

        public static MySqlConnection connection;

        public static void Conneced()
        {
            try
            {
                // Versucht diesen Code auszuführen

                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Connection succsess!");
            }
            catch (MySqlException e)
            {
                // Wenn der Try nicht klapp wird dieser Block ausgeführt
                Console.WriteLine(e);
            }
        }

        public static Produkt GetProdukrByID(int produktID)
        {
            string query = $"CALL GetProdukrByID ({produktID});";

            //MySQLCommand Klasse um SQL Befehle an eine Connection zu schicken
            MySqlCommand command = new MySqlCommand(query, connection);


            // Fuhrt den Command aus und speichert das Resultat
            MySqlDataReader reader = command.ExecuteReader();
            Produkt produkt = null;

            Console.Clear();


            while (reader.Read())
            {
                // Auf die aktuellen Spalten in der Zeile zugreifen
                int id = Convert.ToInt32(reader["id"].ToString());
                int artikelnummer = Convert.ToInt32(reader["artikelnummer"].ToString());
                string produktname = reader["produktname"].ToString();
                double preis = Convert.ToDouble(reader["preis"].ToString());
                string beschreibung = reader["beschreibung"].ToString();
                int anzahl = Convert.ToInt32(reader["anzahl"].ToString());
                produkt = new Produkt(id, artikelnummer, produktname, preis, beschreibung, anzahl);
            }

            command.Dispose();
            reader.Dispose();


            return produkt;
        }

        public static void ReadAll()
        {
            string query = "CALL ReadALL;";

            //MySQLCommand Klasse um SQL Befehle an eine Connection zu schicken
            MySqlCommand command = new MySqlCommand(query, connection);


            // Fuhrt den Command aus und speichert das Resultat
            MySqlDataReader reader = command.ExecuteReader();


            Console.Clear();
            while (reader.Read())
            {
                // Auf die aktuellen Spalten in der Zeile zugreifen
                string id = reader["id"].ToString();
                string artikelnummer = reader["artikelnummer"].ToString();
                string produktname = reader["produktname"].ToString();
                string preis = reader["preis"].ToString();
                string beschreibung = reader["beschreibung"].ToString();
                string anzahl = reader["anzahl"].ToString();

                Console.WriteLine($"ID:\t{id}\t|\t" +
                                  $"Artikelnummer:\t{artikelnummer}\t|\t" +
                                  $"Producktname:\t{produktname}\t|\t" +
                                  $"Preis:\t{preis}\t|\t" +
                                  $"Anzahl:\t{anzahl}\t|\t" +
                                  $"Berschreibung:\t{beschreibung}");
            }


            command.Dispose();
            reader.Dispose();
        }

        public static void Insert(Produkt produkt)
        {
            // Prepared Statments
            //string query = "INSERT INTO produkte (artikelnummer,produktname,preis,beschreibung,anzahl)" +
              //             "VALUES(@artikelnummer,@produktname,@preis,@beschreibung,@anzahl)";
            
            string query = "CALL InsertNewProdukt(@artikelnummer,@produktname,@preis,@beschreibung,@anzahl)";

            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@artikelnummer", produkt.Artikelnummen);
            command.Parameters.AddWithValue("@produktname", produkt.Produktname);
            command.Parameters.AddWithValue("@preis", produkt.Preis);
            command.Parameters.AddWithValue("@beschreibung", produkt.Beschreibung);
            command.Parameters.AddWithValue("@anzahl", produkt.Anzahl);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Produkt wurde eingefügt");
            }
            else
            {
                Console.WriteLine("Fehler Produckt konnte nicht eingefühgt werden");
            }

            command.Dispose();
        }

        public static void UpdateProdukt(Produkt produkt)
        {
            // Prepared Statments
            /*string query = "UPDATE produkte SET " +
                           "artikelnummer = @artikelnummer, " +
                           "produktname = @produktname, " +
                           "preis = @preis, " +
                           "beschreibung = @beschreibung, " +
                           "anzahl = @anzahl " +
                           "WHERE id = @id";*/

            string query = "CALL UpdateProdukt(@id,@artikelnummer,@produktname,@preis,@beschreibung,@anzahl)";


            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", produkt.Id);
            command.Parameters.AddWithValue("@artikelnummer", produkt.Artikelnummen);
            command.Parameters.AddWithValue("@produktname", produkt.Produktname);
            command.Parameters.AddWithValue("@preis", produkt.Preis);
            command.Parameters.AddWithValue("@beschreibung", produkt.Beschreibung);
            command.Parameters.AddWithValue("@anzahl", produkt.Anzahl);


            int rowsAffected = command.ExecuteNonQuery();


            if (rowsAffected > 0)
            {
                Console.WriteLine("Produkt wurde Aktualisiert");
            }
            else
            {
                Console.WriteLine("Fehler Produckt konnte nicht Aktualisiert werden");
            }

            command.Dispose();
        }

        public static void Delete(int id)
        {
           // string query = $"DELETE FROM produkte where id = {id};";
            string query = $"CALL DeleteProdukte({id});";

            //MySQLCommand Klasse um SQL Befehle an eine Connection zu schicken
            MySqlCommand command = new MySqlCommand(query, connection);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine($"Produkt mit ID {id} gelöscht");
            }
            else
            {
                Console.WriteLine($"Produkt mit ID {id} nicht vorhanden");
            }

            command.Dispose();
        }
    }
}