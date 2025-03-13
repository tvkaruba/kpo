namespace Rpg.Domain.Items;

public readonly record struct Item
{
    public required string Name { get; init; }

    public required int HealAmount { get; init; }
}