using HumanResources.Core.Shared.Parameters;
using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Queries.GetCompanies;

public class GetCompaniesQuery : IRequest<CompaniesModel>
{
	public CompanyRequestParameters CompanyRequestParameters { get; set; }

    public GetCompaniesQuery(CompanyRequestParameters companyRequestParameters)
    {
        CompanyRequestParameters = companyRequestParameters;
    }
}
