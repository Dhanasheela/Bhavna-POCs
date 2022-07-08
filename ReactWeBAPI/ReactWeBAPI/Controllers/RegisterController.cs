using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReactWeBAPI.CommonLayer.Model;
using ReactWeBAPI.ServiceLayer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
       private readonly CategoryContext _context;
        private readonly IRegisterSL _registerSL;

        public RegisterController(IRegisterSL registerSL)
        {
            _registerSL = registerSL;
           
        }
        [HttpPost]
        [Route("CreateRecord")]
        public async Task<IActionResult> CreateRecord(RegisterModel registerModel)
        {
            CreateResponse response = null;
            try
            {
                response = await _registerSL.CreateRecord(registerModel);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;

            }
            return Ok(response);
        }
        [HttpPost]
        [Route("LoginRecord")]
        public async Task<IActionResult> LoginRecord(LoginModel request)
        {
            LoginResponse response = new LoginResponse();
            try
            {

                response = await _registerSL.LoginRecord(request);
                //response.Message = "true";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "failed" + ex.Message.ToString();
               
            }
            return Ok(response);

        }

        private IActionResult Ok(LoginResponse response, object p)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("Category")]
        public async Task<IActionResult> Category(CategoryModel request)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {

                response = await _registerSL.Category(request);
                //response.Message = "true";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "failed" + ex.Message.ToString();

            }
            return Ok(response);

        }

     
        [HttpPost]
        [Route("PostDetail")]
        public async Task<ActionResult> PostDetail(CategoryModel categoryModel)
        {
            try
            {
                
                    await _context.SaveChangesAsync();
                 
                
               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
           return Ok("Inserted successfully!");
        }

        [HttpPost]
        [Route("GetCategory")]
        public async Task<ActionResult> GetCategory(int cid)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {
               // return await _context.Pro

                response = await _registerSL.GetCategory( cid);
              

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "failed" + ex.Message.ToString();

            }
            return Ok(response);
        }

    }
}

