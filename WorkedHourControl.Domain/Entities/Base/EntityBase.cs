namespace WorkedHourControl.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public long Id { get; private set; }

        protected void SetId(long id) => Id = id;
    }
}
