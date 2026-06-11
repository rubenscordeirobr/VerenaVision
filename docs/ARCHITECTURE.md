# 🏗️ VerenaVision Architecture

# Overview

VerenaVision is a modular AI Video Analytics platform built using **Clean Architecture**, **Domain-Driven Design (DDD)**, and **event-driven principles**.

The system is designed to process multiple real-time camera streams, execute AI inference, automate physical devices, expose REST APIs, and scale horizontally as demand increases.

---

# High-Level Architecture

```
                    ┌───────────────────────┐
                    │     IP Cameras        │
                    │    RTSP / ONVIF       │
                    └──────────┬────────────┘
                               │
                               ▼
                 ┌────────────────────────────┐
                 │   Camera Processing Layer  │
                 └──────────┬─────────────────┘
                            │
                            ▼
              ┌───────────────────────────────┐
              │      AI Processing Layer      │
              └──────────┬────────────────────┘
                         │
        ┌────────────────┼──────────────────┐
        │                │                  │
        ▼                ▼                  ▼
 Vehicle Detection  Person Detection  Object Detection
        │                │                  │
        └────────────────┴──────────────────┘
                         │
                         ▼
                  License Plate OCR
                         │
                         ▼
                 Business Rules Engine ──────────────────────────┐
                         │                                       │
        ┌────────────────┼────────────────┐                      │
        │                │                │                      │
        ▼                ▼                ▼                      │
   Database      Automation Engine    REST API ◄─────────────────┤
                         │                ▲                      │
                         ▼                │                      │
                 ESP32 Controllers ───────┤                      │
                         │                │                      │
        ┌────────────────┼────────────────┐                      │
        │                │                │                      │
        ▼                ▼                ▼                      │
   Gate Relay      Signal Lights     Buzzer/Siren                │
                                                                 │
                 Overlay Renderer ───────────────────────────────┤
                         │                                       │
                         ▼                                       │
                  FFmpeg Encoder                                 │
                         │                                       │
                         ▼                                       │
                     MediaMTX                                    │
                         │                                       │
                         ▼                                       │
         Browser • Mobile • VLC • Smart TV                       │
                                                                 │
                    Dashboard ───────────────────────────────────┤
                                                                 │
                    Mobile App ──────────────────────────────────┘
```

---

# Architectural Principles

* Clean Architecture
* Domain-Driven Design
* SOLID Principles
* Dependency Injection
* Separation of Concerns
* Event-Driven Processing
* High Cohesion
* Low Coupling
* Modular AI Pipeline
* Horizontal Scalability

---

# Solution Structure

```
VerenaVision/

│

├── src/

│   ├── VerenaVision.Api/

│   ├── VerenaVision.Domain/

│   ├── VerenaVision.Application/

│   ├── VerenaVision.Infrastructure/

│   ├── VerenaVision.Camera/

│   ├── VerenaVision.AI/

│   ├── VerenaVision.Streaming/

│   ├── VerenaVision.Automation/

│   ├── VerenaVision.Edge/

│   └── VerenaVision.Shared/

│

├── firmware/

│   └── VerenaVision.Esp32/

│

├── models/

│   ├── yolo/

│   └── ocr/

│

├── docker/

├── docs/

├── scripts/

└── tests/

    ├── VerenaVision.UnitTests/

    └── VerenaVision.IntegrationTests/
```

---

# Layer Responsibilities

## VerenaVision.Api

Exposes REST endpoints.

Responsibilities:

* Authentication
* Authorization
* CRUD operations
* Health checks
* Swagger
* Configuration
* API versioning

Contains no business logic.

---

## VerenaVision.Domain

Contains the business model.

Includes:

* Entities
* Value Objects
* Enumerations
* Domain Events
* Interfaces
* Business Rules

No dependency on external libraries.

---

## VerenaVision.Application

Implements application use cases.

Contains:

* Commands
* Queries
* DTOs
* Validators
* Services
* Interfaces

Coordinates domain operations without infrastructure concerns.

---

## VerenaVision.Infrastructure

Implements external dependencies.

Contains:

* Entity Framework Core
* Repositories
* Database migrations
* Serilog
* File storage
* Configuration providers

---

## VerenaVision.Camera

Responsible for camera communication.

Features:

* RTSP capture
* ONVIF discovery (future)
* Camera health monitoring
* Frame extraction
* Reconnection strategy

Each camera runs independently.

---

## VerenaVision.AI

Core AI processing module.

Contains:

* YOLO inference
* ONNX Runtime
* Detection pipeline
* Tracking
* OCR integration
* AI model management

This project is isolated so AI models can evolve independently.

---

## VerenaVision.Streaming

Responsible for video distribution.

Contains:

* FFmpeg integration
* Frame encoding
* Overlay rendering
* RTSP publishing
* MediaMTX communication

---

## VerenaVision.Automation

Business automation engine.

Examples:

* Open gate
* Close gate
* Turn signal lights on/off
* Trigger alarms
* Execute workflows
* Generate notifications

Rules are centralized here.

---

## VerenaVision.Edge

Communication with embedded devices.

Supports:

* ESP32
* REST
* MQTT
* WebSocket (future)
* Device monitoring
* Device provisioning

---

## VerenaVision.Shared

Shared abstractions.

Contains:

* Constants
* Extensions
* Exceptions
* Common DTOs
* Utility classes

---

# AI Pipeline

```
Frame

↓

YOLO Detection

↓

Vehicle

Person

Object

↓

Tracking

↓

License Plate Detection

↓

OCR

↓

Business Rules

↓

Automation

↓

Persistence

↓

Overlay

↓

Streaming
```

---

# Camera Processing Model

Each camera executes independently.

```
Camera 1

↓

Worker 1

↓

Inference

↓

Database

↓

Streaming

--------------------------------

Camera 2

↓

Worker 2

↓

Inference

↓

Database

↓

Streaming

--------------------------------

Camera N

↓

Worker N

↓

Inference

↓

Database

↓

Streaming
```

A failure in one worker does not affect the others.

---

# Domain Model

```
Camera

Detection

Vehicle

Person

ObjectDetection

LicensePlate

Snapshot

AuthorizedVehicle

AutomationEvent

Device

DeviceAction

User

Role

AuditLog
```

---

# Edge Automation

```
Business Rule

↓

Automation Service

↓

Device Command

↓

ESP32

↓

Relay

↓

Gate

↓

Signal Light

↓

Buzzer

↓

Physical World
```

---

# Deployment Architecture

```
                 Internet

                     │

                     ▼

            Reverse Proxy

                     │

                     ▼

             ASP.NET Core API

                     │

        ┌────────────┼────────────┐

        │            │            │

        ▼            ▼            ▼

   PostgreSQL    MediaMTX     File Storage

        │

        ▼

 Camera Workers

        │

        ▼

 AI Processing

        │

        ▼

 ESP32 Controllers
```

---

# Future Microservices

```
VerenaVision.Api

VerenaVision.Camera.Service

VerenaVision.AI.Service

VerenaVision.Streaming.Service

VerenaVision.Automation.Service

VerenaVision.Notification.Service

VerenaVision.Edge.Service
```

Each service can be deployed independently when horizontal scaling becomes necessary.

---

# Scalability Strategy

## Vertical Scaling

* More CPU
* More RAM
* GPU acceleration
* Faster storage

---

## Horizontal Scaling

* Multiple AI workers
* Multiple streaming nodes
* Load-balanced APIs
* Distributed databases
* Distributed message queues

---

# Design Goals

* Maintainable
* Testable
* Extensible
* High Performance
* Fault Tolerant
* Cloud Ready
* Container Friendly
* AI Agnostic
* Hardware Agnostic

---

# Long-Term Vision

VerenaVision is designed to become a complete **AI Video Analytics and Edge Automation Platform**, capable of transforming any IP camera into an intelligent sensor that detects vehicles, people, objects, and events while seamlessly integrating with physical infrastructure through IoT devices.

Its modular architecture enables the addition of new AI models, automation workflows, and hardware integrations without impacting existing components, ensuring long-term scalability and adaptability for enterprise and smart city deployments.
