using SharedKernel.Domain.Seedwork;

namespace Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void SetDetails()
        {

        }
    }
}
