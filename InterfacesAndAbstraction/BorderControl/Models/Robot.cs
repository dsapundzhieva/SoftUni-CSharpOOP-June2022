namespace BorderControl.Models
{
    using BorderControl.Contracts;
    using System.Collections.Generic;
    public class Robot : IIdentifiable
    {
        private readonly List<string> ids;

        public Robot(string model, string id)
        {
            ids = new List<string>();
            Id = id;
            Model = model;
        }

        public string Id { get; set; }

        public string Model { get; private set; }

        public IReadOnlyCollection<string> IDs => ids;

        private void AddId()
        {
            if (Id.Length == 7)
            {
                ids.Add(Id);
            }
        }
    }
}
