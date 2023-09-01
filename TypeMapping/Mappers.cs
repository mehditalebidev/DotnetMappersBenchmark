using System.ComponentModel;
using System.Globalization;
using AutoMapper;
using Mapster;
using Nelibur.ObjectMapper;
using TypeMapping.Models;


namespace TypeMapping;

public class Mappers
{
    private readonly AutoMapper.Mapper _autoMapper;
    public Mappers()
    {
        //Automapper config
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>();
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
            Age = user.Age.ToString()
        };
        return userDto;
    }
}


