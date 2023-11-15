using ModuloMarketing.Api.Domain;
using System.ComponentModel.DataAnnotations;

public class ProdutoTest
{

    public Produto produto { get; set; } = new Produto{
        NomeProduto = "Product name",
        Descricao = "Test description",
        Categoria = "Test cat",
        PrecoVenda = 99,
        QuantidadeEstoque = 12,
        DataValidade = DateTime.Now,
        Fornecedor = "Test provider"
    };

    [Fact]
    public void TestHasAll()
    {
        Assert.Equal("Product name", produto.NomeProduto);
        var validationContext = new ValidationContext(produto);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(produto, validationContext, validationResults, true);
        Assert.True(isValid);
    }

    [Fact]
    public void ProdutoSemNome()
    {
        produto.NomeProduto = "";
        var validationContext = new ValidationContext(produto);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(produto, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The NomeProduto field is required.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void ProdutoSemDescricao()
    {
        produto.Descricao = "";
        var validationContext = new ValidationContext(produto);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(produto, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Descricao field is required.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void ProdutoSemCategoria()
    {
        produto.Categoria = "";
        var validationContext = new ValidationContext(produto);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(produto, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Categoria field is required.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void ProdutoSemFornecedor()
    {
        produto.Fornecedor = "";
        var validationContext = new ValidationContext(produto);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(produto, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Fornecedor field is required.", validationResults[0].ErrorMessage);
    }
   

}