using System.ComponentModel.DataAnnotations;

public class ClienteTest
{

    public Cliente cliente {get; set; } = new Cliente{
        Nome = "User name",
        Sobrenome = "User last name",
        Endereco = "User Address",
        Telefone = "12345678",
        Email = "user@email.com",
        DataNascimento = DateTime.Now
    };

    [Fact]
    public void TestHasAll()
    {
        Assert.Equal("User name", cliente.Nome);
        var validationContext = new ValidationContext(cliente);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);
        Assert.True(isValid);
    }

    [Fact]
    public void ClienteSemNome()
    {
        cliente.Nome = "";
        var validationContext = new ValidationContext(cliente);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Nome field is required.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void ClienteSemEndereco()
    {
        cliente.Endereco = "";
        var validationContext = new ValidationContext(cliente);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Endereco field is required.", validationResults[0].ErrorMessage);
    }


    [Fact]
    public void ClienteSemTelefone()
    {
        cliente.Telefone = "";
        var validationContext = new ValidationContext(cliente);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Telefone field is required.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void ClienteSemEmail()
    {
        cliente.Email = "";
        var validationContext = new ValidationContext(cliente);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(cliente, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Email field is required.", validationResults[0].ErrorMessage);
    }

}