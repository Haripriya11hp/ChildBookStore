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
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserDetails()
        {
            return View();
        }


        [HttpPost]
        public IActionResult UserDetails(UserDetails user)
        {

            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into UserDetails (UserDetails_name,UserDetails_email,UserDetails_address,UserDetails_state,UserDetails_pincode) Values ('{user.UserDetails_name}', '{user.UserDetails_email}','{user.UserDetails_address}','{user.UserDetails_state}','{user.UserDetails_pincode}' )";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return RedirectToAction("Sucess");
        }
        public IActionResult LoginSignupPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginSignupPage(Registration registration)
        {

            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into Register (name, email, password) Values ('{registration.name}', '{registration.email}','{registration.password}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            ViewBag.Result = 1;
        
         return View();
    }
        public IActionResult Login(Registration register)
        {

            var check = 1;
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select email,password From Register where email = '{register.LoginEmail}' and password = '{register.LoginPassword}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    var validate = command.ExecuteScalar();
                    if (validate != null)
                    {
                        check = 0;

                    }
                    connection.Close();
                }

            }
            if (check == 0)
            {

                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.Query = 1;
            }

            return RedirectToAction("LoginSignupPage");

        }
        public IActionResult ActivityBooks()
        {
            return View();
        }
        public IActionResult DotToDotBook()
        {
            return View();
        }
        public IActionResult DrawingBook()
        {
            return View();
        }
        public IActionResult SubjectBooks()
        {
            return View();
        }
        public IActionResult MathsBook()
        {
            return View();
        }
        public IActionResult ScienceBook()
        {
            return View();
        }
        public IActionResult StoryBooks()
        {
            return View();
        }
        public IActionResult BedTimeStory()
        {
            return View();
        }
        public IActionResult PictureStory()
        {
            return View();
        }
        public IActionResult Sucess()
        {
            List<UserDetails> UserList = new List<UserDetails>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From UserDetails";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        UserDetails user = new UserDetails();
                        user.UserDetails_id = Convert.ToInt32(dataReader["userdetails_id"]);
                        user.UserDetails_name = Convert.ToString(dataReader["Name"]);
                        user.UserDetails_email = Convert.ToString(dataReader["Email"]);
                        user.UserDetails_address = Convert.ToString(dataReader["Address"]);
                        user.UserDetails_state = Convert.ToString(dataReader["State"]);
                        user.UserDetails_pincode = Convert.ToInt32(dataReader["Pincode"]);
                        UserList.Add(user);
                    }
                }
                connection.Close();

            }
            return View(UserList);
        }
        //[Route]
        public IActionResult Cart1()
        {
            return View();
        }
        public IActionResult Display()
        {
            List<BookDetail> UserList = new List<BookDetail>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From ProductDisplay where Product_Id = '7'";
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
                        ViewBag.Id = Convert.ToInt32(dataReader["book_id"]);
                    }
                }
                connection.Close();

            }

            return View(UserList);
        }
        public IActionResult Cart()
        {
            List<BookDetail> CartList = new List<BookDetail>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From ProductDisplay p, Cart c where c.Id = p.Product_Id";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        BookDetail user = new BookDetail();
                        user.book_id = Convert.ToInt32(dataReader["book_Id"]);
                        user.book_name = Convert.ToString(dataReader["book_name"]);
                        user.category_name = Convert.ToString(dataReader["category_name"]);
                        user.book_authorname = Convert.ToString(dataReader["book_authorname"]);
                        user.book_price = Convert.ToInt32(dataReader["book_price"]);
                        user.Description = Convert.ToString(dataReader["Description"]);
                        user.Image = Convert.ToString(dataReader["Image"]);
                        CartList.Add(user);
                        ViewBag.Id = Convert.ToInt32(dataReader["book_id"]);
                    }
                }
                connection.Close();

            }

            return View(CartList);

        }

        [HttpPost]
        public IActionResult Cartinsert(int id)
        {
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into Cart(Id) Values ('{id}')";

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

        public IActionResult ProductDisplay()
        {
            List<Books> products = new List<Books>() {
                new Books () {
                    book_id = 1,
                    Photo ="https://rukminim1.flixcart.com/image/612/612/jvwpfgw0/book/6/2/3/grandma-s-bag-of-stories-original-imafgzw6mwzjygzf.jpeg?q=70",
                    book_name = "SudhaMurthy's Story Bag",
                    book_price = 650,
                    book_authorname= " Sudha Murthy",
                    Description=" No one can resist a good story, especially those told by a grandmother. In Grandma’s Bag of Stories, Sudha Murty reminds readers of a simple time, where a fun afternoon usually involved sitting by one’s grandma to hear her stories."
                },
            };
            ViewBag.products = products;
            return View();
        }

    }
}


