using ModuloMarketing.Api.Domain;
using System.ComponentModel.DataAnnotations;


namespace ModuloMarketing.Test.Models;

public class ProdutosEmPromocaoTest
{
    public ProdutosEmPromocao ProdutosEmPromocao { get; set; } = new ProdutosEmPromocao
    {
        ID_Promocao = 99,
        ID_Produto = 22,
        DataFim = DateTime.Now,
        DataInicio = DateTime.Now,
        Desconto = Decimal.One,
    };
    
    [Fact]
    public void TestHasAll()
    {
        Assert.Equal(99, ProdutosEmPromocao.ID_Promocao);
        var validationContext = new ValidationContext(ProdutosEmPromocao);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(ProdutosEmPromocao, validationContext, validationResults, true);
        Assert.True(isValid);
    }
}