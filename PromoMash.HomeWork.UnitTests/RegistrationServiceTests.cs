using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using PromoMash.Homework.Web.Server.Dal.SqLite.Repositories.Interfaces;
using PromoMash.Homework.Web.Server.Services;

public class RegistrationServiceTests
{
    private readonly Mock<IPasswordHasher<UserDomain>> _passwordHasherMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<ICountryRepository> _countryRepositoryMock;
    private readonly Mock<IProvinceRepository> _provinceRepositoryMock;
    private readonly Mock<ILogger<RegistrationService>> _loggerMock;
    private readonly RegistrationService _service;
    private readonly Guid _provinceId = Guid.Parse("EB86338D-240F-4962-944F-C3D9BCCB2649");
    public RegistrationServiceTests()
    {
        _passwordHasherMock = new Mock<IPasswordHasher<UserDomain>>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _countryRepositoryMock = new Mock<ICountryRepository>();
        _provinceRepositoryMock = new Mock<IProvinceRepository>();
        _loggerMock = new Mock<ILogger<RegistrationService>>();

        _service = new RegistrationService(
            _passwordHasherMock.Object,
            _userRepositoryMock.Object,
            _countryRepositoryMock.Object,
            _provinceRepositoryMock.Object,
            _loggerMock.Object);
    }

    [Fact]
    public async Task Create_Should_Return_Error_If_Country_Does_Not_Exist()
    {
        // Arrange
        var user = new UserDomain { CountryId = 1, ProvinceId = _provinceId, Email = "test@example.com", Password = "password" };
        _countryRepositoryMock.Setup(repo => repo.Exists(user.CountryId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

        // Act
        var result = await _service.Create(user);

        // Assert
        Assert.Contains(result.Errors, e => e.Contains("Country 1 doesn't exist"));
    }

    [Fact]
    public async Task Create_Should_Return_Error_If_Province_Does_Not_Exist()
    {
        var user = new UserDomain { CountryId = 1, ProvinceId = _provinceId, Email = "test@example.com", Password = "password" };
        _countryRepositoryMock.Setup(repo => repo.Exists(user.CountryId, It.IsAny<CancellationToken>())).ReturnsAsync(true);
        _provinceRepositoryMock.Setup(repo => repo.Exists(user.ProvinceId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

        var result = await _service.Create(user);

        Assert.Contains(result.Errors, e => e.Contains($"Province {_provinceId} doesn't exist"));
    }

    [Fact]
    public async Task Create_Should_Return_Error_If_Email_Already_Exists()
    {
        var user = new UserDomain { CountryId = 1, ProvinceId = _provinceId, Email = "test@example.com", Password = "password" };
        _countryRepositoryMock.Setup(repo => repo.Exists(user.CountryId, It.IsAny<CancellationToken>())).ReturnsAsync(true);
        _provinceRepositoryMock.Setup(repo => repo.Exists(user.ProvinceId, It.IsAny<CancellationToken>())).ReturnsAsync(true);
        _userRepositoryMock.Setup(repo => repo.Exists(user.Email, It.IsAny<CancellationToken>())).ReturnsAsync(true);

        var result = await _service.Create(user);

        Assert.Contains(result.Errors, e => e.Contains("Email test@example.com already exists"));
    }

    [Fact]
    public async Task Create_Should_Hash_Password_And_Save_User()
    {
        var user = new UserDomain { CountryId = 1, ProvinceId = _provinceId, Email = "test@example.com", Password = "password" };
        _countryRepositoryMock.Setup(repo => repo.Exists(user.CountryId, It.IsAny<CancellationToken>())).ReturnsAsync(true);
        _provinceRepositoryMock.Setup(repo => repo.Exists(user.ProvinceId, It.IsAny<CancellationToken>())).ReturnsAsync(true);
        _userRepositoryMock.Setup(repo => repo.Exists(user.Email, It.IsAny<CancellationToken>())).ReturnsAsync(false);
        _passwordHasherMock.Setup(hasher => hasher.HashPassword(user, user.Password)).Returns("hashed_password");

        var result = await _service.Create(user);

        Assert.Empty(result.Errors);
        Assert.Equal("hashed_password", user.Password);
        _userRepositoryMock.Verify(repo => repo.Create(user, It.IsAny<CancellationToken>()), Times.Once);
    }
}
