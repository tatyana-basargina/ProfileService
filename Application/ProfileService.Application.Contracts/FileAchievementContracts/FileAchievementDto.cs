using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileService.Application.Contracts.FileAchievementContracts;

public class FileAchievementDto
{
    public int Id { get; set; }
    public Guid FileId { get; set; }
    public int AchievementId { get; set; }
}
