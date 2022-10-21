namespace DependencyRejection.Reservation;

public class ReservationsController
{
    private readonly IReservationsRepository _reservationsRepository;

    public ReservationsController(IReservationsRepository reservationsRepository)
    {
        _reservationsRepository = reservationsRepository;
    }

    public int Post(ReservationRequest request)
    {
        var reservations = _reservationsRepository.Read(request.Date);
        if (!ReservationService.CanAccept(10, reservations, request))
            throw new InvalidOperationException("Not possible");
        return _reservationsRepository.Create(request);
    }
}