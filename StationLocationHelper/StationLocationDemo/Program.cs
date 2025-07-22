using System;
using System.Collections.Generic;
using StationLocationHelper;

namespace StationLocationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Station Location Helper Demo");
            Console.WriteLine("============================");

            // Create sample station locations
            var stations = new List<StationLocation>
            {
                new StationLocation("ST001", "Central Station", 40.7128, -74.0060),      // New York City
                new StationLocation("ST002", "Union Station", 38.8977, -77.0365),       // Washington DC
                new StationLocation("ST003", "North Station", 42.3656, -71.0619),       // Boston
                new StationLocation("ST004", "South Station", 41.8781, -87.6298),       // Chicago
                new StationLocation("ST005", "West Station", 37.7749, -122.4194),       // San Francisco
            };

            // Test coordinates (approximately between NYC and DC)
            double testLat = 39.5;
            double testLon = -75.5;

            Console.WriteLine($"\nFinding closest station to coordinates: {testLat}, {testLon}");
            Console.WriteLine("\nAvailable stations:");
            foreach (var station in stations)
            {
                double distance = LocationHelper.CalculateDistance(testLat, testLon, station.Latitude, station.Longitude);
                Console.WriteLine($"  {station} - Distance: {distance:F2} km");
            }

            // Find the closest station
            var closest = LocationHelper.FindClosestStation(testLat, testLon, stations);
            double closestDistance = LocationHelper.CalculateDistance(testLat, testLon, closest.Latitude, closest.Longitude);

            Console.WriteLine($"\nClosest station: {closest}");
            Console.WriteLine($"Distance: {closestDistance:F2} km");

            // Test stations within radius
            Console.WriteLine($"\nStations within 200 km of {testLat}, {testLon}:");
            var nearby = LocationHelper.GetStationsWithinRadius(testLat, testLon, 200, stations);
            
            if (nearby.Count == 0)
            {
                Console.WriteLine("  No stations found within radius");
            }
            else
            {
                foreach (var (station, distance) in nearby)
                {
                    Console.WriteLine($"  {station} - Distance: {distance:F2} km");
                }
            }

            Console.WriteLine("\nDemo completed successfully!");
        }
    }
}
