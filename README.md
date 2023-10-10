# Simple Authentication API
This is a basic authentication API example that illustrates the functioning of authentication and authorisation within a .NET API 6. This particular API leverages JWT (JSON Web Tokens) and Entity Framework Core to enable user registration and authentication within the application.

## Prerequisite
 - Basic Knowledge of .Net Web API 6.0
 - SOLID Principles
 - Dependency Injection
 - ORM e.g EF Core


## Key Concepts
### JWT (JSON Web Tokens)
JSON Web Tokens are a compact, URL-safe means of representing claims to be transferred between two parties. In the context of authentication, JWTs are often used to securely transmit information between a client and a server. They consist of three parts: a header, a payload, and a signature.

### Entity Framework Core
Entity Framework Core is an Object-Relational Mapping (ORM) framework that enables developers to work with databases using .NET objects. It simplifies database operations, including data retrieval, insertion, and updates, by allowing developers to interact with databases using C#.

### Authentication
This is a process which is used to verify a user's identity. During this process, the user is typically requested to provide either their username or their email and password. If the provided password matches the associated username or email, the user is granted access to the application.

For example, you decided to visit a restaurant. The restaurant is based on reservations, so when you arrive, the host will ask for your **name** and **reservation details** to verify your reservation. If your name matches the reservation, you will be granted access to a table. This process is called **Authentication**. If you have a reservation, then the host will direct you to your table but if you don’t the host will not grant you access to your table.

### Authorisation
Authorisation is the process of determining what actions a user is allowed to perform after they have been authenticated. It involves checking the user's role or permissions and comparing it with the requested action.

Proceeding with the restaurant example, After the host has confirmed that your reservation was successful. The host will lead you to your assigned table. The table is one of the resources available to users. As a diner, you can order drinks and meals and pay your expenses.  Some resources like cooking and serving are not eligible to diners. This is process of limiting resources is called Authorisation.

### [Learn More](https://github.com/Adexandria/Authentication_App/wiki/01.-Authentication)
