namespace HeroesIIII.Models
{
    public abstract class GameEntity : GameObject
    {
        private int _currentHealth;

        public int Damage { get; set; }
        public int Defense { get; set; }
        public int Agility { get; set; }
        public int Vitality { get; set; }
        public int MaximumHealth { get; set; }
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value > MaximumHealth ? MaximumHealth : value;
        }
        protected int _level;
        public abstract int Level { get; set; }

        public virtual int Attack(GameEntity target)
        {
            var damage = Damage - (target.Defense / 4);
            if (damage < 0)
                damage = 0;
            target.CurrentHealth -= damage;
            return damage;
        }
    }
}
