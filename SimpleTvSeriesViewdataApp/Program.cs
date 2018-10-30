using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SimpleTvSeriesViewdataApp
{
    // source https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.1
    public class Program
    {
        private static string url = "http://localhost:80";
        static void Main(string[] args)
        {
            if(args != null && args.Length == 1)
            {
                url = args[0];
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseUrls(url);

    }
}
