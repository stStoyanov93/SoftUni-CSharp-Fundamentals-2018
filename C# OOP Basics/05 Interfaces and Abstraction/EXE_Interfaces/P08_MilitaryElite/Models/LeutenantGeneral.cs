using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private readonly List<IPrivate> privates;

    public LeutenantGeneral(int id, string firstName, string lastName, double salary, IList<IPrivate> privates)
        : base(id, firstName, lastName, salary)
    {
        this.privates = (List<IPrivate>)privates;
    }

    public IList<IPrivate> Privates => this.privates.AsReadOnly();

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine(base.ToString());
        builder.AppendLine("Privates:");

        foreach (var soldier in this.Privates)
        {
            builder.AppendLine($"  {soldier.ToString()}");
        }

        return builder.ToString().Trim();
    }
}