namespace IPSSaludYVida.API
{
    public interface IMasterRepository
    {
        Task<dynamic?> GetAll(TablesEnum table, string? param);
    }
}
