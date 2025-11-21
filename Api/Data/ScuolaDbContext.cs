using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Data
{
    public class ScuolaDbContext : DbContext
    {
        public ScuolaDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Aula> Aule { get; set; }
        DbSet<Classe> Classi { get; set; }
        DbSet<Corso> Corsi { get; set; }
        DbSet<Docente> Docenti { get; set; }
        DbSet<Iscrizione> Iscrizioni { get; set; }
        DbSet<Lezione> Lezioni { get; set; }
        DbSet<Presenza> Presenze { get; set; }
        DbSet<Studente> Studenti { get; set; }
        DbSet<Valutazione> Valutazioni { get; set; }
        DbSet<Voto> Voti { get; set; }
    }
}
