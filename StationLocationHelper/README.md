# Station Location Helper

A C# helper library for calculating distances and finding the closest station to a given latitude and longitude coordinates.

## Features

- **Distance Calculation**: Uses the Haversine formula to calculate accurate great-circle distances between two points on Earth
- **Closest Station Finding**: Efficiently finds the station closest to given coordinates
- **Radius-based Search**: Gets all stations within a specified radius, sorted by distance
- **Comprehensive Error Handling**: Proper validation and meaningful exceptions

## Classes

### StationLocation

Represents a station with its geographical location.

**Properties:**
- `Id` (string): Unique identifier for the station
- `Name` (string): Name of the station  
- `Latitude` (double): Latitude coordinate in decimal degrees
- `Longitude` (double): Longitude coordinate in decimal degrees

### LocationHelper

Static helper class providing distance calculation and station finding functionality.

**Methods:**

#### FindClosestStation
```csharp
public static StationLocation FindClosestStation(double latitude, double longitude, IEnumerable<StationLocation> stations)
```
Finds the closest station to the given coordinates.

**Parameters:**
- `latitude`: Target latitude in decimal degrees
- `longitude`: Target longitude in decimal degrees  
- `stations`: Collection of station locations to search

**Returns:** The closest StationLocation

**Throws:**
- `ArgumentNullException`: When stations collection is null
- `ArgumentException`: When stations collection is empty

#### CalculateDistance
```csharp
public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
```
Calculates the great-circle distance between two points using the Haversine formula.

**Parameters:**
- `lat1`, `lon1`: First point coordinates in decimal degrees
- `lat2`, `lon2`: Second point coordinates in decimal degrees

**Returns:** Distance in kilometers

#### GetStationsWithinRadius
```csharp
public static List<(StationLocation Station, double DistanceKm)> GetStationsWithinRadius(double latitude, double longitude, double radiusKm, IEnumerable<StationLocation> stations)
```
Gets all stations within a specified radius, sorted by distance.

**Parameters:**
- `latitude`: Target latitude in decimal degrees
- `longitude`: Target longitude in decimal degrees
- `radiusKm`: Maximum distance in kilometers  
- `stations`: Collection of station locations to search

**Returns:** List of stations within radius with their distances, sorted by distance (closest first)

**Throws:**
- `ArgumentNullException`: When stations collection is null
- `ArgumentException`: When radius is negative

## Usage Example

```csharp
using StationLocationHelper;

// Create station locations
var stations = new List<StationLocation>
{
    new StationLocation("ST001", "Central Station", 40.7128, -74.0060),  // NYC
    new StationLocation("ST002", "Union Station", 38.8977, -77.0365),    // DC
    new StationLocation("ST003", "North Station", 42.3656, -71.0619)     // Boston
};

// Find closest station to coordinates
double targetLat = 39.5;
double targetLon = -75.5;

var closest = LocationHelper.FindClosestStation(targetLat, targetLon, stations);
Console.WriteLine($"Closest station: {closest}");

// Calculate distance to a specific station
double distance = LocationHelper.CalculateDistance(targetLat, targetLon, closest.Latitude, closest.Longitude);
Console.WriteLine($"Distance: {distance:F2} km");

// Find stations within 200km radius
var nearby = LocationHelper.GetStationsWithinRadius(targetLat, targetLon, 200, stations);
foreach (var (station, dist) in nearby)
{
    Console.WriteLine($"{station.Name}: {dist:F2} km");
}
```

## Building and Testing

Build the library:
```bash
cd StationLocationHelper
dotnet build
```

Run tests:
```bash
cd StationLocationHelper.Tests
dotnet test
```

Run demo:
```bash
cd StationLocationDemo
dotnet run
```

## Algorithm Details

The library uses the **Haversine formula** to calculate distances, which gives the great-circle distance between two points on a sphere given their latitude and longitude. This is more accurate than simple Euclidean distance for geographical coordinates.

The formula accounts for the Earth's curvature and provides distances accurate to within a few meters for most practical purposes.

## License

This project is part of the Projects-Website repository.