namespace Rpg.Domain.Combat;

public readonly record struct AttackResult(
    int Damage,
    bool TargetDead,
    AttackType AttackType,
    List<StatusEffect> Effects);
