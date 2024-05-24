namespace TeamHost.Application.Contracts.Games.GetAllGames;

/// <summary>
/// Ответ на запрос всех игр
/// </summary>
public class GetAllGamesResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="allGames">Сущности</param>
    /// <param name="totalCount">Общее кол-во</param>
    public GetAllGamesResponse(List<GetAllGamesResponseItem> allGames, int totalCount)
    {
        AllGames = allGames;
        TotalCount = totalCount;
    }
    
    /// <summary>
    /// Список
    /// </summary>
    public List<GetAllGamesResponseItem> AllGames { get; }

    /// <summary>
    /// Общее кол-во
    /// </summary>
    public int TotalCount { get; set; }
}