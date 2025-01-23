using S2.HseCarShop.Models.Abstractions;

namespace S2.HseCarShop.Models;

/// <summary>
/// Автомобиль
/// </summary>
public class Car
{
    /// <summary>
    /// Номер автомобиля
    /// </summary>
    public Guid Number { get; }

    /// <summary>
    /// Двигатель автомобиля
    /// </summary>
    public IEngine Engine { get; }

    public Car(IEngine engine, Guid number)
    {
        ArgumentNullException.ThrowIfNull(engine, nameof(engine));

        Engine = engine;
        Number = number;
    }

    public override string ToString()
        => $"Номер: {Number}, Двигатель: {{ {Engine} }}";
}
