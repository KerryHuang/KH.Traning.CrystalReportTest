using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;



namespace CrystalReportMVC.Models
{
    /// <summary>
    /// 產品
    /// </summary>
    public class ProductModel
    {
        public System.Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public System.DateTime EffectivedDate { get; set; }
    }

    public class ProductRepository
    {
        /// <summary>
        /// 使用物件
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetAll()
        {
            List<ProductModel> items = new List<ProductModel>();

            try
            {
                // 連線字串
                string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                // SQL
                string sql = "select * from Product order by ProductName";
                // 準備連線
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // 取得資料方式 
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        // 連線取得方式是字串
                        command.CommandType = System.Data.CommandType.Text;

                        // 開起連線
                        if (conn.State != System.Data.ConnectionState.Open)
                            conn.Open();

                        // 讀取資料方法
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 開始讀取
                            while (reader.Read())
                            {
                                // 將資料放至物件裡
                                ProductModel item = new ProductModel
                                {
                                    Id = Guid.Parse(reader["Id"].ToString()),
                                    ProductName = reader["ProductName"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"].ToString()),
                                    EffectivedDate = Convert.ToDateTime(reader["EffectivedDate"].ToString())
                                };

                                // 加入至物料集
                                items.Add(item);
                            }
                        }


                    }
                }
            }
            catch { }
            
            return items;
        }

        /// <summary>
        /// 使用資料集
        /// </summary>
        /// <returns>資料集</returns>
        public ProductDataSet ExcuteDataSet()
        {
            ProductDataSet ds = new ProductDataSet();
            DataTable dt = ds.Tables["Product"];

            try
            {
                // 連線字串
                string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                // SQL
                string sql = "select * from Product order by ProductName";
                // 準備連線
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // 取得資料方式 
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        // 連線取得方式是字串
                        command.CommandType = System.Data.CommandType.Text;

                        // 開起連線
                        if (conn.State != System.Data.ConnectionState.Open)
                            conn.Open();

                        // 讀取資料方法
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 開始讀取
                            while (reader.Read())
                            {
                                // 將資料放至物件裡
                                DataRow dr = dt.NewRow();
                                dr["Id"] = Guid.Parse(reader["Id"].ToString());
                                dr["ProductName"] = reader["ProductName"].ToString();
                                dr["Price"] = Convert.ToDecimal(reader["Price"].ToString());
                                dr["EffectivedDate"] = Convert.ToDateTime(reader["EffectivedDate"].ToString());

                                // 加入至物料集
                                dt.Rows.Add(dr);
                            }
                        }


                    }
                }
            }
            catch { }

            return ds;
        }
    }


}