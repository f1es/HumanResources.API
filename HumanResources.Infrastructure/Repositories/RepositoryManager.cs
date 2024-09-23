using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;

namespace HumanResources.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
	private readonly HumanResourcesDbContext _context;
	private readonly Lazy<ICompanyRepository> _companyRepository;
	private readonly Lazy<IDepartmentRepository> _departmentRepository;
	private readonly Lazy<IEmployeeRepository> _employeeRepository;
	private readonly Lazy<IProfessionRepository> _professionRepository;
	private readonly Lazy<ISpecialityRepository> _specialityRepository;
	private readonly Lazy<IStateRepository> _stateRepository;
	private readonly Lazy<IVacancyRepository> _vacancyRepository;
	private readonly Lazy<IWorkerRepository> _workerRepository;

    public RepositoryManager(HumanResourcesDbContext context)
    {
        _context = context;


    }
    public ICompanyRepository CompanyRepository => throw new NotImplementedException();
	public IDepartmentRepository DepartmentRepository => throw new NotImplementedException();
	public IEmployeeRepository EmployeeRepository => throw new NotImplementedException();
	public IProfessionRepository ProfessionRepository => throw new NotImplementedException();
	public ISpecialityRepository SpecialityRepository => throw new NotImplementedException();
	public IStateRepository StateRepository => throw new NotImplementedException();
	public IVacancyRepository VacancyRepository => throw new NotImplementedException();
	public IWorkerRepository WorkerRepository => throw new NotImplementedException();

	public async Task SaveAsync() => 
		await _context.SaveChangesAsync();
}
