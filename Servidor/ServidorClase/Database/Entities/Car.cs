namespace ServidorClase.Database.Entities;

public class Car
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Price { get; set; }
    public int OwnerId { get; set; }

    public User? Owner { get; set; }
}
