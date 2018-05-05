using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private readonly List<IRepair> repairs;

    public Engineer(int id, string firstName, string lastName, double salary, string corps, IList<IRepair> repairs)
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = (List<IRepair>)repairs;
    }

    public IList<IRepair> Repairs => this.repairs.AsReadOnly();

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine(base.ToString());
        builder.AppendLine("Repairs:");

        foreach (var repair in Repairs)
        {
            builder.AppendLine($"  {repair.ToString()}");
        }

        return builder.ToString().Trim();
    }
}
