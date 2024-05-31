using Microsoft.EntityFrameworkCore;
using silicon_courseProvider.Infrastructure.Data.Contexts;
using silicon_courseProvider.Infrastructure.Factories;
using silicon_courseProvider.Infrastructure.Models;

namespace silicon_courseProvider.Infrastructure.Services;

public interface ICourseService
{
    Task<Course> CreateCourseAsync(CourseCreateRequest ccReq);

    Task<Course> UpdateCourseAsync(CourseUpdateRequest cuReq);

    Task<Course> GetCourseByIdAsync(string id);

    Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category);

    Task<IEnumerable<Course>> GetAllCoursesAsync();

    Task<bool> DeleteCourseAsync(string id);
}

public class CourseService(IDbContextFactory<DataContext> contextFactory) : ICourseService
{
    private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;

    public async Task<Course> CreateCourseAsync(CourseCreateRequest ccReq)
    {
        await using var context = _contextFactory.CreateDbContext();

        var entity = CourseFactory.CreateCourseEntity(ccReq);
        context.Courses.Add(entity);
        await context.SaveChangesAsync();

        return CourseFactory.CreateCourse(entity);
    }

    public async Task<bool> DeleteCourseAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();

        var entity = context.Courses.FirstOrDefault(x => x.Id == id);

        if (entity != null)
        {
            context.Courses.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        
        return false;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        await using var context = _contextFactory.CreateDbContext();

        var entities = await context.Courses.ToListAsync();

        return entities.Select(CourseFactory.CreateCourse);

        //DOES SAME AS ABOVE RETURN
        //List<Course> courses = new List<Course>();

        //foreach (var entity in entities)
        //{
        //    var course = CourseFactory.CreateCourse(entity);
        //    courses.Add(course);
        //}

        //return courses;


    }

    public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category)
    {
        await using var context = _contextFactory.CreateDbContext();

        var entities = await context.Courses.Where(x => x.Category == category).ToListAsync();

        return entities.Select(CourseFactory.CreateCourse);     
    }

    public async Task<Course> GetCourseByIdAsync(string id)
    {
        await using var context = _contextFactory.CreateDbContext();

        var entity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);

        if (entity != null)
        {
            return CourseFactory.CreateCourse(entity);
        }

        return null!;
    }

    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest cuReq)
    {
        await using var context = _contextFactory.CreateDbContext();

        var existingEntity = await context.Courses.FirstOrDefaultAsync(x => x.Id == cuReq.Id);
        if (existingEntity == null) { return null!; }

        var updatedEntity = CourseFactory.CreateCourseEntity(cuReq);

        updatedEntity.Id = existingEntity!.Id;
        context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);

        await context.SaveChangesAsync();

        return CourseFactory.CreateCourse(updatedEntity);
    }
}
