using MySql.Data.MySqlClient;
using ShoppingCart.MVC.Models;
using ShoppingCart.MVC.Repositories.Interfaces;

namespace ShoppingCart.MVC.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _con;

        public ProductRepository(IConfiguration config)
        {
            _con = config.GetConnectionString("DefaultConnection")!;
        }

        public List<Product> GetAll()
        {
            var list = new List<Product>();

            using var con = new MySqlConnection(_con);
            using var cmd = new MySqlCommand("SELECT * FROM Products", con);

            con.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new Product
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Name = r["Name"].ToString()!,
                    Price = Convert.ToDecimal(r["Price"])
                });
            }
            return list;
        }

        public Product? GetById(int id)
        {
            Product? p = null;

            using var con = new MySqlConnection(_con);
            using var cmd = new MySqlCommand(
                "SELECT * FROM Products WHERE Id=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            using var r = cmd.ExecuteReader();

            if (r.Read())
            {
                p = new Product
                {
                    Id = Convert.ToInt32(r["Id"]),
                    Name = r["Name"].ToString()!,
                    Price = Convert.ToDecimal(r["Price"])
                };
            }
            return p;
        }
    }
}
