using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static CoreAPIWeb.Models.Common;

namespace CoreAPIWeb.Models
{
    public class CommonRepository : ICommonRepository
    {
        private CoreWebAPIContext _DbContext;
        public CommonRepository(CoreWebAPIContext OneContext)
        {
            _DbContext = OneContext;
        }
        public List<Country> GetAllCountries()
        {
            List<Country> list = new List<Country>();

            using (SqlConnection conn = _DbContext.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_List_Country", conn);
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@p_Culture";
                par.Value = "en";
                cmd.Parameters.Add(par);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Country()
                        {
                            CountryId = Convert.ToInt32(reader["CountryId"]),
                            CountryName = reader["CountryName"].ToString(),
                        });
                    }
                }
            }
            return list;
        }
    }


}
