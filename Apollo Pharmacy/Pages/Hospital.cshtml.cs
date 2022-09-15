using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Apollo_Pharmacy.Pages;
using System.Data.SqlClient;

namespace Apollo_Pharmacy.Pages
{
    public class HospitalModel : PageModel
    {
        public List<HospitalInfo> hospitalList = new List<HospitalInfo>();
        public void OnGet()
        {

            String connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=apollo;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Hospital";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HospitalInfo hospitalInfo = new HospitalInfo();
                                hospitalInfo.hid = reader.GetString(0);
                                hospitalInfo.hname = reader.GetString(1);
                                hospitalInfo.hcity = reader.GetString(2);

                                hospitalList.Add(hospitalInfo);

                            }
                        }
                    }

                }
            
            }
            catch (Exception)
            {
                return;
            }


        }
        public void OnPost()
        {

        }
    }
    public class HospitalInfo
    {
        public string hid;
        public string hname;
        public string hcity;
    }
}


