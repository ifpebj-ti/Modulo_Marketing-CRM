using System.ComponentModel.DataAnnotations;

public class MarketingTest
{

    public Marketing marketing {get; set; } = new Marketing{
        Nome = "Marketing name",
        Descricao = "Test description",
        Canais = "Whatsapp, Instagram",
        DataInicio = DateTime.Now,
        DataTermino = DateTime.Now
    };

    [Fact]
    public void TestHasAll()
    {
        Assert.Equal("Marketing name", marketing.Nome);
        var validationContext = new ValidationContext(marketing);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(marketing, validationContext, validationResults, true);
        Assert.True(isValid);
    }

    [Fact]
    public void MarketingSemNome()
    {
        marketing.Nome = "";
        var validationContext = new ValidationContext(marketing);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(marketing, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Nome field is required.", validationResults[0].ErrorMessage);
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
    public void MarketingSemCanais()
    {
        marketing.Canais = "";
        var validationContext = new ValidationContext(marketing);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(marketing, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Canais field is required.", validationResults[0].ErrorMessage);
    }

}