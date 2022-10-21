namespace DependencyRejection.Reservation;

public interface IReservationService
{
    bool TryAccept(ReservationRequest reservationRequest, out int id);
}