public class Member
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string StudentCode { get; private set; }
    public DateTime JoinedAt { get; private set; }
    public MemberStatus Status { get; private set; }

    private Member(string name, string email, string studentCode)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = DateTime.UtcNow;
        Status = MemberStatus.Active;
    }

    public static Member Create(string name, string email, string studentcode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AggregateException("Ten khong duoc de trong");
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.EndsWith("gmail.com"))
            throw new AggregateException("Email khong duoc de trong hoac sai dinh dang");
        if (string.IsNullOrWhiteSpace(studentcode))
            throw new AggregateException("Ma sinh vien khong duoc de trong");
        return new Member(name.Trim(), email.Trim().ToLowerInvariant(), studentcode.Trim());    
    }
    public bool IsActive(){
        return Status == MemberStatus.Active;
    }
    public bool Deactivate(){
        return Status == MemberStatus.Inactive;
    }
    public override string ToString()
    {
      return $"{Name} ({StudentCode})";  
    } 
}