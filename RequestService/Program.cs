using RequestService.Policies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient("TestClient").AddPolicyHandler(
        request => request.Method == HttpMethod.Get ? new ClientPolicy().ImmediateHttpRetry : new ClientPolicy().LinearHttpRetry
    );
builder.Services.AddSingleton<ClientPolicy>(new ClientPolicy());

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
