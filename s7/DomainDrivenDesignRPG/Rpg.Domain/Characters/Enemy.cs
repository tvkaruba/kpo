using Rpg.Domain.AI.Strategies.Abstractions;
using Rpg.Domain.Combat;

namespace Rpg.Domain.Characters;

public class Enemy : Character
{
    private readonly IEnemyAttackStrategy _attackStrategy;

    public EnemyType Type { get; }

    public Enemy(EnemyType type, Stats stats, IEnemyAttackStrategy strategy)
        : base(type.ToString(), stats)
    {
        _attackStrategy = strategy;
        Type = type;
    }

    public AttackResult ExecuteAttack(Character target)
    {
        var attack = _attackStrategy.DetermineAttack(this, target);
        int damage = CalculateDamage(attack.BaseDamage);
        target.TakeDamage(damage);

        foreach (var effect in attack.Effects)
            target.ApplyStatusEffect(effect);

        return new AttackResult(
            damage,
            !target.IsAlive,
            attack.Type,
            attack.Effects.Where(e => new Random().NextDouble() < 0.5).ToList()
        );
    }

    private int CalculateDamage(int baseDamage)
        => baseDamage * Stats.Attack;
}
