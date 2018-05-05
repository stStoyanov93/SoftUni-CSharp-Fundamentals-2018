namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Satchel : Bag
    {
        private const int SATCHEL_DEFAULT_CAPACITY = 20;

        public Satchel()
            :base(SATCHEL_DEFAULT_CAPACITY) { }
    }
}
