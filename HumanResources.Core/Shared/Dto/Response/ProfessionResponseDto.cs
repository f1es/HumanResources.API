namespace HumanResources.Core.Shared.Dto.Response;

public record ProfessionResponseDto(
    Guid Id,
    string Name,
    decimal Salary);
