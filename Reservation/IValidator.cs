namespace DependencyRejection.Reservation;

public interface IValidator
{
    void Validate(ReservationRequestDto dto);
}