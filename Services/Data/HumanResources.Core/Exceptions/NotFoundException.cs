namespace HumanResources.Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException()
    {
        
    }

    public NotFoundException(string message)
        : base(message) 
    {
        
    }

    public NotFoundException(string name, object key)
        : base($"entity {name} with key {key} not found")
    {

    }
}
