using AutoMapper;
using HumanResources.Core.Exceptions;
using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Queries.GetComapny;

public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyModel>
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IMapper _mapper;

	public GetCompanyQueryHandler(
		IRepositoryManager repositoryManager,
		IMapper mapper)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
	}

	public async Task<CompanyModel> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
	{
		var company = await _repositoryManager.CompanyRepository.GetByIdAsync(request.Id);

		if (company == null)
		{
			throw new NotFoundException(nameof(Company), request.Id);
		}

		var companyModel = _mapper.Map<CompanyModel>(company);

		return companyModel;
	}
}
