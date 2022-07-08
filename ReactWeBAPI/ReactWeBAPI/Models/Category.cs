using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.CommonLayer.Model
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int cid { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string cname { get; set; }
       // public List<Product> Products { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
