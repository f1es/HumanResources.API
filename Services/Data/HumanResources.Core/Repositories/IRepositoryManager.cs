namespace HumanResources.Core.Repositories;

public interface IRepositoryManager
{
	ICompanyRepository CompanyRepository { get; }
	IDepartmentRepository DepartmentRepository { get; }
	IProfessionRepository ProfessionRepository { get; }
	IVacancyRepository VacancyRepository { get; }
	IWorkerRepository WorkerRepository { get; }
	IDepartmentWorkerRepository DepartmentWorkerRepository { get; }
	Task SaveAsync();
}
