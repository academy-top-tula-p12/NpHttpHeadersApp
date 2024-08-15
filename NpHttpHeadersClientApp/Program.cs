using System.Net.Http.Json;

HttpClient client = new();
string url = "https://localhost:7028/";



// **** HEADERS
//client.DefaultRequestHeaders.Add("User-Agent", "Netscape");
//client.DefaultRequestHeaders.Add("Company", "Academy Top");
//client.DefaultRequestHeaders.Add("Author", "Maxim");

//using var response = await client.GetAsync(url);
//var text = await response.Content.ReadAsStringAsync();
//Console.WriteLine(text);


// POST STRING DATA
//StringContent content = new StringContent("Hello world");

////using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + "data");
////request.Content = content;
////using HttpResponseMessage response = await client.SendAsync(request);

//using HttpResponseMessage response = await client.PostAsync(url, content);
//string responseText = await response.Content.ReadAsStringAsync();

//Console.WriteLine(responseText);



// POST JSON DATA
//JsonContent content = JsonContent.Create(new Employee("Danny", 35));
//using var response = await client.PostAsync(url + "empl", content);
//

using var response = await client.PostAsJsonAsync(url, new Employee("Danny", 35));
Employee? employee = await response.Content.ReadFromJsonAsync<Employee>();

Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Age: {employee.Age}");


class Employee
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }
}