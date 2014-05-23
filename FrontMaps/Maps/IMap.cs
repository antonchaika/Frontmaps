namespace FrontMaps.Maps
{
    public interface IMap
    {
        double? CenterLatitude { get; set; }
        double? CenterLongitude { get; set; }
        int? ZoomLevel { get; set; }

        void Render();
    }
}
