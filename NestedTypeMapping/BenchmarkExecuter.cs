﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using NestedTypeMapping.Models;

namespace NestedTypeMapping;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[RPlotExporter]
[MemoryDiagnoser(false)]

public class BenchmarkExecuter
{
    private User? _user;
    private readonly Mappers _mappers;
    
    public BenchmarkExecuter()
    {
        _mappers = new Mappers();
    }
    
    [GlobalSetup]
    public void Setup()
    {
        _user = new User()
        {
            Address = new Address()
            {
                City = "LA",
                Street = "West road"
            }
        };
    }
    
    [Benchmark]
    public UserDto AutoMapper_bm()
    {
        return _mappers.MapWithAutoMapper(_user);
    }

    [Benchmark] 
    public UserDto Mapster_bm()
    {
        return _mappers.MapWithMapster(_user);
    }
    
    [Benchmark] 
    public UserDto TinyMapper_bm()
    {
        return _mappers.MapWithTinyMapper(_user);
    }
    
    [Benchmark] 
    public UserDto InLineMapping_bm()
    {
        return _mappers.InLineMapping(_user);
    }
   
}