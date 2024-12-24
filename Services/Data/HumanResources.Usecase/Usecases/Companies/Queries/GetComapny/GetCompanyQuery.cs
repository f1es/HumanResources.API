using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Queries.GetComapny;

public class GetCompanyQuery : IRequest<CompanyModel>
{
	public Guid Id { get; set; }

    public GetCompanyQuery(Guid id)
    {
        Id = id;   
    }
}
