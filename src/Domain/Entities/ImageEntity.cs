using SharedKernel.Domain.Seedwork;

namespace Domain.Entities
{
    /// <summary>
    /// Generic Image class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ImageEntity<T> : BaseEntity where T : BaseEntity
    {
        public Guid ItemId { get; set; }
        public T Item { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return ImageUrl;
        }
    }
}