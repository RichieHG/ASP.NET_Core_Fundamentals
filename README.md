# ASP.NET Core Fundamentals
Repository to practice ASP.NET Core Fundamentals

## REST Verbs

* **GET** : Retrieve
* **POST** : Create
* **PUT** : Update (To Updte the entire object)
* **DELETE** : Remove
* **PATCH** : Update (To Updte an specific property of the object)

## [REST Status Codes](https://www.restapitutorial.com/httpstatuscodes.html)
* **1xx** : Information
* **2xx** : Success
* **3xx** : Redirection
* **4xx** : Client Error
* **5xx** : Server Error

## How to pass Parameters to an API Endpoint?
* From Route ​
* From Query / From Uri => ?id=5​
* From Body
* From Service -> Using Dependency Injection

**NOTE:** If we don't specify the way to pass parameters, NET will decide the type of param (FromPath, FromQuery)

## [Dependency Injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)

A *dependency* is an object that another object depends on. 

Dependency injection has the following aspects:
* Use of an interface or base class to abstract the dependency implementation.
* Registration of the dependency in a service container.
* Injection of the service into the constructor of the class where it's used. *The framework takes on the responsibility of creating an instance of the dependency and disposing of it when it's no longer needed.*

### [Service Lifetimes](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes)

#### Transient
When we use Transient lifetime, our services are created each time they're requested from the service container.

* Register transient services with *AddTransient*.
* This lifetime works best for lightweight, stateless services. 
* In apps that process requests, transient services are disposed at the end of the request.

#### Scoped
For web applications, a scoped lifetime indicates that services are created once per client request (connection).

* Register scoped services with *AddScoped*.
* In apps that process requests, scoped services are disposed at the end of the request.
* Using Entity Framework Core, the AddDbContext extension method registers DbContext types with a scoped lifetime by default.

#### Singleton
When we use Singleton, every subsequent request of the service implementation from the dependency injection container uses the same instance.

* Register singleton services with *AddSingleton*.
* If the app requires singleton behavior, allow the service container to manage the service's lifetime.
* Don't implement the singleton design pattern and provide code to dispose of the singleton.
* Services should never be disposed by code that resolved the service from the container.
* If a type or factory is registered as a singleton, the container disposes the singleton automatically.
* Singleton services must be thread safe and are often used in stateless services.
* In apps that process requests, singleton services are disposed when the ServiceProvider is disposed on application shutdown.
* Because memory is not released until the app is shut down, **consider memory use with a singleton service**.

Singleton lifetime services are created either:

* The first time they're requested.
* By the developer, when providing an implementation instance directly to the container. This approach is rarely needed.

**NOTE**

Do not resolve a *scoped* service from a *singleton* and be careful not to do so indirectly, for example, through a *transient service*. It may cause the service to have incorrect state when processing subsequent requests. It's fine to:

* Resolve a *singleton service* from a *scoped* or *transient* service.
* Resolve a *scoped* service from another *scoped* or *transient* service.