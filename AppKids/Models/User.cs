using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace AppKids.Models
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int ID { get; set; }
        [Column("username")]
        [NotNull]
        public string Username { get; set; }
        [Column("email")]
        [NotNull]
        public string Email { get; set; }
        [Column("password")]
        [NotNull]
        public string Password { get; set; }

        // --- Relación con Notas, un usuario tiene varias notas ---
        [OneToMany(nameof(Annotation.UserID))]
        public List<Annotation> Annotations { get; set; }

    }
}
