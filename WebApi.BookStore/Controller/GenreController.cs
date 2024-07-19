using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Business.Operations.GenreOperations.Commands;
using WebApi.BookStore.Business.Operations.GenreOperations.Queries;
using WebApi.BookStore.Business.Operations.Validators.GenreValidator.Commands;
using WebApi.BookStore.Business.Operations.Validators.GenreValidator.Queries;


namespace WebApi.BookStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreConroller : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreConroller(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }
        
        [HttpGet("id")]
        public async Task<ActionResult> GetGenreById(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = id;

            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            await validator.ValidateAndThrowAsync(query);
            
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenre;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            await validator.ValidateAndThrowAsync(command);
            
            command.Handle();
            return Ok();
            
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = updateGenre;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            await validator.ValidateAndThrowAsync(command);
            command.handle();
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            await validator.ValidateAndThrowAsync(command);
            
            command.Handle();
            return Ok();
        }
        
    }
}    