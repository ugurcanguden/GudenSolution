using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guden.Business.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace Guden.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    [Consumes("application/json")]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetCategories()
        {
           var result= _categoryService.GetList();
           if (result.Success)
               return Ok(result.Data);

           return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetCategoryById(int Id)
        {
            var result = _categoryService.GetById(Id);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }
    }
}
