var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) => 
{
    context.Request.Headers.TryGetValue("User-Agent", out var userAgent);
    context.Request.Headers.TryGetValue("Company", out var company);
    context.Request.Headers.TryGetValue("Author", out var author);

    return $"User-Agent: {userAgent}\nCompany: {company}\nAuthor: {author}";
});

app.MapPost("/data", async (HttpContext context) =>
{
    using StreamReader reader = new(context.Request.Body);
    string data = await reader.ReadToEndAsync();

    return $"Data: {data}";
});

app.MapPost("/empl", (Employee employee) =>
{
    employee.Id = Guid.NewGuid().ToString();

    return employee;
});


app.Run();



class Employee
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
