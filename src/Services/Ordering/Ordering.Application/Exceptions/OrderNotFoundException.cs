namespace Ordering.Application.Exceptions;

internal class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(Guid Id): base($"Order with ID:{Id} was not found")
    {
        
    }
}
