using System;
using SQL_CLI_Manager.models;
using SQL_CLI_Manager.views;

namespace SQL_CLI_Manager
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DB_Produkte.Conneced();
            Console.Clear();
            Anzeige.MainMenu();
            
        }
    }
}