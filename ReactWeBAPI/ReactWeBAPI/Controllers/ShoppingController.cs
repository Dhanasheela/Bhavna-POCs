using Microsoft.AspNetCore.Mvc;
using ReactWeBAPI.CommonLayer;
using ReactWeBAPI.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactWeBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private CategoryContext _Context;
        public ShoppingController(CategoryContext Context)
        {
            _Context = Context;
           
        }

        // GET: api/<Shopping>
        [HttpGet("{id}")]
        public object GetShopping(int id) {

               var results = (from shoppingdetails in _Context.shoppingdetails 
                   join RegisterModel  in _Context.RegisterModel on  shoppingdetails.userid equals RegisterModel.id
                   join Products in _Context.Products on shoppingdetails.pid equals Products.pid
                   where RegisterModel.id==id
                   select new ShoppingDetails
                   {
                       cartid = shoppingdetails.cartid,
                       pid = shoppingdetails.pid,
                       userid = shoppingdetails.userid,
                       totalamount = shoppingdetails.totalamount,
                       date = shoppingdetails.date,
                                         }).ToList();
                                 return results;
        }

        // GET api/<Shopping>/5
       // [HttpGet("{id}")]
        public string Get() 
        {
            return "value";
        }

        // POST api/<Shopping>
        [HttpPost]
        public  void Post([FromBody] ShoppingDetails value)
        {
                        
            _Context.shoppingdetails.Add(value);
            _Context.SaveChanges();

        }

        // PUT api/<Shopping>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Shopping>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var shop = _Context.shoppingdetails.FirstOrDefault(s => s.cartid == id);
            if(shop!=null)
            {
                _Context.shoppingdetails.Remove(shop);
                _Context.SaveChanges();
            }
        }
    }
}
