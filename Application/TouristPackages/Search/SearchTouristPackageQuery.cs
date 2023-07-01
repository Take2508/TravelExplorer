using MediatR;
using ErrorOr;
using Application.TouristPackages.Common;

namespace Application.TouristPackages.Search;
public record SearchTouristPackageQuery(
    string Name,
    string Description,
    DateTime? TravelDate,
    decimal? Price,
    string Ubication
) : IRequest<ErrorOr<List<TouristPackageResponse>>>;