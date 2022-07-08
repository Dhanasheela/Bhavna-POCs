using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.CommonLayer.Model
{
    public partial class ProductModel
    {
        [Key]
        public int id { get; set; }
       // [ForeignKey("category_tb")]
        public int cid { get; set; }
        public string pname { get; set; }
        public int price { get; set; }
        public string pimage { get; set; }
        public string actualcost { get; set; }
      //  public virtual CategoryModel category { get; set; }

    }
    public class ProductResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
