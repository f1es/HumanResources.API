using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;

namespace HumanResources.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
	private readonly HumanResourcesDbContext _context;
	private readonly Lazy<ICompanyRepository> _companyRepository;
	private readonly Lazy<IDepartmentRepository> _departmentRepository;
	private readonly Lazy<IProfessionRepository> _professionRepository;
	private readonly Lazy<IVacancyRepository> _vacancyRepository;
	private readonly Lazy<IWorkerRepository> _workerRepository;
	private readonly Lazy<IDepartmentWorkerRepository> _departmentWorkerRepository;

    public RepositoryManager(HumanResourcesDbContext context)
    {
        _context = context;

		_companyRepository = new Lazy<ICompanyRepository>(() =>
		new CompanyRepository(context));

		_departmentRepository = new Lazy<IDepartmentRepository>(() =>
		new DepartmentRepository(context));

		_professionRepository = new Lazy<IProfessionRepository>(() =>
		new ProfessionRepository(context));

		_vacancyRepository = new Lazy<IVacancyRepository>(() =>
		new VacancyRepository(context));

		_workerRepository = new Lazy<IWorkerRepository>(() => 
		new WorkerRepository(context));

		_departmentWorkerRepository = new Lazy<IDepartmentWorkerRepository>(() =>
		new DepartmentWorkerRepository(context));
    }
    public ICompanyRepository CompanyRepository => _companyRepository.Value;
	public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;
	public IProfessionRepository ProfessionRepository => _professionRepository.Value;
	public IVacancyRepository VacancyRepository => _vacancyRepository.Value;
	public IWorkerRepository WorkerRepository => _workerRepository.Value;
	public IDepartmentWorkerRepository DepartmentWorkerRepository => _departmentWorkerRepository.Value;
	public async Task SaveAsync() => 
		await _context.SaveChangesAsync();
}
