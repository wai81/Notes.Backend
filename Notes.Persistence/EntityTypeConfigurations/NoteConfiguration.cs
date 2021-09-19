using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>

    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Id); //Указываем что Id является ключем
            builder.HasIndex(note => note.Id).IsUnique(); //Указываем что Id уникален
            builder.Property(note => note.Title).HasMaxLength(250); //Указывем размер 250 символов поля Title

        }
    }
}
