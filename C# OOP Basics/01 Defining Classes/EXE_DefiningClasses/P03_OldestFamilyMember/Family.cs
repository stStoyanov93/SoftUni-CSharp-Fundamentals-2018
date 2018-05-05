using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> familyMembers;

    public Family()
    {
        familyMembers = new List<Person>();
    }

    public void AddMember(Person member)
    {
        familyMembers.Add(member);
    }

    public Person GetOldestMember()
    {
        return familyMembers.OrderByDescending(x => x.Age).First();
    }
}

