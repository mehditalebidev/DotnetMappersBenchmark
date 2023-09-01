using System.ComponentModel;
using System.Globalization;
using AutoMapper;
using Mapster;
using Nelibur.ObjectMapper;
using CustomPropertyMapping.Models;


namespace CustomPropertyMapping;

public class Mappers
{
    private readonly AutoMapper.Mapper _autoMapper;
    public Mappers()
    {
        //Automapper config
        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        });
        _autoMapper = new Mapper(config);
        
        //Mapster config
        TypeAdapterConfig<User, UserDto>
            .NewConfig()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");

        //Tinymapper config
        TypeDescriptor.AddAttributes(typeof(User), new TypeConverterAttribute(typeof(UserConverter)));
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
            FullName = $"{user.FirstName} {user.LastName}"
        };
        return userDto;
    }
}


public sealed class UserConverter : TypeConverter
{
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        return destinationType == typeof(UserDto);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        var concreteValue = (User)value;
        var result = new UserDto
        {
            FullName = string.Format("{0} {1}", concreteValue.FirstName, concreteValue.LastName)
        };
        return result;
    }
}

