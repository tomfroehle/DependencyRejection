namespace DependencyRejection.Reservation;

public static class ReservationService 
{
    public static bool CanAccept(int capacity, IEnumerable<Reservation> reservations, ReservationRequest reservationRequest)
    {
        var reservedSeats = reservations.Sum(r => r.Quantity);
        return reservedSeats + reservationRequest.Quantity <= capacity;
    }
}