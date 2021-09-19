﻿using FluentValidation;
using System;

namespace Notes.Aplication.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(deleteNoteCommand =>
                deleteNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteNoteCommand =>
                deleteNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
