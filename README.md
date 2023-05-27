
# Stytch .NET Library

This library is still in development. Not all features that are provided by Stytch are implemented. It's built with .NET 7

The Stytch .NET library makes it easy to use the API that is provided by Stytch.

## Currently available
- [X] Email Magic Links

## Install

To install this package run

```bash
dotnet add package ......
```

## Usage
 You can find your API credentials in the [Stytch Dashboard](https://stytch.com/dashboard/api-keys)

- ProjectId
- Secret
- Environment

## Example

In your Startup.cs / Program.cs you can inject the following service:

`services.AddStytch(projectId, secret, environment)`
