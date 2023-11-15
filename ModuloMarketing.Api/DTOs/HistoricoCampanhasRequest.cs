using ModuloMarketing.Api.Domain;

namespace ModuloMarketing.Api.DTOs;
public record HistoricoCampanhasRequest(
    
    string Descricao,
    DateOnly Data_Inicio,
    DateOnly Data_Fim
  
);