<h1 align="center">👾 Nexus Back-end</h1>

<p align="center">
  Nexus is a simple ecommerce to show my skills with .NET, here you find things like CQRS, SOLID, Clean Code,...
</p>


_**"⚠️ The readme is not complete yet, over the days I will still finish it"**_

# Get Started

- For you to use the system you must have <a href="https://dotnet.microsoft.com">.NET 5</a> installed
- With .NET installed, you should now download the project and run command below from the root of the project. This command will cause the dependencies from project to be downloaded

```
  dotnet restore
```

- After the previous steps, you can use one of the commands below inside the **Backend.Domain.Api** folder

  First command. He will run the API and you can use, this command is the more simple
  ```
    dotnet run
  ```
  
  Second command. Here it will open Swagger and you can see the controllers urls
  ```
    dotnet watch run
  ```

# Architecture

The project is divided in 5 parts being them

| Directory         | Contents|
| -                 | -|
| `Backend.Domain/` | Application Domain |
| `Backend.Domain.Api/`| Application Web API |
| `Backend.Domain.Infra/`| Application Infra |
| `Backend.Domain.Shared/`| Application Shared |
| `Backend.Domain.Tests/`| Application Tests |

## Domain

The Domain contain the business rule, it will have the inputs, outups, validations,... He is divided in 6 parts because the CQRS idea is applied, she said i should separate the inputs from outputs

- _what are inputs?_ Inputs are creations, updates and removals. Summary, everything that changes the state

- _what are outputs?_  The outputs are clearer, it's what needs to be found and/or consulted

**Entities**

Entities contain classes that are responsible for holding the objects that represent that class.

Example:

All entities extends the Entity class because it generates the Id as Guid, see the constructor her

```
...
protected Entity() => Id = Guid.NewGuid();
...
```

The objects from name to role only has get due to the second principle of SOLID, _(open and closed principle)_, all objects must be open for extension, but closed for change, the list is a different case, it cannot have just one get because being a class it is still possible to have access to its methods, which include the add method, so we pass an IEnumerable that will return a private list with the differential that it does not allow changes but only the view

```
...
namespace Backend.Domain.Entities
{
    public class User : Entity
    {
        private readonly IList<Buy> _buys;
        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            _buys = new List<Buy>();
        }

        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        public IEnumerable<Buy> Buys => _buys == null ? new List<Buy>() : _buys.ToArray();
    }
}
```

**Commands**

The commands are intended to serve as a form of input validation and verification, 
then all commands extend the ICommand interface to implement the Valid method

```
  ...
  public bool Valid()
  {
    ...
  }
  ...
```

**Repositories**

the Repositories are interfaces that will be implemented in the future with dependency injection, tt will contain the methods to complete the required task

Example:
```
  ...
  public interface IUserRepository
  {
    public void Create(User user);
    public Task<bool> CheckEmail(string email);
    public Task<User> Login(string email, string password);
  }
```

**Handlers**

Handlers are classes that delegate what each one will do and have a filter to implement the commands, this filter
obtained through ICommandHandler

Example:
```
  public class UserHandler : Notifiable, ICommandHandler<CreateUserCommand>
```

It also passes the repository through the constructor to be deployed in the future

Example:
```
  ...
  private readonly IUserRepository _repository;

  public UserHandler(IUserRepository repository) => _repository = repository;
  ...
```

Example of delegation

```
  ...
  public ICommandResult Handle(CreateUserCommand command)
  {
      if(!command.Valid())
          AddNotifications(command.Notifications);

      if(!_repository.CheckEmail(command.Email).Result)
          AddNotification("Email", "This email is already in use");

      var password = new Password(command.Password);

      AddNotifications(password.Notifications);

      if (Invalid)
          return new GenericCommandResult(
              false, "Please correct the fields below",
              Notifications
              );

      var model = new User(command.Name, command.Email, password.Address, command.Role);

      _repository.Create(model);

      return new GenericCommandResult(true, "User created successfully", model);
  }
  ...
```

**Queries**

Queries are filters to find something

Example:
```
  ...
  public static Expression<Func<User, bool>> Login(string email, string password)
    => x => x.Email == email && x.Password == password;
  ...
```

## Infra

The repositories built in the domain are implemented below


**Mapping**

in mapping is where the database table columns are defined

**Data**

In the data, the mapping will be implemented and the DbSet created, it will allow the main methods to be used, creating, searching, changing and deleting

**Repositories**

In the repository, the data is passed in the constructor to be implemented in the future with dependency injection and it is also responsible for implementing the respective interface methods

## Api

**Controllers**

The controllers are the means of communication with frontends or some other api.

_First_ the code snippet below is passed to define that class as an endpoint

Example:
```
  ...
  [ApiController]
  [Route("v1/user")]
  public class UserController : ControllerBase
  ...
```

_Second_ each endpoint has a set of other endpoints defined by methods (POST, GET, PUT, DELETE), 
each of them has its own route and who can access it

example:
```
  ...
  [HttpPost("create")]
  [AllowAnonymous]
  public ActionResult<GenericCommandResult> Create([FromServices] UserHandler handler, [FromBody] CreateUserCommand command)
  ...
```