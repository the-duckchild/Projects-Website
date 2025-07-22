namespace StationLocationHelper
{
    /// <summary>
    /// Represents a station with its geographical location
    /// </summary>
    public class StationLocation
    {
        /// <summary>
        /// Unique identifier for the station
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the station
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Latitude coordinate in decimal degrees
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude coordinate in decimal degrees
        /// </summary>
        public double Longitude { get; set; }

        public StationLocation(string id, string name, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"{Name} ({Id}) - Lat: {Latitude}, Lng: {Longitude}";
        }
    }
}