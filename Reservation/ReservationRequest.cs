namespace DependencyRejection.Reservation;

public record ReservationRequest(DateTime Date, string Name, int Quantity);