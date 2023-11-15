using ModuloMarketing.Api.Domain;
using System.ComponentModel.DataAnnotations;

public class ItemTest
{

    public Item item {get; set; } = new Item{
        Venda = new Venda(),
        Produto = new Produto(),
        Quantidade = 5,
        PrecoUnitario = 12.05
    };

    [Fact]
    public void TestHasAll()
    {
        Assert.Equal(5, item.Quantidade);
        var validationContext = new ValidationContext(item);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(item, validationContext, validationResults, true);
        Assert.True(isValid);
    }
    
}