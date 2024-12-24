using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Commands.DeleteCompany;

public class DeleteCompanyCommand : IRequest
{
	public Guid Id { get; set; }

    public DeleteCompanyCommand(Guid id)
    {
        Id = id;
    }
}
