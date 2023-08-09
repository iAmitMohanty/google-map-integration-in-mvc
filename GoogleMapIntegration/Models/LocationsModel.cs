using System.ComponentModel.DataAnnotations;

namespace GoogleMapIntegration.Models
{
    public class LocationsModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Please enter city latitude")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Please enter city longitude ")]
        public string Longitude { get; set; }
        public string Description { get; set; }
    }
}