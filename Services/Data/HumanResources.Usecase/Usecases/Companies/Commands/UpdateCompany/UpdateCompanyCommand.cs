using MediatR;

namespace HumanResources.Usecase.Usecases.Companies.Commands.UpdateCompany;

public class UpdateCompanyCommand : IRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public DateTime BaseDate { get; set; }

    public UpdateCompanyCommand(Guid id, CompanyUpdateModel model)
    {
        Id = id;
        Name = model.Name;
        BaseDate = model.BaseDate;
    }
}
