namespace DependencyRejection.Reservation;

public class ReservationsController
{
    private readonly IValidator _validator;
    private readonly IMapper _mapper;
    private readonly IReservationService _reservationService;

    public ReservationsController(IValidator validator, IMapper mapper, IReservationService reservationService)
    {
        _validator = validator;
        _mapper = mapper;
        _reservationService = reservationService;
    }

    public int Post(ReservationRequestDto dto)
    {
        _validator.Validate(dto);
        var request = _mapper.Map(dto);
        if (!_reservationService.TryAccept(request, out var id))
            throw new InvalidOperationException("Not possible");
        return id;

    }
}