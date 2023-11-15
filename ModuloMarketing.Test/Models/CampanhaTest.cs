using ModuloMarketing.Api.Domain;
using System.ComponentModel.DataAnnotations;

public class CampanhaTest
{

    public Campanha campanha {get; set; } = new Campanha{
        Nome_Campanha = "Campanha name",
        Descricao = "Test description",
        Email_Criador = "Test@test.com",
        Data_Inicio = DateTime.Now,
        Data_Termino = DateTime.Now
    };

    [Fact]
    public void TestHasAll()
    {
        Assert.Equal("Campanha name", campanha.Nome_Campanha);
        var validationContext = new ValidationContext(campanha);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(campanha, validationContext, validationResults, true);
        Assert.True(isValid);
    }

    [Fact]
    public void CampanhaSemNome()
    {
        campanha.Nome_Campanha = "";
        var validationContext = new ValidationContext(campanha);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(campanha, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Nome_Campanha field is required.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void CampanhaSemDescricao()
    {
        campanha.Descricao = "";
        var validationContext = new ValidationContext(campanha);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(campanha, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Descricao field is required.", validationResults[0].ErrorMessage);
    }

    [Fact]
    public void CampanhaSemEmailCriador()
    {
        campanha.Email_Criador = "";
        var validationContext = new ValidationContext(campanha);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(campanha, validationContext, validationResults, true);
        Assert.False(isValid);
        Assert.Equal("The Email_Criador field is required.", validationResults[0].ErrorMessage);
    }

}