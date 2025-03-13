using Rpg.Domain.Combat;
using Rpg.Domain.Items;

namespace Rpg.Domain.Characters;

public class Character
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Name { get; }

    public Stats Stats { get; }

    public int Health { get; private set; }

    public bool IsAlive => Health > 0;

    public Inventory Inventory { get; } = new(10);

    private List<StatusEffect> _activeEffects = [];

    public Character(string name, Stats stats)
    {
        Name = name;
        Stats = stats;
        Health = stats.MaxHealth;
    }

    public void TakeDamage(int damage)
        => Health = Math.Max(Health - damage, 0);

    public void ApplyItemEffect(Item item)
    {
        Health = Math.Min(Health + item.HealAmount, Stats.MaxHealth);
        Console.WriteLine($"Healed {item.HealAmount} HP");
    }

    public void ApplyStatusEffect(StatusEffect effect)
    {
        var existing = _activeEffects.FirstOrDefault(se => se.Type == effect.Type);
        if (existing != null) existing.RemainingDuration = effect.RemainingDuration;
        else _activeEffects.Add(effect);
    }

    public void UpdateStatusEffects()
    {
        foreach (var effect in _activeEffects.ToList())
        {
            effect.RemainingDuration--;
            if (effect.RemainingDuration <= 0) _activeEffects.Remove(effect);
        }
    }
}
