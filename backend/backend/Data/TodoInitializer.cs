using System;
using System.Threading.Tasks;

namespace backend.Data
{
    public class TodoInitializer
    {
        private readonly TodoContext _dbContext;


        public TodoInitializer(TodoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                _dbContext.SaveChanges();
            }
        }
    }
}
