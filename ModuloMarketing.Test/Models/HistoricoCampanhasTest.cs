using ModuloMarketing.Api.Domain;
using System.ComponentModel.DataAnnotations;

namespace ModuloMarketing.Test.Models;

public class HistoricoCampanhasTest
{
    public HistoricoCampanhas Historico { get; set; } = new HistoricoCampanhas
    {
        Id_Historico_Campanha = 12930,
        Id_Campanha = 12322,
        Id_Resultado_Campanha = 12332,
        Data_Inicio = new DateOnly(),
        Data_Fim = new DateOnly(),
        Descricao = "historico da campanha"
    };

    [Fact]
    public void TestHasAll()
    {
        Assert.Equal(12930, Historico.Id_Historico_Campanha);
        var validationContext = new ValidationContext(Historico);
        var validationResults = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(Historico, validationContext, validationResults, true);
        Assert.True(isValid);
    }


}

