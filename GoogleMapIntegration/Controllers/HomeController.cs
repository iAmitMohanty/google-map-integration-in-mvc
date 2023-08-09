using GoogleMapIntegration.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace GoogleMapIntegration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Location()
        {
            string markers = "[";
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetMap", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    markers += "{";
                    markers += string.Format("'title': '{0}',", sqlDataReader["CityName"]);
                    markers += string.Format("'lat': '{0}',", sqlDataReader["Latitude"]);
                    markers += string.Format("'lng': '{0}',", sqlDataReader["Longitude"]);
                    markers += string.Format("'description': '{0}'", sqlDataReader["Description"]);
                    markers += "},";
                }
            }
            markers += "];";
            ViewBag.Markers = markers;
            return View();
        }

        [HttpPost]
        public ActionResult Location(LocationsModel locationModel)
        {
            if (ModelState.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddNewLocation", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@CityName", locationModel.CityName);
                    sqlCommand.Parameters.AddWithValue("@Latitude", locationModel.Latitude);
                    sqlCommand.Parameters.AddWithValue("@Longitude", locationModel.Longitude);
                    sqlCommand.Parameters.AddWithValue("@Description", locationModel.Description);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            return RedirectToAction("Location");
        }

        public ActionResult LocationByAddress()
        {
            return View();
        }
    }
}