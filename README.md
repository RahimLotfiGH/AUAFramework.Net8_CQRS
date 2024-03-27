# AUA framework .Net 8 (CQS/CQRS)
AUA framework .Net 8 (CQS/CQRS)

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


# UnitOfWork
UnitOfWork is a Runtime block, and it is created at runtime like the call stack and cannot be New manually. 
Otherwise, it becomes very difficult to manage different transaction states such as nested transactions, and certain scenarios cause Deadlock and extreme slowness.
This problem is well solved in the AUA Framework.
