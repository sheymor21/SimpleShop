# SimpleShop

Simple API for Shop management management using .Net core, Docker and Dapper

# Dependencies

- .NET Core 8
- Dapper
- Entity Framework
# How to Run

If you don't have .Net download from  [.NET](https://dotnet.microsoft.com/en-us/download)

If you have .NET , download the project in your PC:

~~~
git clone https://github.com/sheymor21/SimpleShop.git
~~~

Before running the project write at the console for restore the dependencies:

~~~
dotnet restore
~~~

For run the project:

~~~
dotnet run
~~~

Or if you want the swagger interface use:

~~~
dotnet watch run
~~~

# How to run in Docker

If you don't have Docker yet, go to [Docker](https://www.docker.com/get-started/)

For create only the image of the application:

~~~
docker build . -t SimpleShop
~~~

# Author

- [sheymor21](https://github.com/sheymor21)
