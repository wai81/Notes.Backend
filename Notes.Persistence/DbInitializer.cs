namespace Notes.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated(); // создает базу данных если она несоздана при запуске
        }
    }
}
