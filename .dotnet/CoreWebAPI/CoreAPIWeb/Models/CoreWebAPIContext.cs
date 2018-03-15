using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static CoreAPIWeb.Models.Common;

namespace CoreAPIWeb.Models
{
    public  class CoreWebAPIContext
    {
        public  string ConnectionString { get; set; }

        public CoreWebAPIContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        //public List<Country> GetAllCountries()
        //{
        //    List<Country> list = new List<Country>();

        //    using (SqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("usp_List_Country", conn);
        //        SqlParameter par = new SqlParameter();
        //        par.ParameterName = "@p_Culture";
        //        par.Value = "en";
        //        cmd.Parameters.Add(par);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                list.Add(new Country()
        //                {
        //                    CountryId = Convert.ToInt32(reader["CountryId"]),
        //                    CountryName = reader["CountryName"].ToString(),
        //                });
        //            }
        //        }
        //    }
        //    return list;
        //}
    }
}
