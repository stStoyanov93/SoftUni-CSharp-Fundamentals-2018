using System;

public class DateModifier
{
    public int DifferenceInDays { get; private set; }

    public void CalculateDiff(string date1AsString, string date2AsString)
    {
        var date1 = DateTime.Parse(date1AsString);
        var date2 = DateTime.Parse(date2AsString);

        this.DifferenceInDays = Math.Abs(date1.Subtract(date2).Days);
    }
}

