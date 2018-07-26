using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryRepository;


        public CategoryController(ICategory categoryRepository)
        {

            _categoryRepository = categoryRepository;

        }

        #region get all and get by id 

        [HttpGet]
        public IEnumerable<Models.Category> Get()
        {
            var categories = _categoryRepository.GetAll();

            return categories;
        }


        [HttpGet]

        public IActionResult Get([FromBody] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Models.Category category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        #endregion



        #region Post
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Models.Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _categoryRepository.Insert(category);
                _categoryRepository.Save();
            }
            catch (Exception ex)
            {
                if (CategoryExist(category.categoryId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }

            }

            return CreatedAtAction("GetCategory", new { id = category.categoryId }, category);
        }
        #endregion





        #region Update
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]Models.Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            if (id != category.categoryId)
            {
                return BadRequest();
            }

            try
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
            }
            catch (Exception ex)
            {
                if (!CategoryExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok(category);
        }
        #endregion

        #region Delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CategoryExist(id))
            {
                return NotFound();
            }

            _categoryRepository.Delete(id);
            _categoryRepository.Save();

            return Ok();
        }
        #endregion


        private bool CategoryExist(int id)
        {
            return _categoryRepository.GetById(id) != null;
        }







    }
}