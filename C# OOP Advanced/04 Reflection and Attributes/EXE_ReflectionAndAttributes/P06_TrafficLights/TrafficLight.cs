public class TrafficLight
{
    private LightColor currentColor;

    public TrafficLight(LightColor colorState)
    {
        this.currentColor = colorState;
    }

    public void ChangeColor()
    {
        this.currentColor++;

        this.currentColor = (int)this.currentColor > 2 ? 0 : this.currentColor;
    }

    public override string ToString()
    {
        return this.currentColor.ToString();
    }
}