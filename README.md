# Teacher Workout

[![GitHub contributors](https://img.shields.io/github/contributors/code4romania/teacher-workout-backend.svg?style=for-the-badge)](https://github.com/code4romania/teacher-workout-backend/graphs/contributors) [![GitHub last commit](https://img.shields.io/github/last-commit/code4romania/teacher-workout-backend.svg?style=for-the-badge)](https://github.com/code4romania/teacher-workout-backend/commits/master) [![License: MPL 2.0](https://img.shields.io/badge/license-MPL%202.0-brightgreen.svg?style=for-the-badge)](https://opensource.org/licenses/MPL-2.0)

**Check out the [Wiki](https://github.com/code4romania/teacher-workout-backend/wiki)!**

Teacher Workout [was prototyped](https://civiclabs.ro/ro/solutions/teacher-workout) in [Civic Labs](https://civiclabs.ro/ro), the research and prototyping program in [Code for Romania](https://code4.ro/ro).

Teacher Workout is an application meant to deliver shot, interactive lessons. The themes of these lessons include identifying children who manifest a difficulty in learning, handling difficult classrooms situations, integrating children with particular needs in a classroom. These micro-courses are meant to help foster positive habits for teachers and professors alike.

The Teacher Workout ecosystem is composed of:

* [the backend](https://github.com/code4romania/teacher-workout-backend)
* [the web app](https://github.com/code4romania/teacher-workout-client)
* the two mobile apps, [one for Android](https://github.com/code4romania/teacher-workout-android) and [another one for iOS](https://github.com/code4romania/teacher-workout-ios)

The Teacher Workout prototype and UI is available [in the Figma project](https://www.figma.com/file/uLiqrlxmOB5xCppIzmiUXV/Teacher-Workout?node-id=0%3A1).

[Contributing](#contributing) | [Built with](#built-with) | [Repos and projects](#repos-and-projects) | [Deployment](#deployment) | [Feedback](#feedback) | [License](#license) | [About Code4Ro](#about-code-for-romania)

## Contributing

This project is built by amazing volunteers and you can be one of them! Here's a list of ways in [which you can contribute to this project](https://github.com/code4romania/.github/blob/master/CONTRIBUTING.md). If you want to make any change to this repository, please **make a fork first**.

Help us out by testing this project in the [staging environment](https://teacher.heroesof.tech/ui/graphiql). You can use a GraphQL client like [Insomnia](https://insomnia.rest/).
If you see something that doesn't quite work the way you expect it to, open an Issue. Make sure to describe what you _expect to happen_ and _what is actually happening_ in detail.

If you would like to suggest new functionality, open an Issue and mark it as a __[Feature request]__. Please be specific about why you think this functionality will be of use. If you can, please include some visual description of what you would like the UI to look like, if you are suggesting new UI elements.

## Built With

- love
- grahpql

### Programming languages

- c#
- kotlin
- swift
- js

### Platforms

- native mobile android and ios

### Frontend framework

- react

### Package managers

- npm

### Database technology & provider

- postgres

### API endpoints

- GraphQL Playground (available at `/ui/playground`)
- Swagger (available at `/swagger/index.html`)

## Repos and projects

- [web](https://github.com/code4romania/teacher-workout-client)
- [android](https://github.com/code4romania/teacher-workout-android)
- [ios](https://github.com/code4romania/teacher-workout-ios)

## Set Up
### Install Dependencies

- docker-compose >= v1.26.2
- docker >= v20.10.7

### Start DB server
```
docker-compose up # and stop
docker start teacher_workout_db
```
TODO: decouple docker-compose in development from staging 

### Run migrations
```
dotnet ef database update --startup-project TeacherWorkout.Api/ --project TeacherWorkout.Data/ --context TeacherWorkoutContext
```

Alternatively you can use the TeacherWorkout.Migrator project to apply migrations to all contexts at once.

### Start App
```
dotnet run -p TeacherWorkout.Api
```

## FAQ

### Add a migration
```
dotnet ef migrations add <MigrationNameGoesHere> --startup-project TeacherWorkout.Api/ --project TeacherWorkout.Data/ --context TeacherWorkoutContext
```

### Add a migration for a different context
```
dotnet ef migrations add <MigrationNameGoesHere> --context UserContext --project .\TeacherWorkout.Identity --startup-project .\TeacherWorkout.Api 
```

### Run tests
```
ASPNETCORE_ENVIRONMENT=Test dotnet test
```

### Apply migrations and seed data to your dev DB

Migrations will be applied using the Migrator in all environments when running the application with docker.

If dummy data is needed for development purposes just set the *SEEDDATA* to true in the .env file when running locally using docker. This will populate the DB with some dummy data on the first run. Subsequent runs will not re-seed if the data is already present.
```
SEEDDATA=true
```
Alternatively, you can run the following commands to only run the Migrator in your local environment as needed. 
```
cd TeacherWorkout.Migrator
dotnet run SeedData=false
```

To add a default admin account run the Migrator with the *SEEDUSERS* setting set to true.
```
SEEDUSERS=true
```

## Deployment
Guide users through getting your code up and running on their own system. In this section you can talk about:
1. Installation process
2. Software dependencies
3. Latest releases
4. API references

Describe and show how to build your code and run the tests.

## Feedback

* Request a new feature on GitHub.
* Vote for popular feature requests.
* File a bug in GitHub Issues.
* Email us with other feedback contact@code4.ro

## License

This project is licensed under the MPL 2.0 License - see the [LICENSE](LICENSE) file for details

## About Code for Romania

Started in 2016, Code for Romania is a civic tech NGO, official member of the Code for All network. We have a community of around 2.000 volunteers (developers, ux/ui, communications, data scientists, graphic designers, devops, it security and more) who work pro-bono for developing digital solutions to solve social problems. #techforsocialgood. If you want to learn more details about our projects [visit our site](https://www.code4.ro/en/) or if you want to talk to one of our staff members, please e-mail us at contact@code4.ro.

Last, but not least, we rely on donations to ensure the infrastructure, logistics and management of our community that is widely spread across 11 timezones, coding for social change to make Romania and the world a better place. If you want to support us, [you can do it here](https://code4.ro/en/donate/).
