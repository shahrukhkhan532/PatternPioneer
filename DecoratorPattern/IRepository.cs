
using Microsoft.Extensions.Caching.Memory;
using System;

namespace PatternPioneer.DecoratorPattern;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public interface IRepository
{
    public Task<Student> GetPersonByIdAsync(int id);
    public Task SavePersonAsync(Student student);
}

public class SlowRepository : IRepository
{
    private readonly List<Student> _students = new();

    public async Task<Student> GetPersonByIdAsync(int id)
    {
        await Task.Delay(1000);
        return _students.First(x => x.Id == id);
    }

    public Task SavePersonAsync(Student student)
    {
        _students.Add(student);
        return Task.CompletedTask;
    }
}

public class CachedRepository : IRepository
{
    private readonly IRepository _repository;
    private readonly IMemoryCache _memoryCache;

    public CachedRepository(IRepository repository, IMemoryCache memoryCache)
    {
        _repository = repository;
        _memoryCache = memoryCache;
    }
    public async Task<Student> GetPersonByIdAsync(int id)
    {
        if (!_memoryCache.TryGetValue(id, out Student student))
        {
            student = await _repository.GetPersonByIdAsync(id);
            _memoryCache.Set(id, student);
        }

        return student ?? new Student();
    }

    public Task SavePersonAsync(Student student)
    {
        return _repository.SavePersonAsync(student);
    }
}