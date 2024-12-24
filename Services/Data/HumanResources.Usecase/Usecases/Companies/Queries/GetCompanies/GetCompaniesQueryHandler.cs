using AutoMapper;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Features;
using HumanResources.Usecase.Usecases.Companies.Queries.GetComapny;
using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Queries.GetCompanies;


public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, CompaniesModel>
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IMapper _mapper;

	public GetCompaniesQueryHandler(
		IRepositoryManager repositoryManager,
		IMapper mapper)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
	}

	public async Task<CompaniesModel> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
	{
		var companies = await _repositoryManager.CompanyRepository.GetAllAsync(request.CompanyRequestParameters);

		var companyModels = _mapper.Map<IEnumerable<CompanyModel>>(companies);

		var pagedCompanies = PagedList<CompanyModel>.ToPagedList(companyModels, request.CompanyRequestParameters);

		var companiesModel = new CompaniesModel(pagedCompanies);

		return companiesModel;
	}
}
