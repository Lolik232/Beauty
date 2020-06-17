namespace Beauty.Data.Models
{
    /// <summary>
    /// Модель данных конкретного сотрудника и конкретной должности
    /// </summary>
    public class WorkerPosition
    {
        /// <summary>
        /// Возвращает или задает идентификатор текущего экземпляра
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор сотрудника
        /// </summary>
        public int WorkerId { get; set; }

        /// <summary>
        /// Возвращает или задает модель данных сотрудника
        /// Данное свойство не обязательно для заполнения
        /// </summary>
        public Worker Worker { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор должности сотрудника
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Возвращает или задает модель данных должности сотрудника
        /// Данное свойство не обязательно для заполнения
        /// </summary>
        public Position Position { get; set; }
    }
}
