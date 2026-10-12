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
    // US-03: Xác nhận phiếu ở trạng thái pendding
    public void Confirm()
    {
        if (Status != RegistrationStatus.Pending)
            throw new InvalidOperationException(
                $"Khong the xac nhan phieu o trang thai {Status}");
        Status = RegistrationStatus.Confirmed;
    }

    // US-01: Pending hoặc Confirmed thì huỷ được, đã huỷ rồi thì báo lỗi
    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException("Phieu da da huy");
        Status = RegistrationStatus.Cancelled;
    }

}