using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using StationLocationHelper;

namespace StationLocationHelper.Tests
{
    public class LocationHelperTests
    {
        private readonly List<StationLocation> _testStations;

        public LocationHelperTests()
        {
            _testStations = new List<StationLocation>
            {
                new StationLocation("ST001", "Station A", 40.7128, -74.0060), // NYC
                new StationLocation("ST002", "Station B", 38.8977, -77.0365), // DC
                new StationLocation("ST003", "Station C", 42.3656, -71.0619)  // Boston
            };
        }

        [Fact]
        public void CalculateDistance_SamePoint_ReturnsZero()
        {
            // Arrange
            double lat = 40.7128;
            double lon = -74.0060;

            // Act
            double distance = LocationHelper.CalculateDistance(lat, lon, lat, lon);

            // Assert
            Assert.Equal(0, distance, 1); // Within 1 km tolerance
        }

        [Fact]
        public void CalculateDistance_KnownDistances_ReturnsAccurateResult()
        {
            // Arrange - NYC to Washington DC (approximately 328 km)
            double lat1 = 40.7128, lon1 = -74.0060; // NYC
            double lat2 = 38.8977, lon2 = -77.0365; // DC

            // Act
            double distance = LocationHelper.CalculateDistance(lat1, lon1, lat2, lon2);

            // Assert - Should be approximately 328 km
            Assert.True(distance > 320 && distance < 340, $"Expected distance around 330 km, got {distance} km");
        }

        [Fact]
        public void FindClosestStation_ValidInput_ReturnsClosestStation()
        {
            // Arrange - Point closer to NYC than other stations
            double lat = 40.8;
            double lon = -74.1;

            // Act
            var closest = LocationHelper.FindClosestStation(lat, lon, _testStations);

            // Assert
            Assert.Equal("ST001", closest.Id);
            Assert.Equal("Station A", closest.Name);
        }

        [Fact]
        public void FindClosestStation_NullStations_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                LocationHelper.FindClosestStation(40.0, -74.0, null));
        }

        [Fact]
        public void FindClosestStation_EmptyStations_ThrowsArgumentException()
        {
            // Arrange
            var emptyStations = new List<StationLocation>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => 
                LocationHelper.FindClosestStation(40.0, -74.0, emptyStations));
        }

        [Fact]
        public void GetStationsWithinRadius_ValidInput_ReturnsCorrectStations()
        {
            // Arrange - Point near NYC with 500 km radius
            double lat = 40.7;
            double lon = -74.0;
            double radius = 500;

            // Act
            var stationsInRadius = LocationHelper.GetStationsWithinRadius(lat, lon, radius, _testStations);

            // Assert - Should include NYC and DC, but not necessarily Boston (depends on exact distance)
            Assert.True(stationsInRadius.Count >= 2);
            Assert.True(stationsInRadius.Any(s => s.Station.Id == "ST001")); // NYC should be included
            Assert.All(stationsInRadius, item => Assert.True(item.DistanceKm <= radius));
            
            // Verify sorted by distance
            for (int i = 1; i < stationsInRadius.Count; i++)
            {
                Assert.True(stationsInRadius[i - 1].DistanceKm <= stationsInRadius[i].DistanceKm);
            }
        }

        [Fact]
        public void GetStationsWithinRadius_NegativeRadius_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => 
                LocationHelper.GetStationsWithinRadius(40.0, -74.0, -10, _testStations));
        }

        [Fact]
        public void GetStationsWithinRadius_NullStations_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                LocationHelper.GetStationsWithinRadius(40.0, -74.0, 100, null));
        }

        [Fact]
        public void StationLocation_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string id = "TEST01";
            string name = "Test Station";
            double lat = 45.5;
            double lon = -122.6;

            // Act
            var station = new StationLocation(id, name, lat, lon);

            // Assert
            Assert.Equal(id, station.Id);
            Assert.Equal(name, station.Name);
            Assert.Equal(lat, station.Latitude);
            Assert.Equal(lon, station.Longitude);
        }

        [Fact]
        public void StationLocation_ToString_ReturnsExpectedFormat()
        {
            // Arrange
            var station = new StationLocation("ST001", "Test Station", 45.5, -122.6);

            // Act
            string result = station.ToString();

            // Assert
            Assert.Contains("Test Station", result);
            Assert.Contains("ST001", result);
            Assert.Contains("45.5", result);
            Assert.Contains("-122.6", result);
        }
    }
}