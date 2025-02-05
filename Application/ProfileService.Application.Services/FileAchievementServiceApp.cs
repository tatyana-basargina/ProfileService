using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.AchievementContracts;
using ProfileService.Application.Contracts.FileAchievementContracts;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services;

public class FileAchievementServiceApp : IFileAchievementServiceApp
{
    private readonly IMapper _mapper;
    private readonly IFileAchievementRepository _fileAchievementRepository;

    public FileAchievementServiceApp(
            IMapper mapper,
            IFileAchievementRepository fileAchievementRepository
        //IUnitOfWork unitOfWork,
        //IBusControl busControl
        )
    {
        _mapper = mapper;
        _fileAchievementRepository = fileAchievementRepository;
        //_busControl = busControl;
        //_unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Получить .
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО . </returns>
    public async Task<FileAchievementDto> GetByIdAsync(int id)
    {
        var achievement = await _fileAchievementRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<FileAchievement, FileAchievementDto>(achievement);
    }
    /// <summary>
    /// Создать .
    /// </summary>
    /// <param name="creatingAchievementDto"> ДТО создаваемого . </param>
    public async Task<int> CreateAsync(CreatingFileAchievementDto creatingFileAchievementDto)
    {
        var achievement = _mapper.Map<CreatingFileAchievementDto, FileAchievement>(creatingFileAchievementDto);
        var createdFileAchievement = await _fileAchievementRepository.AddAsync(achievement);
        await _fileAchievementRepository.SaveChangesAsync();
        return createdFileAchievement.Id;
    }
    /// <summary>
    /// Изменить .
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <param name="updatingFileAchievementDto"> ДТО редактируемого. </param>
    public async Task UpdateAsync(int id, UpdatingFileAchievementDto updatingFileAchievementDto)
    {
        var fileAchievement = await _fileAchievementRepository.GetAsync(id, CancellationToken.None);
        if (fileAchievement == null)
        {
            throw new Exception($"Профиль с идентфикатором {id} не найден");
        }

        fileAchievement.FileId = updatingFileAchievementDto.FileId;
        fileAchievement.AchievementId = updatingFileAchievementDto.AchievementId;

        _fileAchievementRepository.Update(fileAchievement);
        await _fileAchievementRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить .
    /// </summary>
    /// <param name="id"> Идентификатор . </param>
    public async Task DeleteAsync(int id)
    {
        var fileAchievement = await _fileAchievementRepository.GetAsync(id, CancellationToken.None);
        _fileAchievementRepository.Delete(fileAchievement);
        await _fileAchievementRepository.SaveChangesAsync();
    }
    /// <summary>
    /// Получить постраничный список.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница . </returns>
    public async Task<ICollection<FileAchievementDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<FileAchievement> entities = await _fileAchievementRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<FileAchievement>, ICollection<FileAchievementDto>>(entities);
    }
}
