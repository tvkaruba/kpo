namespace Rpg.Domain.Quests;

public record Quest(
    string Id,
    string Title,
    string Description,
    int Target);

public record QuestProgress(
    string QuestId,
    int CurrentCount,
    QuestStatus Status);
