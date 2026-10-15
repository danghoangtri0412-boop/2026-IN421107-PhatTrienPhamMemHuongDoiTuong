public class CheckIn
{
    public Guid Id {get; private set;}
    public Guid RegistrationId {get; private set;}
    public DateTime CheckedInAt {get; private set;}
    public string Method { get; private set; }

    private CheckIn(Guid registrationId, string method)
    {
        Id = Guid.NewGuid();
        RegistrationId = registrationId;
        CheckedInAt = DateTime.UtcNow;
        Method = method;
    }

    public static CheckIn Create(Registration registration, string method)
    {
        ArgumentNullException.ThrowIfNull(registration);
        if (registration.Status != RegistrationStatus.Confirmed)
            throw new InvalidOperationException("Chỉ phiếu Confirmed mới check-in");
        return new CheckIn(registration.Id, method);
    }

    public string Summary()
    {
        return $"Check-in lúc {CheckedInAt.ToLocalTime():HH:mm dd/MM/yyyy} qua {Method}";
    }
}