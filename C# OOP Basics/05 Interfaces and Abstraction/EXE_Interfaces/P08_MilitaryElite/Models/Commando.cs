using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private readonly List<IMission> missions;

    public Commando(int id, string firstName, string lastName, double salary, string corps, IList<IMission> missions)
        : base(id, firstName, lastName, salary, corps)
    {
        this.missions = (List<IMission>)missions;
    }

    public IList<IMission> Missions => this.missions.AsReadOnly();

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine(base.ToString());
        builder.AppendLine("Missions:");

        foreach (var mision in Missions)
        {
            builder.AppendLine($"  {mision}");
        }

        return builder.ToString().Trim();
    }
}