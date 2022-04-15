using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfigurations;


namespace Notes.Persistence
{
    // Это силд-класс, реализующий интерфейс INotesDbContext и наследующийся от DbContext
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; } //действует как репозиторий
        public NotesDbContext(DbContextOptions<NotesDbContext> options) // действует как unitofwork
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
