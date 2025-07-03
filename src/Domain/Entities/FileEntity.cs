using SharedKernel.Domain.Seedwork;

namespace Domain.Entities
{
    /// <summary>
    /// Generic File class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FileEntity<T> : BaseEntity where T : BaseEntity
    {
        public Guid ItemId { get; set; }
        public T Item { get; set; }
        public string FileUrl { get; set; }

        public override string ToString()
        {
            return FileUrl;
        }
    }
}