using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicsLibrary;

namespace WebForComics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        [HttpGet("ComicsList")]
        public List<Comics> GetAllBooks(int comicsId)
        {
            return new List<Comics>()
            {
                new Comics()
                {
                    Id = 1,
                    Name = "Человек-паук 2077"
                },
                new Comics()
                {
                    Id = 2,
                    Name = "Iron-man"
                },
                new Comics()
                {
                    Id = 3,
                    Name = "Борщ"
                }
            };
        }
    }
}
