public class Registration
{
    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public RegistrationStatus Status { get; private set; }

    private Registration(Guid memberId, Guid eventId)
    {
        Id = Guid.NewGuid();
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = DateTime.UtcNow;
        Status = RegistrationStatus.Pending;
    }

    public static Registration Create(Member member, Event ev, int registeredCount)
    {
        ArgumentNullException.ThrowIfNull(member);
        ArgumentNullException.ThrowIfNull(ev);
        if (!member.IsActive())
            throw new InvalidOperationException("Thanh vien da ngung hoat dong");
        if (!ev.HasCapacity(registeredCount))
            throw new InvalidOperationException("Su kien da het cho");
        return new Registration(member.Id, ev.Id);
    }

}