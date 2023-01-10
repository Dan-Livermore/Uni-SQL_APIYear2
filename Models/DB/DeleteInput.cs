namespace CW2_TrailService.Models.DB
{
    public class DeleteInput
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Area { get; set; }
        public string Difficulty { get; set; }
        public int NewMarkers { get; set; }
        public float Distance { get; set; }
        public float Elevation { get; set; }
    }
}
