using MiniInventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniInventoryManagement.Controllers
{
    public class InventoryController : Controller
    {
        BalProduct objbal = new BalProduct();
        // GET: Inventory
        public ActionResult ListAllProductPage()
        {
            Product objp = new Product();
            objp.lstProducts = new List<Product>();
            var ds = objbal.GetProducts();
            List<Product> listdata = new List<Product>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Product obj = new Product();
                obj.ProductID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductId"]);
                obj.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                obj.Category = ds.Tables[0].Rows[i]["Category"].ToString();
                obj.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                obj.Price = Convert.ToDecimal(ds.Tables[0].Rows[i]["Price"]);
                obj.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedDate"]);

                listdata.Add(obj);
            }

            BalProduct bal = new BalProduct();
            DataSet dss = bal.GetValue();
            decimal total_Value = 0;
            if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                total_Value = Convert.ToDecimal(dss.Tables[0].Rows[0]["total_Value"]);
            }

            ViewBag.TotalInventoryValue = total_Value;

            objp.lstProducts = listdata;

            return View(objp);
        }

        [HttpGet]
        public ActionResult AddProductsPage()
        {


            return View();
        }


        [HttpPost]
        public ActionResult AddProductsPage(Product op)
        {
            if (ModelState.IsValid)
            {
                objbal.AddProduct(op);
                return RedirectToAction("ListAllProductPage", "Inventory");
            }

            return View();
        }




        [HttpGet]
        public ActionResult EditProductPage(int id)
        {
            Product objp = new Product();
            SqlDataReader dr = objbal.getProductById(id);

            Product obj = new Product();
            if (dr.Read())
            {
                obj.ProductID = Convert.ToInt32(dr["ProductId"].ToString());
                obj.ProductName = dr["ProductName"].ToString();
                obj.Category = dr["Category"].ToString();
                obj.Quantity = Convert.ToInt32(dr["Quantity"]);
                obj.Price = Convert.ToDecimal(dr["Price"]);
            }

            return View(obj);
        }


        [HttpPost]
        public ActionResult EditProductPage(Product obj)
        {
            objbal.UpdateProduct(obj);
            return RedirectToAction("ListAllProductPage", "Inventory");
        }



        [HttpGet]
        public ActionResult DeleteProducts(int id)
        {
            Product obj = new Product();
            obj.ProductID = id;

            objbal.DeleteProduct(obj);
            return RedirectToAction("ListAllProductPage", "Inventory");
        }

    }
}