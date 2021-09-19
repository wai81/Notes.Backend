using System;
using MediatR;

namespace Notes.Aplication.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid> //создание Заметки, возвращает результат определенного типа Guid
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }
    }
}
