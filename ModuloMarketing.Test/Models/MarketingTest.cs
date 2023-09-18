using System.ComponentModel.DataAnnotations;

public class MarketingTest
{

    public Marketing marketing {get; set; } = new Marketing{
        Nome_Marketing = "Marketing name",
        Descricao = "Test description",
        Email_Criador = "Test@test.com",
        DataInicio = DateTime.Now,
        DataTermino = DateTime.Now
    };

    [Fact]
    public void TestHasAll()
    {
        Assert.Equal("Marketing name", marketing.Nome_Marketing);
        var validationContext = new ValidationContext(marketing);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(marketing, validationContext, validationResults, true);
        Assert.True(isValid);
    }

    [Fact]
    public void MarketingSemNome()
    {
        marketing.Nome_Marketing = "";
        var validationContext = new ValidationContext(marketing);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(marketing, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Nome_Marketing field is required.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void MarketingSemDescricao()
    {
        marketing.Descricao = "";
        var validationContext = new ValidationContext(marketing);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(marketing, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Descricao field is required.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void MarketingSemEmailCriador()
    {
        marketing.Email_Criador = "";
        var validationContext = new ValidationContext(marketing);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(marketing, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Email_Criador field is required.", validationResults[0].ErrorMessage);
    }

}