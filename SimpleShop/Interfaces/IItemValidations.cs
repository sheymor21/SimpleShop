namespace SimpleShop.Interfaces;

public interface IItemValidations
{
    Task<bool> AnyById(Guid id);
}