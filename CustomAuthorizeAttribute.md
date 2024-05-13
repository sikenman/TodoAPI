## CustomAuthorizeAttribute
Certainly! Below is a full example of how to create a custom authorization attribute in an ASP.NET Core 8 web application. I've included the necessary code snippets for you:
- Create a Custom Authorize Attribute:
First, define a custom authorization attribute by creating a class that inherits from IAuthorizationFilter. This interface exposes a single method called OnAuthorization(AuthorizationFilterContext context) that executes before an action method is invoked. Here's the complete code:

```
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public sealed class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context != null)
        {
            // Your custom authorization logic goes here
            // For example, check if the user has the necessary claims or roles
            // If authorization fails, set context.Result to a ForbiddenResult or RedirectResult
        }
    }
}
```

- Apply the Custom Attribute:
You can apply this custom attribute to an action method or a controller. For instance, consider the following action method that uses our CustomAuthorizeAttribute:

```
[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    [CustomAuthorize]
    public IEnumerable<WeatherForecast> Get()
    {
        // Your action method logic here
        // This method won't execute unless the authorization check is successful
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();
    }
}
```
- Inject Dependencies (Optional):
Sometimes you need to inject external dependencies within the filter to perform more complex authorization logic. For example, to retrieve the logged-in user's claims, you can inject IHttpContextAccessor:

```
public class CustomAuthorizeAttribute : Attribute
{
    private readonly IEnumerable<Claim> _claims;

    public CustomAuthorizeAttribute(IEnumerable<Claim> claims)
    {
        _claims = claims;
    }

    // Your authorization logic using _claims
}
```

Remember to configure the HttpContextAccessor for dependency injection in your Program.cs file:

builder.Services.AddHttpContextAccessor();

That's it! You've created a custom authorization attribute in ASP.NET Core 8. Feel free to adapt this example to your specific requirements. If you need more advanced scenarios, consider using policies and role-based authorization. Happy coding! 🚀
Let me know if you have any further questions or need additional assistance! 😊
