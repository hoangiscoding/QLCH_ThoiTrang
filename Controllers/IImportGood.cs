using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace Controllers
{
    public interface IImportGood
    {
        int GetCurrId(List<ImportGood> importGoods);
        List<ImportGood> LoadAllImportGood();
        void CreateNewImportGood(ImportGood importGood);
        //void EditImportGood(ImportGood importGood);
        void RemoveImportGood(ImportGood importGood);
        List<ImportGood> FindImportGoodById(string id);
        List<ImportGood> FindImportGoodByStaffName(string nameStr);
        List<ImportGood> FindImportGoodByDate(string date);
    }
    public class ImportGoodController : IImportGood
    {
        private string connStr = "Data Source=LAPTOP-HBN2311\\SQLEXPRESS;Initial Catalog=HatiShop;Integrated Security=True";
        private Staff Staff { get; set; }
        private Product Product { get; set; }
        StaffController staffController = new StaffController();
        ProductController productController = new ProductController();
        public void CreateNewImportGood(ImportGood importGood)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("CreateNewImportGood", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", importGood.Id);
                    command.Parameters.AddWithValue("@StaffId", importGood.Staff.Id);
                    command.Parameters.AddWithValue("@ProductId", importGood.Product.Id);
                    command.Parameters.AddWithValue("@ImportTime", importGood.ImportTime);
                    command.Parameters.AddWithValue("@Quantity", importGood.Quantity);
                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in CreateNewImportGood: " + ex.Message);
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

        public int GetCurrId(List<ImportGood> importGoods)
        {
            if (importGoods.Count == 0)
                return 0;
            List<int> idIntList = GetListIdInt(importGoods);
            return idIntList[idIntList.Count - 1];
        }

        public List<ImportGood> LoadAllImportGood()
        {
            List<ImportGood> importGoods = new List<ImportGood>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("LoadImportGood", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["Id"].ToString();
                            var staffId = reader["StaffId"].ToString();
                            var productId = reader["ProductId"].ToString();
                            DateTime importTime = (DateTime)reader["ImportTime"];
                            var quantity = (int)reader["Quantity"];
                            Staff = FindStaff(staffId);
                            Product = FindProduct(productId);
                            ImportGood import = new ImportGood(id,Staff,
                                Product,importTime,quantity);
                            importGoods.Add(import);
                        }
                    }
                }
            }
            return importGoods;
        }

        private Staff FindStaff(string staffId)
        {
            var staffs = new List<Staff>();
            staffs = staffController.LoadAllStaff();
            foreach(Staff staff in staffs) 
            {
                if (staff.Id == staffId)
                    return staff;
            }
            return null;
        }

        private Product FindProduct(string productId)
        {
            var products = new List<Product>();
            products = productController.LoadAllProduct();
            foreach (Product product in products)
            {
                if (product.Id == productId)
                    return product;
            }
            return null;
        }

        private List<int> GetListIdInt(List<ImportGood> importGoods)
        {
            List<int> list = new List<int>();
            foreach (var product in importGoods)
            {
                list.Add(product.IdInt);
            }
            list.Sort();
            return list;
        }

        public void RemoveImportGood(ImportGood importGood)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("RemoveImportGood", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", importGood.Id);
                    command.Parameters.AddWithValue("@ProductId", importGood.Product.Id);
                    command.Parameters.AddWithValue("@Quantity", importGood.Quantity);
                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in RemoveImportGood: " + ex.Message);
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

        public List<ImportGood> FindImportGoodById(string idStr)
        {
            List<ImportGood> importGoods = new List<ImportGood>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FindImportGoodById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", idStr);
                    //thực thi và đọc kết quả
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader["Id"].ToString();
                                var staffId = reader["StaffId"].ToString();
                                var productId = reader["ProductId"].ToString();
                                DateTime importTime = (DateTime)reader["ImportTime"];
                                var quantity = (int)reader["Quantity"];
                                Staff = FindStaff(staffId);
                                Product = FindProduct(productId);
                                ImportGood import = new ImportGood(id, Staff, Product, importTime, quantity);
                                importGoods.Add(import);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in FindProductById: " + ex.Message);
                    }
                }
            }
            return importGoods;
        }

        public List<ImportGood> FindImportGoodByStaffName(string nameStr)
        {
            List<ImportGood> importGoods = new List<ImportGood>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FindImportGoodByStaffName", connection))
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
                                var staffId = reader["StaffId"].ToString();
                                var productId = reader["ProductId"].ToString();
                                DateTime importTime = (DateTime)reader["ImportTime"];
                                var quantity = (int)reader["Quantity"];
                                Staff = FindStaff(staffId);
                                Product = FindProduct(productId);
                                ImportGood import = new ImportGood(id, Staff, Product, importTime, quantity);
                                importGoods.Add(import);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in FindProductById: " + ex.Message);
                    }
                }
            }
            return importGoods;
        }

        public List<ImportGood> FindImportGoodByDate(string date)
        {
            List<ImportGood> importGoods = new List<ImportGood>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FindImportGoodByDate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Date", date);
                    //thực thi và đọc kết quả
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader["Id"].ToString();
                                var staffId = reader["StaffId"].ToString();
                                var productId = reader["ProductId"].ToString();
                                DateTime importTime = (DateTime)reader["ImportTime"];
                                var quantity = (int)reader["Quantity"];
                                Staff = FindStaff(staffId);
                                Product = FindProduct(productId);
                                ImportGood import = new ImportGood(id, Staff, Product, importTime, quantity);
                                importGoods.Add(import);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in FindProductById: " + ex.Message);
                    }
                }
            }
            return importGoods;
        }

        /* public void EditImportGood(ImportGood importGood)
         {
             using (SqlConnection connection = new SqlConnection(connStr))
             {
                 connection.Open();
                 using (SqlCommand command = new SqlCommand("EditImportGoodInfo", connection))
                 {
                     command.CommandType = CommandType.StoredProcedure;

                     command.Parameters.AddWithValue("@Id", importGood.Id);
                     command.Parameters.AddWithValue("@StaffId", importGood.Staff.Id);
                     command.Parameters.AddWithValue("@ProductId", importGood.Product.Id);
                     command.Parameters.AddWithValue("@ImportTime", importGood.ImportTime);
                     command.Parameters.AddWithValue("@Quantity", importGood.Quantity);
                     //thực thi
                     try
                     {
                         command.ExecuteNonQuery();
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine("Error in EditImportGood: " + ex.Message);
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
         }*/
    }
}
