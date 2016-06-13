using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace CrystalReportTest.Model
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
        public List<ProductModel> GetAll()
        {
            List<ProductModel> items = new List<ProductModel>();
            // 連線字串
            string connectionString = WebConfigurationManager.ConnectionStrings[""].ConnectionString;
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

            return items;
        }
    }
}