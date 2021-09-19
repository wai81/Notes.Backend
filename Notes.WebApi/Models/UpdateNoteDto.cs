using AutoMapper;
using Notes.Aplication.Common.Mappings;
using Notes.Aplication.Notes.Commands.UpdateNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.WebApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteDto>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(note => note.Id, opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(note => note.Title, opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(note => note.Details, opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
