using ModuloMarketing.Api.Domain;

public record CampanhaRequest(
    string Nome_Campanha,
    string Email_Criador,
    string Descricao,
    DateTime Data_Inicio,
    DateTime Data_Termino,
    string Mensagem,
    string Observacao
);