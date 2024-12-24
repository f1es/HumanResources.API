using HumanResources.Core.Shared.Features;
using HumanResources.Usecase.Usecases.Companies.Queries.GetComapny;

namespace HumanResources.Usecase.Usecases.Companies.Queries.GetCompanies;

public class CompaniesModel
{
	public PagedList<CompanyModel> Companies { get; set; }

    public CompaniesModel(PagedList<CompanyModel> companies)
    {
        Companies = companies;
    }
}
