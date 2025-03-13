using Rpg.Domain.Characters;
using Rpg.Domain.Combat;

namespace Rpg.Domain.AI.Strategies.Abstractions;

public interface IEnemyAttackStrategy
{
    EnemyAttack DetermineAttack(Enemy enemy, Character target);
}
