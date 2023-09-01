using NestedTypeMapping;
using NestedTypeMapping.Models;
using FluentAssertions;
using NUnit.Framework;

namespace NestedTypeMappingTests;

public class NestedTypeTests
{
    private Mappers _mappers;
    [SetUp]
    public void Setup()
    {
        _mappers = new Mappers();
    }

    [Test]
    public void NestedType_InLineMapping()
    {
        // Arrange
        var user = new User()
        {
            Address = new Address()
            {
                City = "LA",
                Street = "West road"
            }
        };
        
        // Act
        var userDto = _mappers.InLineMapping(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Address = new AddressDto()
            {
                City = "LA",
                Street = "West road"
            }
        });
    }
    
    [Test]
    public void NestedType_AutoMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            Address = new Address()
            {
                City = "LA",
                Street = "West road"
            }
        };
        
        // Act
        var userDto = _mappers.MapWithAutoMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Address = new AddressDto()
            {
                City = "LA",
                Street = "West road"
            }
        });
    }
    
    [Test]
    public void NestedType_MapsterMapping()
    {
        // Arrange
        var user = new User()
        {
            Address = new Address()
            {
                City = "LA",
                Street = "West road"
            }
        };
        
        // Act
        var userDto = _mappers.MapWithMapster(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Address = new AddressDto()
            {
                City = "LA",
                Street = "West road"
            }
        });
    }
    
    [Test]
    public void NestedType_TinyMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            Address = new Address()
            {
                City = "LA",
                Street = "West road"
            }
        };
        
        // Act
        var userDto = _mappers.MapWithTinyMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Address = new AddressDto()
            {
                City = "LA",
                Street = "West road"
            }
        });
    }
}