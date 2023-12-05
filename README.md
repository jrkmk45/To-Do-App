# A simple ASP.NET MVC To Do application with Ajax and Docker support
Live preview link: <http://3.67.184.190/>

# Getting started
Run locally via docker compose

1. Clone repository to a desired folder, run in console `git clone git@github.com:jrkmk45/To-Do-App.git`
2. Build and run docker containers - run in console: `docker-compose up` in project's root directory
3. Apply migrations to database - run in console `dotnet ef database update` in `ToDoApp` directory, or `update-database` in Visual Studio package manager console
4. Open <http://localhost/> in browser