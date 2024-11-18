using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public interface IBill
    {
        int GetCurrId(List<Bill> bills);
        List<Bill> LoadAllBill();
        List<BillDetail> LoadBillDetail();
        List<Bill> FindBillById(string idStr);
        List<Bill> FindBillByCustomerName(string nameStr);
        List<Bill> FindBillByDate(string date);
        void CreateNewBill(Bill bill);
        void CreateNewBillDetail(BillDetail billDetail);
        void UpdateBill(string billId, float originalAmount, float discountAmount, float discountedAmount);
        void PayBill(string billId, float originalAmount, float discountAmount, float discountedAmount);

    }
    public class BillController : IBill
    {
        private string connStr = "Data Source=LAPTOP-HBN2311\\SQLEXPRESS;Initial Catalog=HatiShop;Integrated Security=True";
        private Staff Staff { get; set; }
        private Product Product { get; set; }
        private Customer Customer { get; set; }
        StaffController staffController = new StaffController();
        ProductController productController = new ProductController();
        CustomerController customerController = new CustomerController();

        public int GetCurrId(List<Bill> bills)
        {
            if (bills.Count == 0)
                return 0;
            List<int> idIntList = GetListIdInt(bills);
            return idIntList[idIntList.Count - 1];
        }

        private List<int> GetListIdInt(List<Bill> bills)
        {
            List<int> list = new List<int>();
            foreach (var product in bills)
            {
                list.Add(product.IdInt);
            }
            list.Sort();
            return list;
        }

        public List<Bill> LoadAllBill()
        {
            List<Bill> bills = new List<Bill>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("LoadBill", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["Id"].ToString();
                            var customerId = reader["CustomerId"].ToString();
                            var staffId = reader["StaffId"].ToString();
                            DateTime creationTime = (DateTime)reader["CreationTime"];
                            float discountAmount = float.Parse(reader["DiscountAmount"].ToString());
                            float originalPrice = float.Parse(reader["OriginalPrice"].ToString());
                            float discountedTotal = float.Parse(reader["DiscountedTotal"].ToString());
                            Staff = FindStaff(staffId);
                            Customer = FindCustomer(customerId);
                            Bill bill = new Bill(id, Customer, Staff, creationTime,
                                discountAmount, originalPrice, discountedTotal);
                            bills.Add(bill);
                        }
                    }
                }
            }
            return bills;
        }

        public List<BillDetail> LoadBillDetail()
        {
            List<BillDetail> billDetails = new List<BillDetail>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("LoadBillDetail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["Id"].ToString();
                            var productId = reader["ProductId"].ToString();
                            var product = FindProduct(productId);
                            var quantity = (int)reader["Quantity"];
                            float total = float.Parse(reader["Total"].ToString());
                            BillDetail billDetail = new BillDetail(id, product, quantity, total);
                            billDetails.Add(billDetail);
                        }
                    }
                }
            }
            return billDetails;
        }

        private Customer FindCustomer(string customerId)
        {
            var customers = new List<Customer>();
            customers = customerController.LoadAllCustomer();
            foreach (Customer customer in customers)
            {
                if (customer.Id == customerId)
                    return customer;
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

        private Staff FindStaff(string staffId)
        {
            var staffs = new List<Staff>();
            staffs = staffController.LoadAllStaff();
            foreach (Staff staff in staffs)
            {
                if (staff.Id == staffId)
                    return staff;
            }
            return null;
        }

        public void CreateNewBill(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("CreateNewBill", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", bill.Id);
                    command.Parameters.AddWithValue("@StaffId", bill.Staff.Id);
                    command.Parameters.AddWithValue("@CustomerId", bill.Customer.Id);
                    command.Parameters.AddWithValue("@CreationTime", bill.CreationTime);
                    command.Parameters.AddWithValue("@DiscountAmount", bill.DiscountAmount);
                    command.Parameters.AddWithValue("@OriginalPrice", bill.OriginalAmnount);
                    command.Parameters.AddWithValue("@DiscountedTotal", bill.DiscountedPrice);
                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in CreateNewBill: " + ex.Message);
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

        public void UpdateBill(string billId, float originalAmount, float discountAmount, float discountedAmount)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateBill", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", billId);
                    command.Parameters.AddWithValue("@OriginalPrice", originalAmount);
                    command.Parameters.AddWithValue("@DiscountAmount", discountAmount);
                    command.Parameters.AddWithValue("@DiscountedTotal", discountedAmount);

                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in UpdateBill: " + ex.Message);
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

        public void PayBill(string billId, float originalAmount, float discountAmount, float discountedAmount)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("PayBill", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", billId);
                    command.Parameters.AddWithValue("@OriginalPrice", originalAmount);
                    command.Parameters.AddWithValue("@DiscountAmount", discountAmount);
                    command.Parameters.AddWithValue("@DiscountedTotal", discountedAmount);

                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in PayBill: " + ex.Message);
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

        public void CreateNewBillDetail(BillDetail billDetail)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("CreateNewBillDetail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", billDetail.Id);
                    command.Parameters.AddWithValue("@ProductId", billDetail.Product.Id);
                    command.Parameters.AddWithValue("@Quantity", billDetail.Quantity);
                    command.Parameters.AddWithValue("@Total", billDetail.Total);
                    //thực thi
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in CreateNewBillDetail: " + ex.Message);
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

        public List<Bill> FindBillById(string idStr)
        {
            List<Bill> bills = new List<Bill>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FindBillById", connection))
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
                                var customerId = reader["CustomerId"].ToString();
                                var staffId = reader["StaffId"].ToString();
                                DateTime creationTime = (DateTime)reader["CreationTime"];
                                float discountAmount = float.Parse(reader["DiscountAmount"].ToString());
                                float originalPrice = float.Parse(reader["OriginalPrice"].ToString());
                                float discountedTotal = float.Parse(reader["DiscountedTotal"].ToString());
                                Staff = FindStaff(staffId);
                                Customer = FindCustomer(customerId);
                                Bill bill = new Bill(id, Customer, Staff, creationTime,
                                    discountAmount, originalPrice, discountedTotal);
                                bills.Add(bill);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in FindProductById: " + ex.Message);
                    }
                }
            }
            return bills;
        }

        public List<Bill> FindBillByCustomerName(string nameStr)
        {
            List<Bill> bills = new List<Bill>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FindBillByCustomerName", connection))
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
                                var customerId = reader["CustomerId"].ToString();
                                var staffId = reader["StaffId"].ToString();
                                DateTime creationTime = (DateTime)reader["CreationTime"];
                                float discountAmount = float.Parse(reader["DiscountAmount"].ToString());
                                float originalPrice = float.Parse(reader["OriginalPrice"].ToString());
                                float discountedTotal = float.Parse(reader["DiscountedTotal"].ToString());
                                Staff = FindStaff(staffId);
                                Customer = FindCustomer(customerId);
                                Bill bill = new Bill(id, Customer, Staff, creationTime,
                                    discountAmount, originalPrice, discountedTotal);
                                bills.Add(bill);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in FindBillByCustomerName: " + ex.Message);
                    }
                }
            }
            return bills;
        }

        public List<Bill> FindBillByDate(string date)
        {
            List<Bill> bills = new List<Bill>();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("FindBillByDate", connection))
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
                                var customerId = reader["CustomerId"].ToString();
                                var staffId = reader["StaffId"].ToString();
                                DateTime creationTime = (DateTime)reader["CreationTime"];
                                float discountAmount = float.Parse(reader["DiscountAmount"].ToString());
                                float originalPrice = float.Parse(reader["OriginalPrice"].ToString());
                                float discountedTotal = float.Parse(reader["DiscountedTotal"].ToString());
                                Staff = FindStaff(staffId);
                                Customer = FindCustomer(customerId);
                                Bill bill = new Bill(id, Customer, Staff, creationTime,
                                    discountAmount, originalPrice, discountedTotal);
                                bills.Add(bill);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in FindBillByDate: " + ex.Message);
                    }
                }
            }
            return bills;
        }
    }
}
