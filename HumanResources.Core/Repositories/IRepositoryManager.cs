namespace HumanResources.Core.Repositories;

public interface IRepositoryManager
{
	ICompanyRepository CompanyRepository { get; }
	IDepartmentRepository DepartmentRepository { get; }
	IProfessionRepository ProfessionRepository { get; }
	ISpecialityRepository SpecialityRepository { get; }
	IVacancyRepository VacancyRepository { get; }
	IWorkerRepository WorkerRepository { get; }
	Task SaveAsync();
}
