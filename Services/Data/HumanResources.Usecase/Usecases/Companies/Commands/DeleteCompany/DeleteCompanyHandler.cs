using HumanResources.Core.Exceptions;
using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Commands.DeleteCompany;

public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand>
{
	private readonly IRepositoryManager _repositoryManager;

	public DeleteCompanyHandler(IRepositoryManager repositoryManager)
	{
		_repositoryManager = repositoryManager;
	}

	public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
	{
		var company = await _repositoryManager.CompanyRepository.GetByIdAsync(request.Id);

		if (company is null)
		{
			throw new NotFoundException(nameof(Company), request.Id);
		}

		_repositoryManager.CompanyRepository.Delete(company);

		await _repositoryManager.SaveAsync();
	}
}
