using CustomPropertyMapping;
using CustomPropertyMapping.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CustomePropertyMappingTests;

public class CustomPropertyTests
{
    private Mappers _mappers;
    [SetUp]
    public void Setup()
    {
        _mappers = new Mappers();
    }

    [Test]
    public void CustomProperty_InLineMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi"
        };
        
        // Act
        var userDto = _mappers.InLineMapping(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            FullName = "Mehdi Talebi"
        });
    }
    
    [Test]
    public void CustomProperty_AutoMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi"
        };
        
        // Act
        var userDto = _mappers.MapWithAutoMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            FullName = "Mehdi Talebi"
        });
    }
    
    [Test]
    public void CustomProperty_MapsterMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi"
        };
        
        // Act
        var userDto = _mappers.MapWithMapster(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            FullName = "Mehdi Talebi"
        });
    }
    
    [Test]
    public void CustomProperty_TinyMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi"
        };
        
        // Act
        var userDto = _mappers.MapWithTinyMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            FullName = "Mehdi Talebi"
        });
    }
}