using Microsoft.EntityFrameworkCore;
using ServidorClase.Database.Entities;

namespace ServidorClase.Database.Repositories;

public class UserRepository : Repository<User, int>
{
    public UserRepository(MyDataBase context) : base(context)
    {
    }

    public async Task<User?> GetUserByNameAsync(string name)
    {
        string lowerName = name.ToLower();

        return await GetQueryable()
            .Where(user => user.Name.ToLower().Contains(name))
            .FirstOrDefaultAsync();
    }
}
