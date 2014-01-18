namespace WebApiSample.Models
{
    public class MonkeyFactory
    {
        public static Monkey Create()
        {
            return new Monkey
            {
                Id = 42,
                Name = "Bonzo",
                Banana = new Banana
                {
                    Color = "Yellow",
                    Weight = 126m,
                    Calories =100m
                }
            };
        }
    }
}