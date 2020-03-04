using System;

namespace WebApiHeroku.Core.Entities
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Category(string name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
        }
    }
}