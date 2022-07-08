using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.CommonLayer.Model
{
    public partial class CategoryModel
    {
       

        [Key]
        public int cid { get; set; }
        public string cname { get; set; }
        
      
    }
    public class CategoryResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
