﻿using Guden.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guden.Api.Model.Utilities;
using Guden.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace Guden.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Consumes("application/json")]
 
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetList([FromQuery] PagerRequest request)
        {
            var result = _productService.GetList(new Core.Entities.Concrete.PagerRequest()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                SortColumb = request.SortColumb
            });
            if (result.Success)
            {
                result.DataCount = result.Data.Count;
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategoryId([FromHeader] int categoryId )
        {
            var result = _productService.GetListByCategoryById(categoryId);
            if (result.Success)
            {
                result.DataCount = result.Data.Count;
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getbyidl")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result.Message);
            
               return BadRequest(result.Message);

        }
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);

        }
        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);

        }
    }
}
