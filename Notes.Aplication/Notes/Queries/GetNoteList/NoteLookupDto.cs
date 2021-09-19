using AutoMapper;
using Notes.Aplication.Common.Mappings;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Aplication.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteDto => noteDto.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title, opt => opt.MapFrom(note => note.Title));
        }
    }
}
