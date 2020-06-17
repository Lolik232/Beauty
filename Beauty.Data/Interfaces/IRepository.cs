using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    /// <typeparam name="TModel">Модель данных</typeparam>
    public interface IRepository<TModel> where TModel : class
    {
        /// <summary>
        /// Добавляет модель данных в базу данных
        /// </summary>
        /// <param name="modelId">Идентификатор модели данных, которую необходимо добавить в базу данных</param>
        TModel Add(TModel model);

        /// <summary>
        /// Добавляет список моделей данных в базу данных
        /// </summary>
        /// <param name="modelIds">Идентификаторы моделей данных, которые необходимо добавить в базу данных</param>
        IEnumerable<TModel> AddRange(IEnumerable<TModel> models);

        /// <summary>
        /// Возвращает первую запись модели данных в базе данных
        /// </summary>
        Task<TModel> FirstAsync();

        /// <summary>
        /// Возвращает последнюю запись модели данных в базе данных
        /// </summary>
        TModel Last();

        /// <summary>
        /// Возвращает модель данных из базы данных
        /// </summary>
        /// <param name="modelId">Идентификатор модели данных, которую необходимо вернуть</param>
        Task<TModel> FindAsync(int modelId);

        /// <summary>
        /// Возвращает все модели данных из базы данных
        /// </summary>
        Task<IEnumerable<TModel>> FindAllAsync();

        /// <summary>
        /// Удаляет модель данных из базы данных
        /// </summary>
        /// <param name="modelId">Идентификатор модели данных, которую необходимо удалить</param>
        Task RemoveAsync(int modelId);

        /// <summary>
        /// Удаляет список моделей данных из базы данных
        /// </summary>
        /// <param name="modelIds">Идентификаторы моделей данных, которые необходимо удалить</param>
        Task RemoveRangeAsync(IEnumerable<int> modelIds);

        /// <summary>
        /// Удаляет список моделей данных из базы данных
        /// </summary>
        /// <param name="modelIds">Модели данных, которые необходимо удалить</param>
        void RemoveRange(IEnumerable<TModel> models);
    }
}
