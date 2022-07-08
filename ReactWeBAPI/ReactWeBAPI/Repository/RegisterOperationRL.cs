using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReactWeBAPI.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ReactWeBAPI.Repository
{

    public class RegisterOperationRL : IRegisterOperationsRL
    {
        private readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        public object Request { get; private set; }

        public RegisterOperationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);

        }
      
      
        public async Task<LoginResponse> LoginRecord(LoginModel login)
        {

            LoginResponse response = new LoginResponse();
            response.IsSuccess = true;
             response.Message = "";
            response.name = "";
            try
            {
                if (_sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConnection.OpenAsync();
                }

                string loginQuery = "select * from RegisterModel where email = '" + login.email + "' and password = '" + login.password + "' ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(loginQuery, _sqlConnection))
                {
                    DataSet dt = new DataSet();
                    adapter.Fill(dt, "RegisterModel");
                    var role = dt.Tables[0].Rows[0].ItemArray[5];
                    //true
                    var name = dt.Tables[0].Rows[0].ItemArray[2];//dhanu
                    if ((bool)role ) 
                    {
                        
                        response.IsSuccess = true;
                        response.Message =  "" +role  ;
                        response.name = "" + name;

                    }
                    else if(!((bool)role))
                    {

                        response.IsSuccess = true;
                        response.Message = "" + role;
                       
                      
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = " Login failed";

                    }

                }
            }

            catch
            {
                response.IsSuccess = false;
                response.Message = "failed";
            }
            finally
            {
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response ;
            //return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);

        }

        
        public async Task<CreateResponse> CreateRecord(RegisterModel registerModel)
        {
            CreateResponse response = new CreateResponse();
            response.IsSuccess = true;
            response.Message = "successful";

            try
            {
                string selectQuery = @" select email from RegisterModel ";
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(selectQuery, _sqlConnection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                bool flag = false;
                var length = dt.Rows.Count;

                for (int i = 0; i <= length - 1; i++)
                {
                    if (registerModel.email == Convert.ToString(dt.Rows[i].ItemArray[0]))
                    {
                        flag = true;
                    }
                }

                if (flag == false)
                {
                    string insertQuery = "insert into RegisterModel values ( '" + registerModel.email.ToLower() + "', '" + registerModel.name + "', '" + registerModel.password + "','" + registerModel.confirmpassword + "','" + registerModel.role + "') ";
                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, _sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;
                        _sqlConnection.Open();
                        int status = await sqlCommand.ExecuteNonQueryAsync();
                        if (status <= 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "something went wrong";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }


        public async Task<CategoryResponse> Category(CategoryModel category)
        {
            CategoryResponse response = new CategoryResponse();
            response.IsSuccess = true;
            response.Message = "successful";
            try
            {
                string insertQuery = "insert into Categories values (  '" + category.cname + "') ";
                 using (SqlCommand sqlCommand = new SqlCommand(insertQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                     await sqlCommand.ExecuteNonQueryAsync();
                    response.IsSuccess = true;
                    response.Message = " Succesful";
                   
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "something went wrong";
            }
            return response;
        }





       

        public Task<ActionResult> PostDetail(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }

      

        public async Task<CategoryResponse> GetCategory(int cid)
        {
            CategoryResponse response = new CategoryResponse();
            response.IsSuccess = true;
            response.Message = "successful";
            try
            {
                if (_sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConnection.OpenAsync();
                }
                //string categoryQuery=" select category_tb.cname,product_tb.* " +
                //     "from category_tb LEFT JOIN product_tb ON category_tb.cid = product_tb.cid where product_tb.cid = 1";

                // string categoryQuery = "select *from RegisterModel";
               
                    string categoryQuery = "select category_tb.cname,product_tb.* " +
                    "from category_tb LEFT JOIN product_tb" +
                    " ON category_tb.cid=product_tb.cid where  product_tb.cid='" + cid + "' ";
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(categoryQuery, _sqlConnection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                 response.IsSuccess = true;
                response.Message = "Category Found";

            } 

            catch
            {
                response.IsSuccess = false;
                response.Message = "not found";
            }
            finally
            {
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response;

        }

        //public async Task<AllProductResponse> AllProducts(AllProductModel allProduct)
        //{
        //    AllProductResponse response = new AllProductResponse();
        //    response.IsSuccess = true;
        //    response.Message = "successful";
        //    try
        //    {
        //        if (_sqlConnection.State != System.Data.ConnectionState.Open)
        //        {
        //            await _sqlConnection.OpenAsync();

        //        }
        //        string categoryQuery = "select *from product_tb";
        //        DataTable dt = new DataTable();
        //        SqlCommand cmd = new SqlCommand(categoryQuery, _sqlConnection);
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        sda.Fill(dt);
        //        response.IsSuccess = true;
        //        response.Message = "Category Found";

        //    }

        //    catch
        //    {
        //        response.IsSuccess = false;
        //        response.Message = "not found";
        //    }
        //    finally
        //    {
        //        await _sqlConnection.CloseAsync();
        //        await _sqlConnection.DisposeAsync();
        //    }

        //    return response;

        //}

    }
    
}
