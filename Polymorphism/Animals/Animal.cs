namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favoriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favoriteFood;
        }
        public string Name { get; set; }

        public string FavouriteFood { get; set; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
