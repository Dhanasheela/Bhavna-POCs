using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.CommonLayer.Model
{
    public class Product
    {

        [Key]
        public int pid { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string pname { get; set; }

        public int price { get; set; }
        public int actualcost { get; set; }
        public string pimage { get; set; }

        [ForeignKey("cid")]
        public int Categorycid { get; set; }

       
        // [NotMapped]
        //public IFormFile imageFile { get; set; }

        [NotMapped]
        public string FileName { get; set; }

       
        // public virtual Category Categories { get; set; }

        // public List<Category> Cat{ get; set; }

    }

}

