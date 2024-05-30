using silicon_courseProvider.Infrastructure.Models;
using silicon_courseProvider.Infrastructure.Services;

namespace silicon_courseProvider.Infrastructure.GraphQL.Queries;

public class Query(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;

    [GraphQLName("getAllCourses")]
    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _courseService.GetAllCoursesAsync();
    }

    [GraphQLName("getCourseById")]
    public async Task<Course> GetCourseByIdAsync(string id)
    {
        return await _courseService.GetCourseByIdAsync(id);
    }

    [GraphQLName("getCoursesByCategory")]
    public async Task<IEnumerable<Course>> GetCoursesByCategoryAsync(string category)
    {
        return await _courseService.GetCoursesByCategoryAsync(category);
    }
}
