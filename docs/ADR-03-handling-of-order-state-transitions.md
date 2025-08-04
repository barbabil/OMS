# ADR-03: Handling of Order State Transitions by using Value Objects

## Context
The Order Management System (OMS) must handle the state transisions of each order. These are actually transitions among different order statuses. We identified two separate types of orders (**Pickup Orders** and **Delivery Orders**) each one with the following typical state transitions :

- **Pickup Orders**: Progress through `"Pending" → "Preparing" → "Ready for Pickup"`.
- **Delivery Orders**: Progress through `"Pending" → "Preparing" → "Ready for Delivery" → "Out for Delivery" → "Delivered"` (or `"Unable to Deliver"`).

These lifecycles are **mutually exclusive**. A delivery order will never reach “Ready for Pickup”, and a pickup order will never be “Out for Delivery.” Modeling all statuses in a single shared enum creates the risk of invalid states and transition bugs.

## Decision
We introduce an abstract base `Order` class with two concrete sub-classes:
- `PickupOrder : Order`
- `DeliveryOrder : Order`

Each subclass encapsulates its own **`OrderStatus` value object**. These value objects:
- Contain only valid states for their order type.
- Expose **type-safe transitions** (`ToPreparing()`, `MarkAsReady()`, etc.).
- Prevent invalid transitions by desing.

The abstract base class `Order` does not contain the `OrderStatus` property directly. Status will be the responsibility of the subclasses.

This aligns with Domain-Driven Design principles, where behavior belongs to aggregates and value objects — not to data transfer objects (DTOs) or primitive enums.

## Diagram (TODO)

## Consequences
- **Pros**:
  - Models the domain with clarity.
  - Prevents invalid states by design (e.g., pickup orders cannot marked as "Out for Delivery").
  - Enables polymorphic behavior and extensibility (e.g., adding another transition state later).
  - Keeps abstract class `Order` clean and abstracted from use-case-specific logic.

- **Trade-offs**:
  - Slight increase in code complexity and subclass management.
  - Requires clear interface or base contract if application services interact with both types.

