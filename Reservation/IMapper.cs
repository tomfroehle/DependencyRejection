namespace DependencyRejection.Reservation;

public interface IMapper
{
    ReservationRequest Map(ReservationRequestDto dto);
}