# 🍽️ Order Management System – Architecture Overview

## 🧱 Architecture Overview

The system is built using **Clean Architecture** utilizing **CQRS** and **DDD** approaches ensuring clear separation of concerns across the following primary layers:

- **Domain Layer**: Pure business logic and domain models.
- **Application Layer**: Use cases and service interfaces (CQRS applied).
- **Infrastructure Layer**: External systems and data access (via EF Core).
- **API Layer**: HTTP endpoints and controllers.

This architecture supports lose coupling, extensibility and testability across multiple layers while capturing complex business rules with clarity.

## 📐 Key Design Decisions

### ADR-01: Use of Clean Architecture
Adopted **Clean Architecture** to maintain a loosely-coupled, testable system. Interfaces in inner layers are implemented by outer layers, supporting CQRS and DDD principles.

### ADR-02: Use of relational database over NoSQL
Chose a **relational database** (SQL Server) due to the transactional, highly structured nature of the data and the need to enforce integrity and also exploit reporting and analytics capabilities

### ADR-03: Handling of order state transitions
Handled state transitions via polymorphic value objects. `PickupOrder` and `DeliveryOrder` subclasses encapsulate valid transitions through type-safety, preventing invalid states by design.

## ⚖️ Trade-offs & Alternatives

| Decision Area | Choice | Alternative | Trade-off |
|---------------|--------|-------------|-----------|
| Architecture | Clean Architecture | Traditional 3-layer, database centric | More upfront complexity |
| Persistence | Relational DB (SQL) | NoSQL | Sacrificed horizontal scaling for integrity & maturity |
| Order States | Value Objects + Subclasses | Shared Enum | Avoided risk of invalid state transitions |

## 🔮 Future-Proofing & Extensibility

- **Scalable Read Models**: CQRS opens the path for custom projections,  denormalized views and read-only data stores.
- **Eventual Messaging Support**: Clean separation makes it easy to introduce event publishing (e.g., order updates).
- **Cloud-native Ready**: Stateless design allows scaling API/infrastructure with ease.

---

## ➕ Optional Enhancements

### 📦 Deployment Diagram (Suggested Setup)
- **Azure App Service**: Hosts WebAPI
- **Azure SQL Database**: Primary data store
- **Azure DevOps**: CI/CD pipeline with build, test, deploy steps
- **Azure Monitor**: Logging and alerts

### 🌐 Integration Points 
Integration needs are depicted as separate projects in the **Infrastructure** layer
- **Identity Provider (e.g., EntraID)**: For authentication/authorization 
- **Payment Processor (e.g., Stripe, Paypal)**: For order payments 
- **Map API (e.g., Google Maps)**: For delivery and route optimization
- **SMS/Email Providers (e.g., Twilio, SendGrid)**: For order status notifications

### 🚀 Performance & Scaling Concerns

| Bottleneck | Concern | Mitigation |
|------------|---------|------------|
| API Scalability | Many customer requests | Stateless design enables auto-scaling (App Service Plan) |
| DB Load | Relational joins on large datasets | Use CQRS: split read models optimized for query speed (start with views and later separate to read data stores) |
| Order Routing | Complex delivery routing | Use external Maps API |
| Delivery Assignment Blocking | Asynchonous handling | Offload to message queues (e.g RabbitMQ) |
| Caching | Data retrieval | Utilization of distributed cache systems (e.g Redis) |


---

