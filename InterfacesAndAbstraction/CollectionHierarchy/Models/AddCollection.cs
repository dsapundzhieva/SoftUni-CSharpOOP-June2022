
namespace CollectionHierarchy.Models
{
    using CollectionHierarchy.Models.Interfaces;
    using System.Collections.Generic;
    public class AddCollection<T> : IAddCollection<T>
    {
        private readonly ICollection<T> data;


        public AddCollection()
        {
            this.data = new List<T>();
        }
        public int Add(T item)
        {
            this.data.Add(item);
            return this.data.Count - 1;
        }
    }
}
