# AUA framework .Net 8 (CQS/CQRS-Domain-Driven Design(DDD))
AUA framework .Net 8 (CQS/CQRS)

# Asp.Net Unique Architecture
AUA ( Asp.Net Unique Architecture ) is a ready-to-use framework for ASP.NET Core with repositories, services, models mapping, user access, reporting, exception handling, webApi, and MVC,... Using the AUA framework, you can easily have better, faster, and more orderly and focused coding. This framework is based on new and up-to-date concepts, structures, and architectures, including Clean Architecture, Clean Code, Domain-driven design (DDD), Lmax Architecture, SOLID Principle, Code Refactoring, and GRASP (object-oriented design principle). Using the AUA ( Asp.Net Unique Architecture ) framework, you can easily have better, faster, and more orderly and focused coding. 

# AUA Login Info:
Username: admin
<br/>
Password: admin

# Dynamic Aggregate:

Programming today is all about costs. One of the most important challenges for software companies is performance.
In most cases, when designing the aggregates, we design the aggregates based on the initial requirements, but in the future, the requirements may change, and the aggregates may not be suitable to meet the future requirements.
And have complex query performance problems. Or even need to load additional data. And cause performance problems and complex queries. Or even need to load additional data. Also, the aggregate changes may spread across many parts of the software, increasing development time and cost.
In some cases, based on the type of database (SQL Server, MongoDB, ...), it may be necessary to change the fetching order of Entities in aggregates for performance purposes, or it is necessary to load a part of the aggregate.
In other words, an aggregate is suitable for one requirement and not suitable for other requirements, causing complexity in the design. In different scenarios, it is necessary to combine and load different aggregates.
To avoid such problems, it is suggested to design aggregates small, and you can use Dynamic aggregate in the AUA framework.

Dynamic aggregate allows you to combine aggregates and load them dynamically at runtime. Dynamic aggregate makes it possible to load data from different aggregates at high speed without changing the primary aggregates.
When reading data from different aggregates, it is recommended to use Dynamic aggregate to reduce the number of I/O.
<br/>
-Challenges with Traditional Aggregate Design:

   1.Changing Requirements: 
   Initial aggregate designs may not be suitable for future requirements, leading to performance issues and complex queries.

  2.Complex Query Performance:
   As aggregates grow or change, querying them can become complex and slow, affecting system performance.

   3.Data Loading: There might be a need to load additional data, which can further impact performance.

    4.Development Time and Cost: 
    Changes to aggregates can spread across different parts of the software, increasing development time and costs.

    5.Database Specifics:
    Depending on the type of database used (e.g., SQL Server, MongoDB), fetching order and loading requirements might need adjustments for performance optimization.

- Benefits of Dynamic Aggregate Design:

 1. Flexibility:
   Dynamic aggregates allow for combining and loading aggregates dynamically at runtime, adapting to changing requirements without altering primary aggregates.

   2. Performance Optimization: 
   By utilizing dynamic aggregates, you can reduce the number of I/O operations when reading data from different aggregates, improving system performance.

   3.  Reduced Complexity:
    Dynamic aggregates can help in simplifying the design by making it easier to adapt to various scenarios without overcomplicating the aggregate structure.

# Recommendations:

 1.Design Smaller Aggregates: 
  Instead of designing large, monolithic aggregates, it's beneficial to design smaller aggregates that can be combined dynamically as needed.

 2.Use Dynamic Aggregates:
   Adopting Dynamic Aggregate-DDD can help mitigate the challenges associated with evolving requirements and performance optimization.

In summary, Dynamic Aggregate-DDD offers a more flexible and adaptable approach to aggregate design, addressing the challenges of changing requirements, performance optimization, and complexity associated with traditional aggregate designs. By designing smaller aggregates and leveraging dynamic capabilities, you can build more resilient and efficient systems that can adapt to evolving business needs.

# DbContext
we use one dbContext for reading and writing based on this article.
<a  href='https://www.linkedin.com/pulse/cqrs-implementation-story-rahim-lotfi-ffy3f/?trackingId=ETZdQKTSTf6QYHDJG5dplw%3D%3D' target='_blank' >
CQRS Implementation Story
</a>

# UnitOfWork
UnitOfWork is a Runtime block, and it is created at runtime like the call stack and cannot be New manually. 
Otherwise, it becomes very difficult to manage different transaction states such as nested transactions, and certain scenarios cause Deadlock and extreme slowness.
This problem is well solved in the AUA Framework.


You can see the web site for more details. <br/>
Site : <br/>
https://auaframework.com/Document/Introduction

Video : <br/>
https://auaframework.com/Document/VideoTutorial

# Documentation is being completed...
