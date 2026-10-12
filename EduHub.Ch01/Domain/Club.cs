public class Club
{
    private readonly List<Member> members = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyList<Member> Members => members; 

    private Club(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);
        if (members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException($"{member} đã là thành viên");
        members.Add(member);
    }

    public int MemberCount(){
        return members.Count();
    }
}