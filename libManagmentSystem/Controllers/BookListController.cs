using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libManagmentSystem.Repository;
using log4net.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4net.config", Watch = true)]


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class BookListController : ControllerBase
    {
        private readonly ILibrary ibk;
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BookListController(ILibrary obj)
        {
            this.ibk = obj;
        }

        // GET: api/<BookListController>
        [HttpGet]
        [Route("FetchBooks")]
        public IActionResult FetchBooks()
        {
            BasicConfigurator.Configure();
            log.Info("entering AuthenticateUser");
            log.Info("entering Fetch all method");
            return Ok(ibk.ShowBooks());
        }

        // GET api/<BookListController>/5
        [HttpGet]
        [Route("FetchBookById")]
        public IActionResult FetchBookById(int id)
        {
            //IQueryable<Books> Got = (IQueryable<Books>)ibk.GetBookWithID(id);
            BasicConfigurator.Configure();
            log.Info("Fetch Book By Id");
            Book Got = ibk.FetchBookByID(id);
            if (Got == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(Got);
            }
        }

        // POST api/<BookListController>
        [HttpPost]
        [Route("AddBooks")]
        public IActionResult AddBooks([FromBody] Book value)
        {
            BasicConfigurator.Configure();
            log.Info("Adding Books");
            bool solution = ibk.AddBook(value);
            if (solution == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        // PUT api/<BookListController>/5
        [HttpPut]
        [Route("UpdateBooks")]
        public IActionResult UpdateBooks(int id, [FromBody] Book value)
        {
            BasicConfigurator.Configure();
            log.Info("Update Books");
            bool solution = ibk.UpdateBook(id, value);
            if (solution == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }


        // DELETE api/<BookListController>/5
        [HttpDelete]
        [Route("RemoveBooks")]
        public IActionResult RemoveBooks(int id)
        {
            BasicConfigurator.Configure();
            log.Info("Delete Books");
            bool solution = ibk.RemoveBook(id);
            if (solution == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}
