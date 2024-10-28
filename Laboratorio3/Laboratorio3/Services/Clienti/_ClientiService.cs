namespace Laboratorio3.Services.Clienti
{
    public partial class ClientiService
    {
        ClientiDbContext _dbContext;

        public ClientiService(ClientiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
