using Rpg.App.Services.Abstractions;
using Rpg.Domain.Quests;

namespace Rpg.App.Services;

public class QuestService : IQuestService
{
    private readonly Dictionary<string, QuestProgress> _quests = [];

    public void AddQuest(Quest quest)
    {
        _quests[quest.Id] = new QuestProgress(quest.Id, 0, QuestStatus.NotStarted);
    }

    public void UpdateQuestProgress(string questId, int count)
    {
        if (_quests.TryGetValue(questId, out var progress))
        {
            var newCount = Math.Min(progress.CurrentCount + count, _quests[questId].CurrentCount);
            var newStatus = newCount >= _quests[questId].CurrentCount ? QuestStatus.Completed : QuestStatus.InProgress;

            _quests[questId] = progress with
            {
                CurrentCount = newCount,
                Status = newStatus
            };
        }
    }

    public IReadOnlyCollection<QuestProgress> GetActiveQuests() => _quests.Values;
}
