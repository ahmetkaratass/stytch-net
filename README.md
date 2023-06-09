
# Stytch .NET Library

This library is still in development. Not all features that are provided by Stytch are implemented. It's built with .NET 7

The Stytch .NET library makes it easy to use the API that is provided by Stytch.

## Currently available
- [X] Email Magic Links

## Install
Nuget link: https://www.nuget.org/packages/StytchAuth

To install this package run
```bash
dotnet add package StytchAuth
```

## Usage
 You can find your API credentials in the [Stytch Dashboard](https://stytch.com/dashboard/api-keys)

- ProjectId
- Secret
- Environment

## Example

In your Startup.cs / Program.cs you can inject the following service:
```c#
using StytchAuth.Extensions;

.....

services.AddStytchAuth(projectId, secret, environment);
```

You can create a controller, for example `MagicLinkController` and have something like this:
```c# 
public class MagicLinkController : ControllerBase
{
    private readonly IMagicLinkService _magicLinkService;

    public MagicLinkController(IMagicLinkService magicLinkService)
    {
        _magicLinkService = magicLinkService;
    }

    [HttpPost("LoginOrCreate")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LoginOrCreate([FromQuery] string email)
    {
        var response = await _magicLinkService.LoginOrCreate(new LoginOrCreateParams(email));
        if (response.IsSuccessStatusCode)
        {
            // ...............
            return Ok();
        }
        return BadRequest();
    }
}
```