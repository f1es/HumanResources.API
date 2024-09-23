namespace HumanResources.Core.Repositories;

public interface IRepositoryManager
{
	ICompanyRepository CompanyRepository { get; }
	IDepartmentRepository DepartmentRepository { get; }
	IEmployeeRepository EmployeeRepository { get; }
	IProfessionRepository ProfessionRepository { get; }
	ISpecialityRepository SpecialityRepository { get; }
	IStateRepository StateRepository { get; }
	IVacancyRepository VacancyRepository { get; }
	IWorkerRepository WorkerRepository { get; }
	Task SaveAsync();
}
