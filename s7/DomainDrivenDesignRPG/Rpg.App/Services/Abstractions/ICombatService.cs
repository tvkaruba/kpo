using Rpg.Domain.Characters;

namespace Rpg.App.Services.Abstractions;

public interface ICombatService
{
    void StartCombat(Character player, Enemy enemy);

    void PlayerAttack();

    bool PlayerUseItem(string itemId);

    void EnemyTurn();

    bool IsCombatActive();
}