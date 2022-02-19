using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class ContController1 : Controller
    {
        // GET: ContController1
        public ActionResult Index()
        {

            List<Product> li = new List<Product>();

            Sqlconnection cn = new Sqlconnection();
            //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Exam;IntegrtatedSecurity = true;Connect 
            cn.ConnectionString = @"data source =(localdb)\MSSQLLocalDB;
            Initial Catalog = MiniProject;Integrated Security=True;";

            cn.open();
            SqlCom2mand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Product";

            try
            {
                SqlDataReader dr = cmdEmp.ExecuteReader();

                while (dr.Read())
                {
                    li.Add(new Product
                    {
                        ProductId = (int)dr["ProductId"],
                        ProductName = (string)dr["ProductName"],
                        Rate = (string)dr["Rate"],
                        Description = (string)dr["Description"],
                        CategoryName = (string)dr["CategoryName"]
                    });
                }
                dr.Close();

                } 
            catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            return View(li);
        }

        // GET: ContController1/Details/5
        public ActionResult Details(int Productid)
        {
            return View();
        }

        // GET: ContController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product obj)
        {
            Sqlconnection cn = new Sqlconnection();
            //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Exam;IntegrtatedSecurity = true;Connect 
            cn.ConnectionString = @"data source =(localdb)\MSSQLLocalDB;
            Initial Catalog = MiniProject;Integrated Security=True;";

            cn.open();
            SqlCommand cmdInsert = new SqlCommand
            {
                Connection = cn,
                CommandType = System.Data.CommandType.Text,
                CommanText = "Insert into Product values (@ProuctName , @Rate,@Desription, @CategoryName);
            };

            cmdInsert.Parameter.AddWithValue("@ProductName", obj.ProductName);
            cmdInsert.Parameter.AddWithValue("@Rate", obj.Rate);
            cmdInsert.Parameter.AddWithValue("@Desription", obj.Description);
            cmdInsert.Parameter.AddWithValue("@CategoryName", obj.CategoryName);
            try
            {
                cmdInsert.ExcuteNonQuery();

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
            finally
            {

                cn.Close();
            }
        }

        // GET: ContController1/Edit/5
        public ActionResult Edit(int id)
        {
            Sqlconnection cn = new Sqlconnection();
            //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Exam;IntegrtatedSecurity = true;Connect 
            cn.ConnectionString = @"data source =(localdb)\MSSQLLocalDB;
            Initial Catalog = MiniProject;Integrated Security=True;";

            cn.open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Product where student ProductId=@ProductId";
            cmdInsert.Parameters.AddWithValue("@ProductId", id);
            Product obj = null;
            SqlDataReader dr = cmdInsert.ExecuteReader();
            if (dr.Read())

                obj = new Product { ProductId = id, ProductName = dr.GetString(1), Rate = dr.GetInt32(2), Description = dr.GetString(1), CategoryName = dr.GetString(1) }
            else
            {
                ViewBag.ErrorMessage = "Not Found";
            }
            cn.Close();
            return View(obj);
        

        }

        // POST: ContController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ? ProductId, Product obj)
        {
            Sqlconnection cn = new Sqlconnection();
            //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Exam;IntegrtatedSecurity = true;Connect 
            cn.ConnectionString = @"data source =(localdb)\MSSQLLocalDB;
            Initial Catalog = MiniProject;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;

            cmdInsert.Commandtext = "Update the student name = ProductName= @ProductName, Rate= @Rate, Desciption= @Desciption,CategoryName=@CategoryName";
            cmdInsert.Parameter.AddWithValue("@ProductName", obj.ProductName);
            cmdInsert.Parameter.AddWithValue("@Rate", obj.Rate);
            cmdInsert.Parameter.AddWithValue("@Desciption", obj.Description);
            cmdInsert.Parameter.AddWithValue("@CategoryName", obj.CategoryName);

            try
            {
                cmdInsert.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }

            finaly
                {
                cn.close();
            }
        }

        // GET: ContController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            Sqlconnection cn = new Sqlconnection();
            //Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Exam;IntegrtatedSecurity = true;Connect 
            cn.ConnectionString = @"data source =(localdb)\MSSQLLocalDB;
            Initial Catalog = MiniProject;Integrated Security=True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "delete from Product where where ProductId = @id"




            try
            {
                cmdInsert.ExecuteNonQuery();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine(e.Message);
                return View();
            }

            finaly
             {
                cn.close();

            } }
    }
}
