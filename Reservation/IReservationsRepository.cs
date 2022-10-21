namespace DependencyRejection.Reservation;

public interface IReservationsRepository
{
    IEnumerable<Reservation> Read(DateTime datetime);

    int Create(ReservationRequest reservationRequest);
}