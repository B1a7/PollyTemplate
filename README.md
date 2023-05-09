
# PollyTemplate

The repository contains an example of how to use the Polly nuget package and how to define an error handling policy



## Structure

- **RequestService**
 It is a simple service which contains one controller with policy retring request. Policy is in *ClientPolicy.cs* class:
 ```csharp
    public ClientPolicy()
    {
        // send request since get right status or reach the limit
        ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
            res => !res.IsSuccessStatusCode)
            .RetryAsync(5);
    ...
```

- **ResponseService** 

Is a service which emulates random response status code.
## Tech Stack

- **.NET 6** 
- **ASP.NET** 

## Nuget packages

- **Microsoft.Extensions.Http.Polly** v7.0.5
