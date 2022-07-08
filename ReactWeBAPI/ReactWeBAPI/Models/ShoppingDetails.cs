using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.CommonLayer
{
    public class ShoppingDetails
    {
        [Key]
        public int cartid { get; set; }

        public int pid { get; set; }
       
        public int userid { get; set; }

        public int totalamount { get; set; }
        public DateTime date { get; set; }

    }
}
