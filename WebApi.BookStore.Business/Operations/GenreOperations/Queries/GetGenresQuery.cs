﻿using AutoMapper;
using WebApi.BookStore.Data.Context;

namespace WebApi.BookStore.Business.Operations.GenreOperations.Queries;

public class GetGenresQuery
{
    public readonly BookStoreDbContext _context;

    public readonly IMapper _mapper;

    public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
   
    public List<GenresViewModel> Handle()
    {
        var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
        List<GenresViewModel> returnobj = _mapper.Map<List<GenresViewModel>>(genres);
        return returnobj;
    }
}

public class GenresViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}
