using Rpg.Domain.AI.Strategies.Abstractions;
using Rpg.Domain.Characters;
using Rpg.Domain.Combat;

namespace Rpg.Domain.AI.Strategies;

public class GoblinAttackStrategy : IEnemyAttackStrategy
{
    public EnemyAttack DetermineAttack(Enemy enemy, Character target)
        => new("Dagger Slash", BaseDamage: 8, AttackType.Melee, Effects: []);
}