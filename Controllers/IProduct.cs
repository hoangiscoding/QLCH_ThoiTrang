using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Collections;
using System.Globalization;
using System.Reflection.Emit;
using System.Xml.Linq;
namespace Controllers
{
    public interface IProduct
    {
        List<Product> LoadAllProduct();
        int GetCurrId(List<Product> products);
        void CreateNewProduct(Product product);
        void EditProductInfo(Product product);
        int GetPriceInt(string priceStr);
        bool RemoveProduct(string productId);
        Product FindProductById(List<Product> products, string id);
        List<Product> FindProductById(string productId);
        List<Product> FindProductByName(string name);
        void SortIdASC(List<Product> products);
        void SortIdDESC(List<Product> products);
        void SortPriceASC(List<Product> products);
        void SortPriceDESC(List<Product> products);
        void SortNameASC(List<Product> products);
        void UpdateProduct(Product product);
    }
    public class ProductController : IProduct
    {
        private string connStr = "Data Source=LAPTOP-HBN2311\\SQLEXPRESS;Initial Catalog=HatiShop;Integrated Security=True";
        public int GetCurrId(List<Product> products)
        {
            if (products.Count == 0)
                return 0;
            List<int> idIntList = GetListIdInt(products);
            return idIntList[idIntList.Count - 1];
        }
        private List<int> GetListIdInt(List<Product> products)
        {
            List<int> list = new List<int>();
            foreach (var product in products)
            {
                list.Add(product.IdInt);
            }
            list.Sort();
            return list;
        }

        public List<Product> LoadAllProduct()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("LoadProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["Id"].ToString();
                            var name = reader["Name"].ToString();
                            var price = (int)reader["Price"];
                            var type = reader["Type"].ToString();
                            var size = reader["Size"].ToString();
                            var quantity = (int)reader["Quantity"];
                            var info = reader["Info"].ToString();
                            var avatarPath = reader["AvatarPath"].ToString();
                            Product product = new Product(id, name, price, type, quantity, size, info, avatarPath);
                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }

        public void CreateNewProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("CreateNewProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Type", product.Type);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    command.Parameters.AddWithValue("@Size", product.Size);
                    command.Parameters.AddWithValue("@Info", product.Info);
                    command.Parameters.AddWithValue("@AvatarPath", product.AvatarPath);
                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in CreateNewProduct: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }

                }
            }
        }

        public void EditProductInfo(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("EditProductInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Type", product.Type);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    command.Parameters.AddWithValue("@Size", product.Size);
                    command.Parameters.AddWithValue("@Info", product.Info);
                    command.Parameters.AddWithValue("@AvatarPath", product.AvatarPath);
                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in EditProduct: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }

                }
            }
        }

        public int GetPriceInt(string priceStr)
        {
            string currencyStr = priceStr;

            // Xóa ký tự mẫu của tiền tệ (VD: "$", "€", "₫")
            currencyStr = currencyStr.Replace("₫", "").Trim();

            // Loại bỏ ký tự phân cách hàng nghìn
            currencyStr = currencyStr.Replace(".", "");

            // Thay thế dấu phân cách thập phân
            currencyStr = currencyStr.Replace(",", ".");

            // Chuyển đổi chuỗi thành số
            decimal number = decimal.Parse(currencyStr, CultureInfo.InvariantCulture);

            return (int)number;
        }

        public bool RemoveProduct(string productId)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("RemoveProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", productId);
                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error in EditProduct: " + ex.Message);
                        return false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return true;
        }

        public Product FindProductById(List<Product> products, string id)
        {
            foreach (var product in products)
            {
                if (product.Id == id) return product;
            }
            return null;
        }

        public void SortIdASC(List<Product> products)
        {
            for (int i = 0; i < products.Count - 1; i++)
                for (int j = i + 1; j < products.Count; j++)
                    if (products[i].IdInt > products[j].IdInt)
                    {
                        var temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
        }

        public void SortIdDESC(List<Product> products)
        {
            for (int i = 0; i < products.Count - 1; i++)
                for (int j = i + 1; j < products.Count; j++)
                    if (products[i].IdInt < products[j].IdInt)
                    {
                        var temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
        }

        public void SortPriceASC(List<Product> products)
        {
            for (int i = 0; i < products.Count - 1; i++)
                for (int j = i + 1; j < products.Count; j++)
                    if (products[i].Price > products[j].Price)
                    {
                        var temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
        }

        public void SortPriceDESC(List<Product> products)
        {
            for (int i = 0; i < products.Count - 1; i++)
                for (int j = i + 1; j < products.Count; j++)
                    if (products[i].Price < products[j].Price)
                    {
                        var temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
        }

        public void SortNameASC(List<Product> products)
        {
            for (int i = 0; i < products.Count - 1; i++)
                for (int j = i + 1; j < products.Count; j++)
                    if (products[i].Name.CompareTo(products[j].Name) > 0)
                    {
                        var temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
        }

        public List<Product> FindProductById(string productId)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FindProductById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", productId);
                    //thực thi và đọc kết quả
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader["Id"].ToString();
                                var name = reader["Name"].ToString();
                                var price = (int)reader["Price"];
                                var type = reader["Type"].ToString();
                                var quantity =(int) reader["Quantity"];
                                var size = reader["Size"].ToString();
                                var info = reader["Info"].ToString();
                                var avatarPath = reader["AvatarPath"].ToString();
                                Product prod = new Product(id,name,price,type,quantity,size,info,avatarPath);
                                products.Add(prod);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in FindProductById: " + ex.Message);
                    }
                }
            }
            return products;
        }

        public List<Product> FindProductByName(string nameStr)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FindProductByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", nameStr);
                    //thực thi và đọc kết quả
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader["Id"].ToString();
                                var name = reader["Name"].ToString();
                                var price = (int)reader["Price"];
                                var type = reader["Type"].ToString();
                                var quantity = (int)reader["Quantity"];
                                var size = reader["Size"].ToString();
                                var info = reader["Info"].ToString();
                                var avatarPath = reader["AvatarPath"].ToString();
                                Product prod = new Product(id, name, price, type, quantity, size, info, avatarPath);
                                products.Add(prod);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in FindProductById: " + ex.Message);
                    }
                }
            }
            return products;
        }

        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in UpdateProduct: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }

                }
            }
        }
    }
}
