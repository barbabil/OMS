# ADR-002: Use of Relational Database Over NoSQL

## Context
The Order Management System (OMS) must track structured, transactional data such as orders, customers and menu items. The data model contains strict relationships with predefined schemas that will benefit from integrity constraints. 

## Decision
We decided to use a **relational database** (e.g., SQL Server) as the primary data store. Relational databases and management systems (RDBMS) offer:
- Strong data consistency with ACID transactions that ensures data integrity
- Data integrity and normalization as they can avoid data duplication and ensure data consistency. Foreign keys enforce referential integrity between related tables.
- Powerful Querying with SQL as the Structured Query Language provides a powerful, standardized query language for complex queries, joins, and aggregations, making it suitable for structured data with complex relationships.
- Mature ecosystem as relational databases are well-established with extensive tools, libraries, and community support. 

NoSQL was considered but deemed unnecessary since:
- The domain does not involve semistructured or unstructured elements (e.g. posts), or may involve very few with minor significance.
- Integrity and relationships are core to the model.

## Consequences
- **Pros**:
  - A relational database and SQL is a natural fit for this domain.
  - We will utilize the RDBMSs extensive reporting and analytics capabilities

- **Trade-offs**:
  - Scaling horizontally (across multiple servers) is more complex and often less efficient in RDBMSs, which generally scale vertically by adding more resources to a single server
  - This concern can be addressed through indexing and read models if needed later.