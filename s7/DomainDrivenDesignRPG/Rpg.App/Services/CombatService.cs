using Rpg.App.Services.Abstractions;
using Rpg.Domain.Characters;

namespace Rpg.App.Services;

public class CombatService : ICombatService
{
    private Character _player;

    private Enemy _enemy;

    public void StartCombat(Character player, Enemy enemy)
    {
        _player = player;
        _enemy = enemy;
    }

    public void PlayerAttack()
    {
        var damage = Math.Max(_player.Stats.Attack - _enemy.Stats.Defense, 0);
        _enemy.TakeDamage(damage);
    }

    public void EnemyTurn()
    {
        var damage = Math.Max(_enemy.Stats.Attack - _player.Stats.Defense, 0);
        _player.TakeDamage(damage);
    }

    public bool PlayerUseItem(string itemName)
    {
        if (!_player.Inventory.HasItem(itemName))
            return false;

        var item = _player.Inventory.PeekItem(itemName);

        _player.ApplyItemEffect(item);
        _ = _player.Inventory.RemoveItem(item);
        return true;
    }

    public bool IsCombatActive() => _player.IsAlive && _enemy.IsAlive;
}
