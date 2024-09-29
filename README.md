# Repository Pattern and Unit of work

## What Repositories

Repositories are classes or components that encapsulate the logic required to access persistence store. and used to perform database operations for domain objects (Entity and Value types)

## What Repository Pattern

The Repository pattern is a design pattern that abstracts the data access layer of an application, providing a centralized location for data storage and retrieval. It acts as an abstract layer between the business logic and the data storage, allowing for decoupling of the two.

Repositories are classes or components that encapsulate the logic required to access persistence store.
Your repository may be based on a database, an XML file, a text document, a web service, or anything. 

- **Generic Repository Pattern**: is used to provide common database operations for all database entities in a single class, such as CRUD operations
- **Non-Generic Repository Pattern**: is used to provide database operations for a specific database entity, such as CRUD operations for a specific table in the database.

### Why to use Repository Pattern

- **Decoupling**: The Repository pattern helps to decouple the business logic from the data storage
- **Abstraction**: It abstracts the data access layer, making it easier to switch between different data storage technologies
- **Testability**: Repositories make it easier to write unit tests for your application
- **Reusability**: Repositories can be reused across multiple applications and domains
- **Flexibility**: Repositories can be easily extended or modified without affecting the rest of the application
- **Separation of Concerns**: Repositories separate the data access logic from the business logic
- **Easier Maintenance**: Repositories make it easier to maintain and update the data access layer
- **Improved Scalability**: Repositories can be easily scaled to handle large amounts of data and traffic
- **Improved Performance**: Repositories can improve the performance of your application by reducing the number of database queries and improving data retrieval efficiency
- **Improved Security**: Repositories can improve the security of your application by providing a single point of access to the data storage, making it easier to implement security measures such as authentication and authorization.

## What is Unit of work Uow

The Unit of Work pattern is a design pattern that keeps track of changes made to objects in a system
and writes them to the database in a single, all-or-nothing transaction.

it aggregate all Repository transactions into a single transaction. Only one commit will be made for all modifications.
If any transaction fails to assure data integrity, it will be rolled back.

### why to use Unit of work

- **Atomicity**: Ensures that all changes are committed or rolled back as a single, indivisible unit
- **Consistency**: Ensures that the database remains in a consistent state, even in the event of a failure
- **Isolation**: Ensures that multiple transactions do not interfere with each other
- **Durability**: Ensures that once a transaction is committed, its effects are permanent and cannot be rolled back.

## Enhanced Repository Pattern

### Separation of concern Queries and commands repository

- **Queries**: are used to retrieve data from the database
- **Commands**: are used to modify data in the database

### Pagination of retrieved Data

- Use AsNoTracking in getting data to improve performance
- Use Skip and Take to implement pagination

### Use separated repository for lookup data

### Improve GetAll

- Use AsNoTracking in getting data to improve performance
getAll that return IQueryable is a bad practice because it allow the  implementor to make extend the  queries that override the separation of concern and also break clean architecture rules
