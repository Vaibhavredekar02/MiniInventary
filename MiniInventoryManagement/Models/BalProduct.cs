using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MiniInventoryManagement.Models
{
    public class BalProduct
    {
        SqlConnection con = new SqlConnection("Data Source=VAIBHAV;Initial Catalog=inventory;Integrated Security=True;Encrypt=False");


        public void AddProduct(Product objp)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spinventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "InsertProduct");
            cmd.Parameters.AddWithValue("@ProductName", objp.ProductName);
            cmd.Parameters.AddWithValue("@Category", objp.Category);
            cmd.Parameters.AddWithValue("@Quantity", objp.Quantity);
            cmd.Parameters.AddWithValue("@Price", objp.Price);
            cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataSet GetProducts()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spinventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetAllProducts");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }


        public SqlDataReader getProductById(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spinventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetProductbyID");
            cmd.Parameters.AddWithValue("@PID", id);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;


        }

        public void UpdateProduct(Product objp)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spinventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateProduct");
            cmd.Parameters.AddWithValue("@PID", objp.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", objp.ProductName);
            cmd.Parameters.AddWithValue("@Category", objp.Category);
            cmd.Parameters.AddWithValue("@Quantity", objp.Quantity);
            cmd.Parameters.AddWithValue("@Price", objp.Price);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteProduct(Product objp)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spinventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DeleteProduct");
            cmd.Parameters.AddWithValue("@PID", objp.ProductID);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataSet GetValue()
        {
           
            SqlCommand cmd = new SqlCommand("spinventory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UDF");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet(); 
            con.Open();

            adpt.Fill(ds);
            return ds;
        }
    }
}