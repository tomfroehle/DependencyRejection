namespace DependencyRejection.Reservation;

public class ReservationService : IReservationService
{
    private readonly int _capacity;
    private readonly IReservationsRepository _reservationsRepository;

    public ReservationService(int capacity, IReservationsRepository reservationsRepository)
    {
        _capacity = capacity;
        _reservationsRepository = reservationsRepository;
    }

    public bool TryAccept(ReservationRequest reservationRequest, out int id)
    {
        var reservedSeats = _reservationsRepository.Read(reservationRequest.Date).Sum(r => r.Quantity);
        if (reservedSeats + reservationRequest.Quantity <= _capacity)
        {
            id = _reservationsRepository.Create(reservationRequest);
            return true;
        }

        id = -1;
        return false;
    }
}