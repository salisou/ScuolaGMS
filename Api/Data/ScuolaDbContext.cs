using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Data
{
    public class ScuolaDbContext : DbContext
    {
        public ScuolaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Aula> Aule { get; set; }
        public DbSet<Classe> Classi { get; set; }
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Iscrizione> Iscrizioni { get; set; }
        public DbSet<Lezione> Lezioni { get; set; }
        public DbSet<Presenza> Presenze { get; set; }
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Valutazione> Valutazioni { get; set; }
        public DbSet<Voto> Voti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unicità iscrizione
            modelBuilder.Entity<Iscrizione>()
                .HasIndex(i => new { i.StudenteId, i.CorsoId, i.AnnoAccademico })
                .IsUnique();

            // Relazioni Iscrizione
            modelBuilder.Entity<Iscrizione>()
                .HasOne(i => i.Studente)
                .WithMany(s => s.Iscrizione)
                .HasForeignKey(i => i.StudenteId);

            modelBuilder.Entity<Iscrizione>()
                .HasOne(i => i.Corso)
                .WithMany(c => c.Iscrizioni)
                .HasForeignKey(i => i.CorsoId);

            modelBuilder.Entity<Iscrizione>()
                .HasOne(i => i.Classe)
                .WithMany(cl => cl.Iscrizioni)
                .HasForeignKey(i => i.ClasseId); // <-Fix qui

            // Relazioni Lezione
            modelBuilder.Entity<Lezione>()
                .HasOne(l => l.Corso)
                .WithMany(c => c.Lezioni)
                .HasForeignKey(l => l.CorsoId);

            modelBuilder.Entity<Lezione>()
                .HasOne(l => l.Docente)
                .WithMany(d => d.Lezioni)
                .HasForeignKey(l => l.DocenteId);

            modelBuilder.Entity<Lezione>()
                .HasOne(l => l.Aula)
                .WithMany(a => a.Lezioni)
                .HasForeignKey(l => l.AulaId);

            // Relazioni Presenza
            modelBuilder.Entity<Presenza>()
                .HasOne(p => p.Studente)
                .WithMany(s => s.Presenze)
                .HasForeignKey(p => p.StudenteId);

            modelBuilder.Entity<Presenza>()
                .HasOne(p => p.Lezione)
                .WithMany(l => l.Presenze)
                .HasForeignKey(p => p.LezioneId);

            // Relazioni Valutazione
            modelBuilder.Entity<Valutazione>()
                .HasOne(v => v.Corso)
                .WithMany(c => c.Valutazioni)
                .HasForeignKey(v => v.CorsoId);

            modelBuilder.Entity<Valutazione>()
                .HasOne(v => v.Docente)
                .WithMany(d => d.Valutazioni)
                .HasForeignKey(v => v.DocenteId);

            // Relazioni Voto
            modelBuilder.Entity<Voto>()
                .HasOne(v => v.Studente)
                .WithMany(s => s.Voti)
                .HasForeignKey(v => v.StudenteId);

            modelBuilder.Entity<Voto>()
                .HasOne(v => v.Valutazione)
                .WithMany(val => val.Voti)
                .HasForeignKey(v => v.ValutazioneId);
        }
    }
}
