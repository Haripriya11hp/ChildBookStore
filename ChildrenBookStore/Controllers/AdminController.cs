using ChildrenBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenBookStore.Controllers
{
    public class AdminController : Controller
    {
        public IConfiguration Configuration { get; }
        public AdminController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(BookDetail book)
        {
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into BookDetail (book_name,category_name,book_authorname,book_price,Description,Image) Values ( '{book.book_name}','{book.category_name}', '{book.book_authorname}', '{book.book_price}','{book.Description}','{book.Image}' )";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return View();
        }
        public IActionResult Display()
        {
            List<BookDetail> UserList = new List<BookDetail>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From ProductDetails";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        BookDetail user = new BookDetail();
                        user.book_id = Convert.ToInt32(dataReader["book_id"]);
                        user.book_name = Convert.ToString(dataReader["book_name"]);
                        user.category_name = Convert.ToString(dataReader["category_name"]);
                        user.book_authorname = Convert.ToString(dataReader["book_authorname"]);
                        user.book_price = Convert.ToInt32(dataReader["book_price"]);
                        user.Description = Convert.ToString(dataReader["Description"]);
                        user.Image = Convert.ToString(dataReader["Image"]);
                        UserList.Add(user);
                    }
                }
                connection.Close();
            }
            return View(UserList);
        }
    }
}