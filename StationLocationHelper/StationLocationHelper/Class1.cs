using System;
using System.Collections.Generic;
using System.Linq;

namespace StationLocationHelper
{
    /// <summary>
    /// Helper class for calculating distances and finding the closest station to a given location
    /// </summary>
    public static class LocationHelper
    {
        /// <summary>
        /// Earth's radius in kilometers
        /// </summary>
        private const double EarthRadiusKm = 6371.0;

        /// <summary>
        /// Finds the closest station to the given latitude and longitude coordinates
        /// </summary>
        /// <param name="latitude">Target latitude in decimal degrees</param>
        /// <param name="longitude">Target longitude in decimal degrees</param>
        /// <param name="stations">Collection of station locations to search through</param>
        /// <returns>The closest station location</returns>
        /// <exception cref="ArgumentNullException">Thrown when stations collection is null</exception>
        /// <exception cref="ArgumentException">Thrown when stations collection is empty</exception>
        public static StationLocation FindClosestStation(double latitude, double longitude, IEnumerable<StationLocation> stations)
        {
            if (stations == null)
                throw new ArgumentNullException(nameof(stations), "Stations collection cannot be null");

            var stationList = stations.ToList();
            if (stationList.Count == 0)
                throw new ArgumentException("Stations collection cannot be empty", nameof(stations));

            StationLocation? closestStation = null;
            double minDistance = double.MaxValue;

            foreach (var station in stationList)
            {
                double distance = CalculateDistance(latitude, longitude, station.Latitude, station.Longitude);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestStation = station;
                }
            }

            // closestStation will never be null here since we've validated the list is not empty
            return closestStation!;
        }

        /// <summary>
        /// Calculates the great-circle distance between two points on Earth using the Haversine formula
        /// </summary>
        /// <param name="lat1">Latitude of the first point in decimal degrees</param>
        /// <param name="lon1">Longitude of the first point in decimal degrees</param>
        /// <param name="lat2">Latitude of the second point in decimal degrees</param>
        /// <param name="lon2">Longitude of the second point in decimal degrees</param>
        /// <returns>Distance in kilometers</returns>
        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Convert degrees to radians
            double lat1Rad = ToRadians(lat1);
            double lon1Rad = ToRadians(lon1);
            double lat2Rad = ToRadians(lat2);
            double lon2Rad = ToRadians(lon2);

            // Differences
            double deltaLat = lat2Rad - lat1Rad;
            double deltaLon = lon2Rad - lon1Rad;

            // Haversine formula
            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                      Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                      Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c;
        }

        /// <summary>
        /// Gets all stations within a specified radius from the given coordinates, sorted by distance
        /// </summary>
        /// <param name="latitude">Target latitude in decimal degrees</param>
        /// <param name="longitude">Target longitude in decimal degrees</param>
        /// <param name="radiusKm">Maximum distance in kilometers</param>
        /// <param name="stations">Collection of station locations to search through</param>
        /// <returns>List of stations within the radius, sorted by distance (closest first)</returns>
        public static List<(StationLocation Station, double DistanceKm)> GetStationsWithinRadius(
            double latitude, double longitude, double radiusKm, IEnumerable<StationLocation> stations)
        {
            if (stations == null)
                throw new ArgumentNullException(nameof(stations), "Stations collection cannot be null");

            if (radiusKm < 0)
                throw new ArgumentException("Radius must be non-negative", nameof(radiusKm));

            var result = new List<(StationLocation Station, double DistanceKm)>();

            foreach (var station in stations)
            {
                double distance = CalculateDistance(latitude, longitude, station.Latitude, station.Longitude);
                if (distance <= radiusKm)
                {
                    result.Add((station, distance));
                }
            }

            // Sort by distance
            result.Sort((a, b) => a.DistanceKm.CompareTo(b.DistanceKm));

            return result;
        }

        /// <summary>
        /// Converts degrees to radians
        /// </summary>
        /// <param name="degrees">Angle in degrees</param>
        /// <returns>Angle in radians</returns>
        private static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
