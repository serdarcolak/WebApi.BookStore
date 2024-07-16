﻿using AutoMapper;
using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Data.Model;

namespace WebApi.BookStore.Business.Operations.AuthorOperations.Commands;

public class CreateAuthorCommand
{
    public CreateAuthorModel Model;
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.Name == Model.Name);

        if (author is not null)
            throw new InvalidOperationException("Yazar zaten mevcut");

        author = _mapper.Map<Author>(Model);
        _dbContext.Authors.Add(author);
        _dbContext.SaveChanges();


    }
}

public class CreateAuthorModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
}