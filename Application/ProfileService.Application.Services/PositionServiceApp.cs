using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.PositionContracts;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services;

public class PositionServiceApp: IPositionServiceApp
{
    private readonly IMapper _mapper;
    private readonly IPositionRepository _positionRepository;

    public PositionServiceApp(
            IMapper mapper,
            IPositionRepository positionRepository
        )
    {
        _mapper = mapper;
        _positionRepository = positionRepository;
    }

    /// <summary>
    /// Получить должность.
    /// </summary>
    /// <param name="id"> Идентификатор должности. </param>
    /// <returns> ДТО должности. </returns>
    public async Task<PositionDto> GetByIdAsync(int id)
    {
        var position = await _positionRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<Position, PositionDto>(position);
    }
    /// <summary>
    /// Создать должность.
    /// </summary>
    /// <param name="creatingPositionDto"> ДТО создаваемого должности. </param>
    public async Task<int> CreateAsync(CreatingPositionDto creatingPositionDto)
    {
        var position = _mapper.Map<CreatingPositionDto, Position>(creatingPositionDto);
        var createdPosition = await _positionRepository.AddAsync(position);
        await _positionRepository.SaveChangesAsync();
        return createdPosition.Id;
    }
    /// <summary>
    /// Изменить должность.
    /// </summary>
    /// <param name="id"> Идентификатор должности. </param>
    /// <param name="updatingPositionDto"> ДТО редактируемого должности. </param>
    public async Task UpdateAsync(int id, UpdatingPositionDto updatingPositionDto)
    {
        var position = await _positionRepository.GetAsync(id, CancellationToken.None);
        if (position == null)
        {
            throw new Exception($"Должность с идентфикатором {id} не найдена");
        }

        position.Title = updatingPositionDto.Title;

        _positionRepository.Update(position);
        await _positionRepository.SaveChangesAsync();
    }
    /// <summary>
    /// Удалить должность.
    /// </summary>
    /// <param name="id"> Идентификатор должности. </param>
    public async Task DeleteAsync(int id)
    {
        var position = await _positionRepository.GetAsync(id, CancellationToken.None);
        _positionRepository.Delete(position);
        await _positionRepository.SaveChangesAsync();
    }
    /// <summary>
    /// Получить постраничный список.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница. </returns>
    public async Task<ICollection<PositionDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<Position> entities = await _positionRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<Position>, ICollection<PositionDto>>(entities);
    }
}
