using Domain.Base;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }

        public Customer(string name)
        {
            this.Name = name;
        }
    }
}
