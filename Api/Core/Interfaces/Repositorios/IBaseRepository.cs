namespace Core.Interfaces.Repositorios;
    public interface IBaseRepository<TEntity> where TEntity : class {
        ValueTask<TEntity> GetByIdAsync(int id);
        ValueTask<TEntity> GetByNombreAsync(string nombre);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Remove(TEntity entidad);
        void RemoveRange(IEnumerable<TEntity> entidades);
        Task Update(TEntity entidad);
        Task AddAsync(TEntity entidad);

    }

