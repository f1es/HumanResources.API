using AutoMapper;
using HumanResources.Core.Exceptions;
using HumanResources.Core.Repositories;
using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Commands.UpdateCompany;

public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand>
{
	private readonly IMapper _mapper;
	private readonly IRepositoryManager _repositoryManager;

	public UpdateCompanyHandler(
		IMapper mapper,
		IRepositoryManager repositoryManager)
	{
		_mapper = mapper;
		_repositoryManager = repositoryManager;
	}

	public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
	{
		var company = await _repositoryManager.CompanyRepository.GetByIdAsync(request.Id, trackChanges: true);

		if (company is null)
		{
			throw new NotFoundException($"Company with id {request.Id} not found");
		} 
		
		_mapper.Map(request, company);

		await _repositoryManager.SaveAsync();
	}
}
