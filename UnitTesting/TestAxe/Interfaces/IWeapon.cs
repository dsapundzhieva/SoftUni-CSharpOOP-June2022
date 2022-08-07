namespace TestAxe.Interfaces
{
    public interface IWeapon
    {
        public int AttackPoints { get; }

        public int DurabilityPoints { get; }

        public void Attack(ITarget target);
    }
}
