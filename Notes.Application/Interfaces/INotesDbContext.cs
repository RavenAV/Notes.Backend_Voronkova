using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Interfaces
{
    // интерфейс контекста БД, а его реализция в Notes.Persistence
    // интерфейс - часть приложения, а реализация во вне.
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; } // представляет собой коллекцию всех сущностей в контексте или может запрашиваться из БД, заданного типа.
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);//сохраняет изменения контекста в БД
    }
}
