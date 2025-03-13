namespace Rpg.Domain.Characters;

public readonly record struct Stats(
    int Attack,
    int Defense,
    int MaxHealth,
    int Speed);
