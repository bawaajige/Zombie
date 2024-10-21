namespace Zombie.Models;

public class GameData
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Количество убийств
    /// </summary>
    public int KillCount { get; init; }

    /// <summary>
    /// Количество здоровья
    /// </summary>
    public float PlayerHealth { get; init; }
    
    /// <summary>
    /// Id игрока
    /// </summary>
    public int PlayerId { get; init; }
}