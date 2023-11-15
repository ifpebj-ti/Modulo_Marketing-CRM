
namespace ModuloMarketing.Api.DTOs;

public record CampanhaRequest(
    string Nome_Campanha,
    string Nome_Criador,
    string Email_Criador,
    string Descricao,
    DateTime Data_Inicio,
    DateTime Data_Termino,
    DateTime Data_Criacao,
    string Mensagem,
    string Observacao,
    double Valor_Meta,
    bool Recorrente,
    int Frequencia,
    int Dia_Da_Semana_Da_Recorrencia,
    int Dia_Do_Mes_Da_Recorrencia,
    int Frequencia_de_Repeticao
);