using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SQLite;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // database name:
        public static readonly string dbName = "kia";
        // database folder:
        static readonly string dbFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        // database path:
        public static string dbPath = System.IO.Path.Combine(dbFolder, "kia", "1-databases", dbName);
        public static readonly string dbPath_projects = System.IO.Path.Combine(dbFolder, "kia", "1-databases", "kia_projects");
        public static readonly string dbPath_tmpdb = System.IO.Path.Combine(dbFolder, "kia", "1-databases", "tmp_db");
        public static readonly System.Text.RegularExpressions.Regex regex = new(@"\~\[\[\w+[\%\+\=\-\:\/.\,\;\?\#\w]*\]\]");
    }
    
}