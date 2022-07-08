    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ReactWeBAPI.CommonLayer.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    namespace ReactWeBAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            private CategoryContext _Context;
            private readonly IWebHostEnvironment webHostEnvironment;
            public ProductController(CategoryContext Context, IWebHostEnvironment hostEnvironment)
            {
                _Context = Context;
                webHostEnvironment = hostEnvironment;
            }
        
                    //[HttpGet]

            //public IActionResult Get()
            //{

            //   // List<Product> products;
            //    try
            //    {

            //        var  products = from Category in _Context.Categories
            //                       join Product in _Context.Products on
            //                       Category.cid equals Product.Categorycid

            //                       select new
            //                       {
            //                           Category.cname,
            //                           Product.pname,
            //                           Product.price,
            //                           Product.pimage,
            //                           Product.actualcost,
            //                           Product.Categorycid


            //                       };
            //        //products = _Context.Set<Product>().ToList();
            //    }
            //    catch(Exception)
            //    {
            //        throw;
            //    }
            //    return  Ok();
            //}
            [HttpGet]
            [Route("Getproducts")]
            public List<Product> Getproducts()
            {

                List<Product> product;
                try
                {
                    product = _Context.Set<Product>().ToList();
           
            }
                catch (Exception)
                {
                    throw;
                }
                return product;
            }

            [HttpGet]
            [Route("GetCategory")]
            public List<Category> GetCategory()
            {

                List<Category> categories;
                try
                {
                categories = _Context.Set<Category>().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return categories;
            }
            [HttpGet]
            [Route("AllCategory")]
            public object AllCategory()
            {
                var query =( from p in _Context.Products
                            join c in _Context.Categories
                            on p.Categorycid equals c.cid
                             select new
                             {
                                 cid = c.cid,
                                 cname = c.cname,
                                 pid = p.pid,
                                 pname = p.pname,
                                 price = p.price,
                                 pimage = p.pimage,
                                 actualcost = p.actualcost,
                                 Categorycid = p.Categorycid,
                             }).ToList();
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(query, Newtonsoft.Json.Formatting.Indented);
                return query;
            }
        
            [HttpPost]
            [Route("PostProduct")]
            public async Task<IActionResult> PostProduct(Product product)
            {
                try
                {
              
                  //  product.pimage = await SaveImage(product.imageFile);
                  //  _Context.Products.Add(product);
                  //  await _Context.SaveChangesAsync();
                  //return Ok("inserted succesfully");

                    if (ModelState.IsValid)
                    {
                        string uniqueFileName = UploadedFile(product);

                        Product products = new Product
                        {
                            pid = product.pid,
                            pname = product.pname,
                            price = product.price,
                            actualcost = product.actualcost,
                            pimage = product.pimage,
                            Categorycid = product.Categorycid,
                        };
                        _Context.Add(products);
                        await _Context.SaveChangesAsync();
                        
                    }
                    return Ok("inserted successfully") ;
                }


            
                catch (Exception ex)
                {
                    return BadRequest("Failed to insert!");
                    //return StatusCode(StatusCodes.Status500InternalServerError, ex);
                }

           
            }
           
           [HttpGet("{id}")]
           public object ProductId(int id)
            {
                var result = (from Product p in _Context.Products
                              where p.pid == id
                              select new Product
                              {
                                  pid = p.pid,
                                  pname = p.pname,
                                  price = p.price,
                                  pimage = p.pimage,
                                  actualcost = p.actualcost,
                                  Categorycid = p.Categorycid,
                              }).ToList();
                if (result == null)
                {
                    return NotFound();
                }
                // string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
                return result;

            }

        //[HttpGet("{id}")]

        //public object GetCategoryId(int id)
        //{
        //    var result = (from Category c in _Context.Categories
        //                  where c.cid == id
        //                  select new Category
        //                  {
        //                      cid = c.cid,
        //                      cname = c.cname,

        //                  }).ToList();
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    // string json = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
        //    return result;
        //}
        //public async Task<string> SaveImage(IFormFile imageFile)
        //{
        //    string pimage = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
        //    pimage = pimage + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
        //    var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "images", pimage);
        //    using (var fileStream = new FileStream(imagePath, FileMode.Create))
        //    {
        //        await imageFile.CopyToAsync(fileStream);

        //    }
        //    return pimage;

        //}

        private string UploadedFile(Product model)
        {
            string uniqueFileName = null;

            if (model.pimage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                //  uniqueFileName = Guid.NewGuid().ToString() + "_" + model.pimage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    //  model.pimage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


    }
    }
