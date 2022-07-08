using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.CommonLayer.Model
{

   
    public class LoginModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public bool role { get; set; }
         }
    public class LoginResponse
    {
        public string name { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
