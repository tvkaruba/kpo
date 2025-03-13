namespace Rpg.Domain.World;

public class GameWorld
{
    private Dictionary<Position, Location> _locations = new();

    public void AddLocation(Position pos, Location location) => _locations[pos] = location;
    public Location? GetLocation(Position pos) => _locations.GetValueOrDefault(pos);
}
