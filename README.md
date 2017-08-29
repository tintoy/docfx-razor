## DocFX MVC / Razor demo

1. `dotnet restore`
2. `docfx build .\docfx-seed\docfx.json`
3. `dotnet run .\src\DocFXRazor\DocFXRazor.csproj`
4. Navigate to http://localhost:5000/site/index.html

The important bits are in [HomeController.cs](src/DocFXRazor/Controllers/HomeController.cs#L44-L66) and [Conceptual.cshtml](src/DocFXRazor/Views/Home/Conceptual.cshtml#L7-L15)

You could easily make classes for JSON.NET to deserialise the view-model into, and then you'll have intellisense and compile-time checking of model usage. Make some of the model properties of type [HtmlString](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.html.htmlstring) and you can just `@` them directly into the page rather than using `@Html.Raw()`.
