using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Business.Operations.BookOperations.Commands;
using WebApi.BookStore.Business.Operations.BookOperations.Queries;
using WebApi.BookStore.Business.Validators.BookValidator.Commands;
using WebApi.BookStore.Business.Validators.BookValidator.Queries;

namespace WebApi.BookStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;
        
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBooksDetailQuery.BooksViewDetailModel result;
            try
            {
                GetBooksDetailQuery command = new GetBooksDetailQuery(_context, _mapper);
                
                command.BookId = id;
                
                var validator = new GetBooksDetailQueryValidator();
                var validationResult = validator.Validate(command);
                
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    return BadRequest(ModelState);
                }
                
                result = command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);

        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookCommand.CreateBookModel addBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = addBook;
            
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookCommand.UpdateBookModel updatedBook)
        {
            
            
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.BookModel = updatedBook;

                var validator = new UpdateBookCommandValidator();
                var validationResult = validator.Validate(updatedBook);
                
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    return BadRequest(ModelState);
                }
                
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }
        
        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult BookDelete(int id)
        {
            DeleteBookCommand.BookViewDeleteModel result;
            
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context, _mapper);
                command.BookId = id;
                
                var validator = new DeleteBookCommandValidator();
                var validationResult = validator.Validate(command);
                
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    return BadRequest(ModelState);
                }
                
                result = command.Handle();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);

        }
    }
}
