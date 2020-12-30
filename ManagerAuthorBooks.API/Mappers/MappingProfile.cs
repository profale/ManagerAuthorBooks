using AutoMapper;
using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using ManagerAuthorBooks.Domain.Commands.BooksCommands;
using ManagerAuthorBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<CreateBooksCommand, Books>();

            CreateMap<UpdateAuthorCommand, Author>();
            CreateMap<UpdateBooksCommand, Books>();
        }
    }
}
