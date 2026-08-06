using SharedKernel.Entities;

namespace Inventory.Domain.Products;

public sealed class Product : AggregateRoot
{
    private Product()
    {
        // Required by EF Core
    }

    public Product(
        string name,
        string sku,
        decimal price,
        int quantity)
    {
        Name = name;
        Sku = sku;
        Price = price;
        Quantity = quantity;
    }

    public string Name { get; private set; } = default!;

    public string Sku { get; private set; } = default!;

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public void IncreaseStock(int quantity)
    {
        Quantity += quantity;
    }

    public void DecreaseStock(int quantity)
    {
        if (Quantity < quantity)
            throw new InvalidOperationException("Insufficient stock.");

        Quantity -= quantity;
    }

    public void ChangePrice(decimal price)
    {
        Price = price;
    }
}