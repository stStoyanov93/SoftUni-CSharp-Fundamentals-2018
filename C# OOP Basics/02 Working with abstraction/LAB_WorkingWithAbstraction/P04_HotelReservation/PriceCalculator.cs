using System;

public class PriceCalculator
{
    private decimal pricePerDay;
    private int numberOfDays;
    private Season season;
    private Discount discountType;
    private decimal totalPrice;

    public void CalculatePrice(string input)
    {
        var inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        this.pricePerDay = decimal.Parse(inputParams[0]);
        this.numberOfDays = int.Parse(inputParams[1]);
        this.season = Enum.Parse<Season>(inputParams[2]);
        this.discountType = Discount.None;

        if (inputParams.Length == 4)
        {
            discountType = Enum.Parse<Discount>(inputParams[3]);
        }

        var discount = (pricePerDay * numberOfDays * (int)season * (decimal)discountType) / 100m;
        this.totalPrice = (pricePerDay * (int)season * numberOfDays) - discount;      
    }

    public void PrintPrice()
    {
        Console.WriteLine($"{this.totalPrice:F2}");
    }
}