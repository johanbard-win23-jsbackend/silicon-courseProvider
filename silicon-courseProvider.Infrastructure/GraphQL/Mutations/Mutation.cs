using silicon_courseProvider.Infrastructure.Models;
using silicon_courseProvider.Infrastructure.Services;

namespace silicon_courseProvider.Infrastructure.GraphQL.Mutations;

public class Mutation(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;

    [GraphQLName("createCourse")]
    public async Task<Course> CreateCourseAsync(CourseCreateRequest ccReq)
    {
        return await _courseService.CreateCourseAsync(ccReq);
    }

    [GraphQLName("updateCourse")]
    public async Task<Course> UpdateCourseAsync(CourseUpdateRequest cuReq)
    {
        return await _courseService.UpdateCourseAsync(cuReq);
    }

    [GraphQLName("deleteCourse")]
    public async Task<bool> DeleteCourseAsync(string id)
    {
        return await _courseService.DeleteCourseAsync(id);
    }
}
