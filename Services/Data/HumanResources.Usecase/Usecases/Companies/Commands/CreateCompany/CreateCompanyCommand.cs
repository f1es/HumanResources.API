using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Commands.CreateCompany;

public class CreateCompanyCommand : IRequest<Guid>
{
	public string Name { get; set; }
	public DateTime BaseDate { get; set; }
}
