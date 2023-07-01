namespace Destinations.Common;

public record DestinationResponse(
Guid Id,
string Name,
string Description,
string Ubication,
bool Active
);