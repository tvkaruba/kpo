using Rpg.Domain.Characters;

namespace Rpg.Persistence.Repositories.Abstractions;

public interface IEnemyRepository
{
    Enemy GetEnemy(EnemyType type);
}