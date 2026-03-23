namespace Business;

/// <summary>
/// Задаёт соблюдение контракта для наследника
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Идентификатор для наследника
    /// </summary>
    public Guid Id { get; }
}