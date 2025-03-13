using Rpg.App.Services.Abstractions;
using Rpg.Domain.AI.Strategies;
using Rpg.Domain.Characters;
using Rpg.Domain.Quests;
using Rpg.Domain.World;

namespace Rpg.App;

public sealed class GameEngine
{
    private readonly ICombatService _combatService;

    private readonly IQuestService _questService;

    private GameState _currentState;

    private Character? _player;

    private Position _playerPosition;

    public GameEngine(ICombatService combatService, IQuestService questService)
    {
        ArgumentNullException.ThrowIfNull(combatService);
        ArgumentNullException.ThrowIfNull(questService);

        _combatService = combatService;
        _questService = questService;

        _currentState = GameState.Undefined;
        _player = null;
        _playerPosition = new(0, 0);
    }

    public void Initialize(Character player)
    {
        _player = player;
        _currentState = GameState.Exploring;

        _questService.AddQuest(new Quest("q1", "Goblin Hunter", "Defeat 3 goblins", Target: 3));
    }

    public void RunGameLoop()
    {
        while (_player!.IsAlive)
        {
            switch (_currentState)
            {
                case GameState.Exploring:
                    HandleExploration();
                    break;
                case GameState.Combat:
                    HandleCombat();
                    break;
                case GameState.Menu:
                    HandleMenu();
                    break;
            }
        }

        Console.WriteLine("Game Over!");
    }

    private void HandleExploration()
    {
        Console.WriteLine("\nYou're exploring...");
        Console.WriteLine("1. Move  2. Inventory  3. Quests  4. Menu");

        switch (Console.ReadKey().KeyChar)
        {
            case '1':
                MovePlayer();
                CheckForRandomEncounter();
                break;
            case '2':
                ShowInventory();
                break;
            case '3':
                ShowQuests();
                break;
            case '4':
                _currentState = GameState.Menu;
                break;
        }
    }

    private void HandleCombat()
    {
        Console.WriteLine("\nCombat!");
        Console.WriteLine("1. Attack  2. Use Item  3. Flee");

        switch (Console.ReadKey().KeyChar)
        {
            case '1':
                _combatService.PlayerAttack();
                break;
            case '2':
                UseItemInCombat();
                break;
            case '3':
                _currentState = GameState.Exploring;
                return;
        }

        if (_combatService.IsCombatActive())
        {
            _combatService.EnemyTurn();
        }
        else
        {
            _currentState = GameState.Exploring;
            _questService.UpdateQuestProgress("q1", 1);
        }
    }

    private void HandleMenu()
    {
        Console.WriteLine("\nGame Paused");
        Console.WriteLine("1. Resume 2. Quit");

        switch (Console.ReadKey().KeyChar)
        {
            case '1':
                _currentState = GameState.Exploring;
                break;
            case '2':
                Environment.Exit(0);
                return;
        }
    }

    private void MovePlayer()
        => _playerPosition = new(_playerPosition.X + new Random().Next(0, 2), _playerPosition.Y + new Random().Next(0, 2));

    private void CheckForRandomEncounter()
    {
        if (new Random().NextDouble() < 0.1)
        {
            var enemy = new Enemy(EnemyType.Goblin, new Stats(5, 2, 15, 1), new GoblinAttackStrategy());
            _currentState = GameState.Combat;
            _combatService.StartCombat(_player!, enemy);
        }
    }

    private void ShowInventory()
        => Console.WriteLine(_player!.Inventory);

    private void ShowQuests()
        => Console.WriteLine(string.Join("\n", _questService.GetActiveQuests()));

    private void UseItemInCombat()
    {
        Console.WriteLine("\nAvailable Items:");
        Console.WriteLine(_player!.Inventory);

        Console.Write("Select item: ");
        var choise = Console.ReadLine();

        if (string.IsNullOrEmpty(choise) || !_player!.Inventory.HasItem(choise))
        {
            Console.WriteLine("Invalid selection!");
            return;
        }

        _combatService.PlayerUseItem(choise);

        Console.WriteLine($"Used {choise}!");
        Console.WriteLine($"Current HP: {_player.Health}/{_player.Stats.MaxHealth}");
    }
}
