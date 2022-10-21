namespace DependencyRejection.Reservation;

public class ReservationsController
{
    private readonly IValidator _validator;
    private readonly IMapper _mapper;
    private readonly IReservationsRepository _reservationsRepository;

    public ReservationsController(IValidator validator, IMapper mapper, IReservationsRepository reservationsRepository)
    {
        _validator = validator;
        _mapper = mapper;
        _reservationsRepository = reservationsRepository;
    }

    public int Post(ReservationRequestDto dto)
    {
        _validator.Validate(dto);
        var request = _mapper.Map(dto);
        var reservations = _reservationsRepository.Read(request.Date);
        if (!ReservationService.CanAccept(10, reservations, request))
            throw new InvalidOperationException("Not possible");
        return _reservationsRepository.Create(request);
    }
}