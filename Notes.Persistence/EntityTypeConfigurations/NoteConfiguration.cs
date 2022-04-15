using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfigurations
{
    // реализуем Influent API
    // Этот класс позволяет разделять конигурацию для типа сущностей на отдельный класс, а не в методе modelcreating нашего db-констекста
    // в котором просто будем использовать готовую конфигурацию. Пусть можно и в методе все описать, однако, чтобы уменьшить размер это метода,
    // мы можем извлечь все конфигурации для типа сущности в отдельный класс + концептуальное разделение
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Id); // ID - это наш ключ 
            builder.HasIndex(note => note.Id).IsUnique();// ключ уникален
            builder.Property(note => note.Title).HasMaxLength(250);// ограничение заголовка
        }
    }
}
