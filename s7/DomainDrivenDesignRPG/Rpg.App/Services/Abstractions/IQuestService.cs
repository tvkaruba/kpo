using Rpg.Domain.Quests;

namespace Rpg.App.Services.Abstractions;

public interface IQuestService
{
    void AddQuest(Quest quest);

    void UpdateQuestProgress(string questId, int amount);

    IReadOnlyCollection<QuestProgress> GetActiveQuests();
}
