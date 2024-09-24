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

		_companyRepository = new Lazy<ICompanyRepository>(() =>
		new CompanyRepository(context));

		_departmentRepository = new Lazy<IDepartmentRepository>(() =>
		new DepartmentRepository(context));
    }
    public ICompanyRepository CompanyRepository => _companyRepository.Value;
	public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;
	public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
	public IProfessionRepository ProfessionRepository => _professionRepository.Value;
	public ISpecialityRepository SpecialityRepository => _specialityRepository.Value;
	public IStateRepository StateRepository => _stateRepository.Value;
	public IVacancyRepository VacancyRepository => _vacancyRepository.Value;
	public IWorkerRepository WorkerRepository => _workerRepository.Value;
	public async Task SaveAsync() => 
		await _context.SaveChangesAsync();
}
