using Microsoft.AspNetCore.Mvc;
using ReactWeBAPI.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.Repository
{
    public interface IRegisterOperationsRL
    {
        public Task<CreateResponse> CreateRecord(RegisterModel registerModel);
        public  Task<LoginResponse> LoginRecord(LoginModel login);
        public Task<CategoryResponse> Category(CategoryModel category);
        public Task<ActionResult> PostDetail(CategoryModel categoryModel);
      public   Task<CategoryResponse> GetCategory(int cid);
  
        //public Task<ActionResult> PostDetail(category_tb categoryModel);
    }
}
