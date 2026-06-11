# 📚 Domain Model

# Overview

The VerenaVision domain model represents the business concepts involved in AI-powered video analytics, intelligent access control, and edge automation.

The domain layer is independent of infrastructure concerns such as databases, REST APIs, AI frameworks, or streaming technologies. It contains only business rules and domain behavior.

The model follows **Domain-Driven Design (DDD)** principles and is designed to support future expansion without breaking existing modules.

---

# Bounded Contexts

VerenaVision is organized into several bounded contexts.

```
VerenaVision

├── Camera Management

├── AI Detection

├── License Plate Recognition

├── Person Analytics

├── Object Analytics

├── Automation

├── Edge Devices

├── Security

├── Streaming

├── Notifications

└── Audit
```

---

# Core Domain Entities

## Camera

Represents a physical or virtual video source.

### Properties

| Property    | Description          |
| ----------- | -------------------- |
| Id          | Unique identifier    |
| Name        | Friendly name        |
| Description | Optional description |
| RTSPUrl     | Camera stream        |
| Username    | Authentication       |
| Password    | Authentication       |
| Enabled     | Active state         |
| Status      | Online/Offline       |
| LocationId  | Physical location    |
| Mark        | Brand (e.g., Hikvision, Dahua) |
| Model       | Camera model (e.g., DS-2CD1027G2H-LIU) |
| CreatedAt   | Creation timestamp   |
| UpdatedAt   | Last modification    |


### Relationships

```
Camera

├── Detections

├── Snapshots

├── Streams

└── StatusHistory
```

---

## Detection

Represents any AI-generated detection.

Every AI module creates Detection records.

### Properties

| Property      | Description             |
| ------------- | ----------------------- |
| Id            | Identifier              |
| CameraId      | Source camera           |
| Timestamp     | Detection time          |
| Confidence    | AI confidence           |
| FrameNumber   | Video frame             |
| BoundingBox   | Coordinates             |
| DetectionType | Vehicle, Person, Object |
| TrackingId    | Tracking session        |

---

## Vehicle

Represents a detected vehicle.

### Properties

* Id
* DetectionId
* VehicleType
* Color
* Confidence
* Direction
* Speed (future)
* TrackingId

### Vehicle Types

* Car
* Truck
* Bus
* Motorcycle
* Bicycle
* Van
* Trailer
* Unknown

---

## LicensePlate

Represents a recognized plate.

### Properties

* Id
* VehicleId
* Plate
* Country
* State
* Confidence
* OCRVersion
* DetectionTime

### Business Rules

* Plate cannot be empty.
* Confidence must be between 0 and 100.
* One vehicle may have multiple OCR attempts.
* Highest confidence result is considered the final result.

---

## Person

Represents a detected person.

### Properties

* Id
* DetectionId
* TrackingId
* Confidence
* Position
* Direction
* EnteredAt
* ExitedAt

### Future Extensions

* Re-identification
* Face association
* PPE status
* Employee identification

---

## ObjectDetection

Represents any detected object.

### Properties

* Id
* DetectionId
* ObjectClass
* Confidence
* BoundingBox

Examples:

* Backpack
* Package
* Chair
* Box
* Animal
* Traffic Cone
* Helmet
* Fire Extinguisher

---

## Snapshot

Represents an image captured from a detection.

### Properties

* Id
* DetectionId
* FileName
* StoragePath
* Width
* Height
* CreatedAt

Snapshots are immutable.

---

# Automation Context

## Device

Represents a controllable hardware device.

### Properties

* Id
* Name
* Type
* IPAddress
* Enabled
* FirmwareVersion
* LastSeen
* Status

### Device Types

* ESP32
* PLC
* Relay Board
* Smart Switch
* MQTT Device

---

## DeviceAction

Represents an executable action.

### Examples

* OpenGate
* CloseGate
* GreenLightOn
* RedLightOn
* YellowLightOn
* BlueLightOn
* ActivateBuzzer
* ActivateSiren
* ToggleRelay

---

## AutomationRule

Represents a business rule.

Example:

```
IF

AuthorizedVehicleDetected

THEN

OpenGate

GreenLightOn

BeepBuzzer
```

Automation rules are configurable and independent from AI models.

---

## AutomationEvent

Represents the execution of an automation rule.

### Properties

* Id
* RuleId
* DeviceId
* Action
* ExecutedAt
* Success
* Response

---

# Authorization Context

## AuthorizedVehicle

Represents a vehicle allowed to enter.

### Properties

* Id
* Plate
* Owner
* Description
* Enabled
* ValidFrom
* ValidUntil

Business rule:

Only enabled and valid registrations grant access.

---

## Visitor

Represents temporary access.

### Properties

* Id
* Name
* Plate
* Host
* ValidUntil

---

# AI Context

## AIModel

Represents an installed AI model.

### Properties

* Id
* Name
* Version
* Framework
* Enabled
* Type
* Path

Examples:

* YOLO11n
* YOLO11s
* YOLO11m
* PaddleOCR
* CustomModel

---

## InferenceSession

Represents one AI execution.

### Properties

* Id
* ModelId
* StartedAt
* FinishedAt
* Duration
* FPS
* GPUUsage

Used for diagnostics and performance monitoring.

---

# Streaming Context

## Stream

Represents a processed output stream.

### Properties

* Id
* CameraId
* OutputUrl
* Codec
* Resolution
* FPS
* Enabled

---

## StreamClient

Represents a consumer.

Examples:

* Browser
* VLC
* Mobile
* Smart TV

---

# Location Context

## Location

Represents a physical place.

### Properties

* Id
* Name
* Description
* Latitude
* Longitude

Examples:

* Main Gate
* Parking Lot
* Warehouse
* Building A
* Reception

---

# Notification Context

## Notification

Represents a generated notification.

### Types

* Email
* SMS
* Push
* Webhook
* MQTT
* WebSocket

Triggered by business events.

---

# Audit Context

## AuditLog

Stores all important operations.

### Properties

* Id
* User
* Action
* Entity
* EntityId
* Timestamp
* Details

Audit logs are immutable.

---

# Relationships

```
Location

│

├──────── Camera

│              │

│              ├──────── Detection

│              │              │

│              │              ├──── Vehicle

│              │              │          │

│              │              │          └── LicensePlate

│              │              │

│              │              ├──── Person

│              │              │

│              │              └──── ObjectDetection

│              │

│              └──────── Snapshot

│

├──────── Stream

│

└──────── Device

                │

                ├──── DeviceAction

                │

                └──── AutomationEvent
```

---

# Aggregate Roots

The following entities are aggregate roots:

* Camera
* Device
* AuthorizedVehicle
* AutomationRule
* Location
* AIModel
* Stream

Child entities must be modified through their aggregate root.

---

# Domain Events

Examples:

* CameraConnected
* CameraDisconnected
* VehicleDetected
* PersonDetected
* ObjectDetected
* LicensePlateRecognized
* AuthorizedVehicleDetected
* UnauthorizedVehicleDetected
* AutomationExecuted
* DeviceOffline
* DeviceOnline
* StreamStarted
* StreamStopped

Domain events enable future event-driven and microservice architectures.

---

# Value Objects

Examples:

## BoundingBox

```
X

Y

Width

Height
```

Immutable.

---

## GeoCoordinate

```
Latitude

Longitude
```

Immutable.

---

## Resolution

```
Width

Height
```

Immutable.

---

## ConfidenceScore

```
Value (0-100)
```

Validates confidence limits and prevents invalid states.

---

# Future Extensions

The domain model has been designed to support future capabilities without breaking existing entities.

Planned additions include:

* Face Recognition
* Person Re-identification
* Vehicle Tracking
* Parking Occupancy
* Speed Estimation
* Queue Analysis
* Crowd Analytics
* Fire Detection
* Smoke Detection
* Fall Detection
* Weapon Detection
* Retail Analytics
* Warehouse Analytics
* Smart City Integrations

---

# Domain Philosophy

The VerenaVision domain model separates **business knowledge** from **technical implementation**.

Infrastructure technologies such as Entity Framework Core, PostgreSQL, ONNX Runtime, MediaMTX, FFmpeg, MQTT, or ESP32 communication are implementation details built around the domain—not the other way around.

This approach ensures long-term maintainability, extensibility, and adaptability as VerenaVision evolves into a comprehensive AI Video Analytics and Edge Automation Platform.
