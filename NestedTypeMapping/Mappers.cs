using System.ComponentModel;
using System.Globalization;
using AutoMapper;
using Mapster;
using Nelibur.ObjectMapper;
using NestedTypeMapping.Models;


namespace NestedTypeMapping;

public class Mappers
{
    private readonly AutoMapper.Mapper _autoMapper;
    public Mappers()
    {
        //Automapper config
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<Address, AddressDto>();
        });
        _autoMapper = new Mapper(config);
        
        //Mapster config

        //Tinymapper config
        TinyMapper.Bind<User, UserDto>();

    }

    public UserDto MapWithAutoMapper(User user)
    {
        var userDto = _autoMapper.Map<UserDto>(user);
        return userDto;
    }

    public UserDto MapWithMapster(User user)
    {
        var userDto = user.Adapt<UserDto>();
        return userDto;
    }
    
    public UserDto MapWithTinyMapper(User user)
    {
        var userDto = TinyMapper.Map<UserDto>(user);
        return userDto;
    }
    
    public UserDto InLineMapping(User user)
    {
        var userDto = new UserDto()
        {
            Address = new AddressDto()
            {
                City = user.Address.City,
                Street = user.Address.Street
            }
        };
        return userDto;
    }
}


