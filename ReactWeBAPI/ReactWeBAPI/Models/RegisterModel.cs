using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.CommonLayer.Model
{
    public class RegisterModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public bool role { get; set; } 
        public string confirmpassword { get; set; }
    }
    public class CreateResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
