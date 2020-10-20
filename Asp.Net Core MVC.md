

# Starter project creation 
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-3.1&tabs=visual-studio

# Scaffold model
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-3.1&tabs=visual-studio

# Work with a database
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/sql?view=aspnetcore-3.1&tabs=visual-studio


- Dependency injection comes deafult in .net core mvc.
           
           public void ConfigureServices(IServiceCollection services)
           {
                services.AddRazorPages();
                services.AddDbContext<RazorPagesMovieContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RazorPagesMovieContext")));
           }

connection string configured in appsettings.json  

# Add search to ASP.NET Core Razor Pages
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/search?view=aspnetcore-3.1
