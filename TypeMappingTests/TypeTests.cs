using TypeMapping;
using TypeMapping.Models;
using FluentAssertions;
using NUnit.Framework;

namespace TypeMappingTests;

public class TypeTests
{
    private Mappers _mappers;
    [SetUp]
    public void Setup()
    {
        _mappers = new Mappers();
    }

    [Test]
    public void Type_InLineMapping()
    {
        // Arrange
        var user = new User()
        {
            Age = 25
        };
        
        // Act
        var userDto = _mappers.InLineMapping(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Age = "25"
        });
    }
    
    [Test]
    public void Type_AutoMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            Age = 25
        };
        
        // Act
        var userDto = _mappers.MapWithAutoMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Age = "25"
        });
    }
    
    [Test]
    public void Type_MapsterMapping()
    {
        // Arrange
        var user = new User()
        {
            Age = 25
        };
        
        // Act
        var userDto = _mappers.MapWithMapster(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Age = "25"
        });
    }
    
    [Test]
    public void Type_TinyMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            Age = 25
        };
        
        // Act
        var userDto = _mappers.MapWithTinyMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Age = "25"
        });
    }
}