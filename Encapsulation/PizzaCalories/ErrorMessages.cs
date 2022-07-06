namespace PizzaCalories
{
    public static class ErrorMessages
    {
        public const string NullOrWhitespaceName = "Pizza name should be between 1 and 15 symbols.";
        public const string ToppingInvalidValue = "Number of toppings should be in range [0..10].";
        public const string DoughInavlidValue = "Invalid type of dough.";
        public const string DoughInavlidWeight =  "Dough weight should be in the range[1..200].";
        public const string ToppingInvalidType = "Cannot place {0} on top of your pizza.";
        public const string ToppingInvalidWeight = "{0} weight should be in the range [1..50].";
    }
}
