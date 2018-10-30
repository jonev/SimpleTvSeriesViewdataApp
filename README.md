# SimpleTvSeriesViewdataApp
Loading data from csv file and displaying it in browser via ASP REST API.

Run the application:

Prerequisites
- .NET Core 2.1

Run
- dotnet SimpleTvSeriesViewdataApp.dll (runs on localhost:5000)
- dotnet SimpleTvSeriesViewdataApp.dll url:port (runs on selected url and port)

HttpGet's
- api/getAllSeriesIdAndViews
- api/getAllSeriesIdAndViewsSortedOnDate
- api/getAllSeriesIdViewdOnTv
- api/getTheMostPopularInYear2018
- api/getAllDataOnOneSeriesIdAtDate/{id}/{date}
