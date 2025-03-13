namespace Rpg.Domain.Combat;

public class StatusEffect
{
    public required StatusEffectType Type { get; init; }

    public required int RemainingDuration { get; set; }
}
