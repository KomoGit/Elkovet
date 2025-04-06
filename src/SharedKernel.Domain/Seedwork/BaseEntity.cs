namespace SharedKernel.Domain.Seedwork
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public BaseEntity()
        {
            Id = new Guid();
            CreatedDate = DateTime.Now.Date;
            UpdatedDate = DateTime.Now.Date;
        }
    }
}
