using Domain.Base;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }
    }
}
