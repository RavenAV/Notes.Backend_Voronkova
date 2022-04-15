using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public class Note
    {
        public Guid UserId { get; set; } //ID пользователя
        public Guid Id { get; set; } //ID заметки
        public string Title { get; set; } //Название
        public string Details { get; set; } //Детали
        public DateTime CreationDate { get; set; } //Дата создания
        public DateTime? EditDate { get; set; } //Дата редактирования
    }
}
