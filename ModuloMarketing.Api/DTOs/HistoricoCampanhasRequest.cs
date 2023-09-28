using ModuloMarketing.Api.Domain;

public record HistoricoCampanhasRequest(
    
    string Descricao,
    DateOnly Data_Inicio,
    DateOnly Data_Fim
  
);