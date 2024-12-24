using AutoMapper;
using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Commands.CreateCompany;

public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, Guid>
{
	private readonly IMapper _mapper;
	private readonly IRepositoryManager _repositoryManager;

    public CreateCompanyHandler(
		IMapper mapper, 
		IRepositoryManager repositoryManager)
    {
        _mapper = mapper;
		_repositoryManager = repositoryManager;
    }

    public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
	{
		var companyModel = _mapper.Map<Company>(request);
		companyModel.Id = Guid.NewGuid();

		_repositoryManager.CompanyRepository.Create(companyModel);
		await _repositoryManager.SaveAsync();

		return companyModel.Id;
	}
}
