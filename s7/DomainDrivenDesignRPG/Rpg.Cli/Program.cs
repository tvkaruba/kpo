using Rpg.App;
using Rpg.App.Services;
using Rpg.Domain.Characters;
using Rpg.Domain.Items;

var combatService = new CombatService();
var questService = new QuestService();
var engine = new GameEngine(combatService, questService);

var player = new Character("Hero", new Stats(10, 5, 30, 1));
player.Inventory.AddItem(new Item { Name = "HP", HealAmount = 30});

engine.Initialize(player);
engine.RunGameLoop();