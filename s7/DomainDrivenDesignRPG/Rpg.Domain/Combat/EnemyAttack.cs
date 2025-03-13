namespace Rpg.Domain.Combat;

public record EnemyAttack(
    string Name,
    int BaseDamage,
    AttackType Type,
    List<StatusEffect> Effects);
