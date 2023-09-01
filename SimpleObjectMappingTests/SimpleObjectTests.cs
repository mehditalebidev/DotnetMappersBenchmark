using FluentAssertions;
using NUnit.Framework;
using SimpleObjectMapping;
using SimpleObjectMapping.Models;

namespace SimpleObjectMappingTests;

public class SimpleObjectTests
{
    private Mappers _mappers;
    [SetUp]
    public void Setup()
    {
        _mappers = new Mappers();
    }

    [Test]
    public void SimpleObjectInLineMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Email = "example@gmail.com"
        };
        
        // Act
        var userDto = _mappers.InLineMapping(user);
        
        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Email = "example@gmail.com"
        });
    }
    
    
    [Test]
    public void SimpleObjectAutoMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Email = "example@gmail.com"
        };
        
        // Act
        var userDto = _mappers.MapWithAutoMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Email = "example@gmail.com"
        });
    }
    
    [Test]
    public void SimpleObjectMapsterMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Email = "example@gmail.com"
        };
        
        // Act
        var userDto = _mappers.MapWithMapster(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Email = "example@gmail.com"
        });
    }
    
    [Test]
    public void SimpleObjectTinyMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Email = "example@gmail.com"
        };
        
        // Act
        var userDto = _mappers.MapWithTinyMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Email = "example@gmail.com"
        });
    }
}