using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace WpfApp1.FlashCardApp
{
    [Table("AppSettings")]
    public class AppSettings
    {
        [Column("ID"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("qbDir"), NotNull]
        public bool QbDir { get; set; }
        [Column("abDir"), NotNull]
        public bool AbDir { get; set; }
    }
}
