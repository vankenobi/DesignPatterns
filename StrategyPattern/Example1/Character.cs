using System;
namespace StrategyPattern
{
    public class Character
    {
        private ICombatStrategy _combatStrategy;

        // We created an empthy ctor becuase sometimes i can set my strategy after create an instance.
        public Character()
        {

        }

        public Character(ICombatStrategy combatStrategy)
        {
            _combatStrategy = combatStrategy;
        }

        public void SetAttackStrategy(ICombatStrategy combatStrategy)
        {
            _combatStrategy = combatStrategy;
            Console.WriteLine($"New combat strategy is set: {_combatStrategy.GetType().Name}");
        }

        public void ApplyAttackStrategy()
        {
            _combatStrategy.Attack();
        }
    }

    public interface ICombatStrategy
    {
        void Attack();
    }

    public class AggresiveCombatStrategy : ICombatStrategy
    {
        public void Attack()
        {
            Console.WriteLine("Aggresive attack applied.");
        }
    }

    public class DefensiveAttackStrategy : ICombatStrategy
    {
        public void Attack()
        {
            Console.WriteLine("Defensive attack applied.");
        }
    }
}

