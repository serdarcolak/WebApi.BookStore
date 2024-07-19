using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookStore.Business.Operations.AuthorOperations.Commands;
using WebApi.BookStore.Business.Operations.AuthorOperations.Queries;
using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Business.Operations.BookOperations.Queries;

namespace WebApi.BookStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorContoller : ControllerBase
    {

        private readonly IBookStoreDbContext _context;

        private readonly IMapper _mapper;
        
        public AuthorContoller(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetByIdAuthor(int id)
        {
            GetAuthorsDetailQuery query = new GetAuthorsDetailQuery(_context, _mapper);
            query.AuthorId = id;
            
            var obj = query.Handle();
            return Ok(obj);
            

        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel addAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);

            command.Model = addAuthor;
            command.Handle();
            return Ok();



        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
            

                UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
                command.AuthorId = id;
                command.Model = updatedAuthor;

                command.Handle();
                return Ok();

        }
        
        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult AuthorDelete(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            
            command.Handle();
            return Ok();
        
        }
    }
}
