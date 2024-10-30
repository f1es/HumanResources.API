﻿using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Core.Repositories;

public interface IVacancyRepository : IBaseRepository<Vacancy>
{
	Task<Vacancy> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Vacancy>> GetAllAsync(Guid companyId, VacancyRequestParameters pagingParameters, bool trackChanges = false);
}
