using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.CommonLayer.Model
{
    public class AllProductModel
    {
        public int cid { get; set; }
        public string cname { get; set; }
        public int pid { get; set; }
        public string pname { get; set; }
        public int price { get; set; }
         public int actualcost { get; set; }
        public string pimage { get; set; }

    }
    public class AllProductResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
