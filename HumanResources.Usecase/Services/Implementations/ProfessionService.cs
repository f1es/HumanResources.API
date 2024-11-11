using AutoMapper;
using HumanResources.Core.Exceptions;
using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;
using HumanResources.Core.Shared.Features;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;

namespace HumanResources.Usecase.Services.Implementations;

public class ProfessionService : IProfessionService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IMapper _mapper;

	public ProfessionService(
		IRepositoryManager repositoryManager,
		IMapper mapper)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
	}

	public async Task<ProfessionResponseDto> CreateAsync(ProfessionRequestDto professionDto)
	{
		var professionModel = _mapper.Map<Profession>(professionDto);
		professionModel.Id = Guid.NewGuid();

		_repositoryManager.ProfessionRepository.Create(professionModel);
		await _repositoryManager.SaveAsync();

		var professionResponse = _mapper.Map<ProfessionResponseDto>(professionModel);
		return professionResponse;
	}

	public async Task DeleteAsync(Guid id)
	{
		var profession = await GetByIdAndCheckIfExist(id);
		_repositoryManager.ProfessionRepository.Delete(profession);
		await _repositoryManager.SaveAsync();
	}

	public async Task<PagedList<ProfessionResponseDto>> GetAllAsync(ProfessionRequestParameters requestParameters)
	{
		var professions = await _repositoryManager.ProfessionRepository.GetAllAsync(requestParameters);
		var professionsResponse = _mapper.Map<IEnumerable<ProfessionResponseDto>>(professions);

		var pagedList = PagedList<ProfessionResponseDto>.ToPagedList(professionsResponse, requestParameters);

		return pagedList;
	}

	public async Task<ProfessionResponseDto> GetByIdAsync(Guid id)
	{
		var professionModel = await GetByIdAndCheckIfExist(id);
		var professionResponse = _mapper.Map<ProfessionResponseDto>(professionModel);
		return professionResponse;
	}

	public async Task UpdateAsync(Guid id, ProfessionRequestDto professionDto)
	{
		var professionModel = await GetByIdAndCheckIfExist(id ,trackChanges: true);

		professionModel = _mapper.Map(professionDto, professionModel);

		await _repositoryManager.SaveAsync();
	}

	private async Task<Profession> GetByIdAndCheckIfExist(Guid id, bool trackChanges = false)
	{
		var profession = await _repositoryManager.ProfessionRepository.GetByIdAsync(id, trackChanges);

		if (profession is null)
			throw new NotFoundException($"Profession with id {id} not found");

		return profession;
	}
}
