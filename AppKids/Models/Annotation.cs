using SQLite;
using SQLiteNetExtensions.Attributes;

// --- Tabla de notas ---
namespace AppKids.Models
{
    [Table("annotations")]
    public class Annotation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("title")]
        [NotNull]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("created_date")]
        [NotNull]
        public DateTime CreatedDate { get; set; }

        // --- Relación con User (Muchas notas a un usuario) ---
        [ForeignKey(typeof(User))]
        public int UserID { get; set; }

        [ManyToOne]
        public User Author { get; set; }
    }
}
