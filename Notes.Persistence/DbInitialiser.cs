using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Persistence
{
    public class DbInitialiser
    {
        // этот метод будет использоваться про старте приложения и проверять, создана ли БД: и если нет, то она будет создана на основе нашего
        //контекста
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
