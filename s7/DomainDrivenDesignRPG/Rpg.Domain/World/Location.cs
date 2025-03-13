using Rpg.Domain.Characters;
using Rpg.Domain.Items;

namespace Rpg.Domain.World;

public class Location
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public List<EnemyType> PossibleEnemies { get; } = [];

    public List<Item> AvailableItems { get; } = [];
}
