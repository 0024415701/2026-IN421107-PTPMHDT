
using EduHub.Ch02;
using EduHub.Ch02.Domain;

namespace Ch02.Refactor.Tests;

public class DomainTests
{
    [Fact]
    public void CreateClub_WithEmptyName_ThrowsArgumentException()
    {
        // Arrange
        string name = "";
        string description = "Mo ta CLB";

        // Act
        var act = () => Club.Create(name, description);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Club_Create_WithValidName_ReturnsClub()
    {
        // Arrange
        string name = "Tech Club";
        string description = "Cau lac bo cong nghe";

        // Act
        var club = Club.Create(name, description);

        // Assert
        Assert.Equal(name, club.Name);
        Assert.Equal(description, club.Description);
        Assert.NotEqual(Guid.Empty, club.Id);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("A name longer than the maximum allowed length")]
    public void Club_Create_WithInvalidName_ThrowsArgumentException(
        string name)
    {
        // Arrange
        if (name == "A name longer than the maximum allowed length")
        {
            name = new string('A', Club.MaxNameLength + 1);
        }

        // Act
        var act = () => Club.Create(name, "Mo ta CLB");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [InlineData(49, true)]
    [InlineData(50, false)]
    public void Club_HasRoom_AtMemberCount_ReturnsExpectedResult(
        int memberCount,
        bool expected)
    {
        // Arrange
        var club = Club.Create("Tech Club", "Mo ta CLB");

        // Act
        bool result = club.HasRoom(memberCount);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Event_Register_NewMember_ReturnsTrue()
    {
        // Arrange
        var ev = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = Guid.NewGuid(),
            Title = "Workshop SOLID",
            Date = new DateTime(2026, 11, 20)
        };

        var memberId = Guid.NewGuid();

        // Act
        bool result = ev.Register(memberId);

        // Assert
        Assert.True(result);
        Assert.Contains(memberId, ev.RegisteredMemberIds);
    }

    [Fact]
    public void Event_Register_SameMemberTwice_ReturnsFalse()
    {
        // Arrange
        var ev = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = Guid.NewGuid(),
            Title = "Workshop SOLID",
            Date = new DateTime(2026, 11, 20)
        };

        var memberId = Guid.NewGuid();
        ev.Register(memberId);

        // Act
        bool result = ev.Register(memberId);

        // Assert
        Assert.False(result);
        Assert.Single(ev.RegisteredMemberIds);
    }

    [Fact]
    public void Event_CheckIn_UnregisteredMember_ThrowsInvalidOperationException()
    {
        // Arrange
        var ev = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = Guid.NewGuid(),
            Title = "Workshop SOLID",
            Date = new DateTime(2026, 11, 20)
        };

        var memberId = Guid.NewGuid();

        // Act
        var act = () => ev.CheckIn(memberId);

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }
}
