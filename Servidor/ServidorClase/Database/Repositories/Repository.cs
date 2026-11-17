using Microsoft.EntityFrameworkCore;

namespace ServidorClase.Database.Repositories;

public abstract class Repository<TEntity, TId> where TEntity : class
{
    protected MyDataBase Context { get; private set; }

    public Repository(MyDataBase context)
    {
        Context = context;
    }

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().ToArrayAsync();
    }
}
