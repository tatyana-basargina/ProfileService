using MassTransit;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Contracts.ProfileInfoContracts;
using ProfileService.Common.Enums;
using SnowPro.Shared.Contracts;

namespace ProfileService.API.Consumers;

public class UserRegisteredConsumer(
    ILogger<UserRegisteredConsumer> logger,
    IProfileInfoServiceApp profileInfoService
) : IConsumer<UserRegisteredDto>
{
    public async Task Consume(ConsumeContext<UserRegisteredDto> context)
    {
        UserRegisteredDto? message = context.Message;
        logger.LogInformation($"Received: {message.UserId} ({message.RoleName})");
        try
        {
            await CreateProfileInfoAsync(message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to process the creation of the user profile after registration");
        }
    }

    /// <summary>
    /// Создание профиля пользователя после регистрации
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private async Task CreateProfileInfoAsync(UserRegisteredDto message)
    {
        var profileType = message.RoleName switch
        {
            nameof(ProfileType.Client) => ProfileType.Client,
            nameof(ProfileType.Instructor) => ProfileType.Instructor,
            _ => throw new ArgumentException(nameof(message.RoleName), $"Unknown role: {message.RoleName}")
        };

        await profileInfoService.CreateAsync(message.UserId,
                new CreatingProfileInfoDto()
                {
                    ProfileType = profileType,
                    Name = message.FirstName,
                    Surname = message.LastName,
                    PhoneNumber = message.PhoneNumber
                });
    }
}
