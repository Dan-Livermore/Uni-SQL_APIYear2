using System.ComponentModel.DataAnnotations;

namespace CW2_TrailService.Models.DB
{
    public class UpdateInput
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Area { get; set; }
        public string Difficulty { get; set; }
        public int NewMarkers { get; set; }
        public float Distance { get; set; }
        public float Elevation { get; set; }
    }
}

