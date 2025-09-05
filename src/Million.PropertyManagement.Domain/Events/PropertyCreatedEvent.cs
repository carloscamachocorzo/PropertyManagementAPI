namespace Million.PropertyManagement.Domain.Events
{
    public class PropertyCreatedEvent : IDomainEvent
    {
        public int PropertyId { get; }
        public string Name { get; }
        public DateTime OccurredOn { get; }

        public PropertyCreatedEvent(int propertyId, string name)
        {
            PropertyId = propertyId;
            Name = name;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
