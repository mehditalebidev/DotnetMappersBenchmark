using AutoMapper;
using Mapster;
using Nelibur.ObjectMapper;
using SimpleObjectMapping.Models;

namespace SimpleObjectMapping;

public class Mappers
{
    private readonly AutoMapper.Mapper _autoMapper;
    public Mappers()
    {
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<User, UserDto>());
        _autoMapper = new Mapper(config);
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
            Email = user.Email
        };
        return userDto;
    }
}