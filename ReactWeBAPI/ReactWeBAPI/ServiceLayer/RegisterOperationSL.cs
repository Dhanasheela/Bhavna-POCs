using Microsoft.AspNetCore.Mvc;
using ReactWeBAPI.CommonLayer.Model;
using ReactWeBAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeBAPI.ServiceLayer
{
    public class RegisterOperationSL : IRegisterSL
    {
        private IRegisterOperationsRL _registerOperationsRL;

        public RegisterOperationSL(IRegisterOperationsRL registerOperationsRL)
        {
            _registerOperationsRL = registerOperationsRL;
        }

        
        public async Task<CreateResponse> CreateRecord(RegisterModel registerModel)
        {
            return await  _registerOperationsRL.CreateRecord(registerModel);
        }
         public async Task<LoginResponse> LoginRecord(LoginModel login)
        {
            return await _registerOperationsRL.LoginRecord(login);
        }
        public async Task<CategoryResponse> Category(CategoryModel category)
        {
            return await _registerOperationsRL.Category(category);
        }
       
        public async Task<ActionResult> PostDetail(CategoryModel categoryModel)
        {
            return await _registerOperationsRL.PostDetail(categoryModel);
        }

        public async  Task<CategoryResponse> GetCategory(int cid)
        {
            return await _registerOperationsRL.GetCategory(cid);
        }

      


    }
}
