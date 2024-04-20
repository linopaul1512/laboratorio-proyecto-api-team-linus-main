namespace Core.Interfaces.Repositorios;
    public interface IBaseRepository<TEntity> where TEntity : class {
        ValueTask<TEntity> GetByIdAsync(int id);
        ValueTask<TEntity> GetByNombreAsync(string nombre);
        ValueTask<TEntity> GetByPorcentajeAsync(double tasa);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Remove(TEntity entidad);
        void RemoveRange(IEnumerable<TEntity> entidades);
        Task Update(TEntity entidad);
        Task AddAsync(TEntity entidad);

    }

