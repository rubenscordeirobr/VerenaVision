# 🚗 VerenaVision

> **An open-source AI-powered platform for real-time video analytics, Automatic Number Plate Recognition (ANPR), person and object detection, intelligent access control, and edge automation.**

VerenaVision combines **Computer Vision**, **Artificial Intelligence**, **IoT**, and **ASP.NET Core** to process live video streams, detect and classify objects, recognize license plates, identify people, automate physical devices, and distribute annotated video with low latency.

Designed with a modular architecture, VerenaVision can be deployed in parking facilities, gated communities, industries, logistics centers, warehouses, retail stores, and smart city environments.

---

# Vision

VerenaVision aims to become a complete **AI Video Analytics Platform**, capable of transforming ordinary IP cameras into intelligent sensors.

By combining computer vision with edge automation, the platform enables real-time decision-making and interaction with physical infrastructure.

---

# Core AI Modules

## 🚗 Vehicle Detection

* Cars
* Trucks
* Buses
* Motorcycles
* Vans
* Bicycles

---

## 🔢 Automatic Number Plate Recognition (ANPR)

* License plate localization
* OCR recognition
* Confidence scoring
* Authorized vehicle verification
* Detection history
* Duplicate suppression (planned)

---

## 👤 Person Detection

* Person localization
* Multi-person detection
* Entry/exit counting
* Restricted area monitoring
* Occupancy monitoring
* Intrusion detection

Future enhancements:

* Person tracking
* Re-identification
* PPE detection
* Safety monitoring

---

## 📦 Object Detection

VerenaVision supports generic object detection using YOLO models.

Examples include:

* Packages
* Backpacks
* Boxes
* Traffic cones
* Barriers
* Animals
* Tools
* Construction equipment
* Safety equipment
* Furniture
* Unknown abandoned objects

This capability allows the platform to be adapted to many industries without changing its architecture.

---

# AI Pipeline

```
Camera

↓

Capture Frame

↓

YOLO Detection

↓

┌───────────────┬────────────────┬────────────────┐

│               │                │

▼               ▼                ▼

Vehicle      Person          Generic Object

│               │                │

└───────────────┴────────────────┘

↓

Specialized Processing

↓

License Plate OCR

↓

Business Rules Engine

↓

Database

↓

Overlay Rendering

↓

FFmpeg

↓

MediaMTX

↓

Clients
```

---

# Intelligent Events

VerenaVision can generate events based on AI detections.

Examples:

* Authorized vehicle arrived
* Unauthorized vehicle detected
* Person entered restricted area
* Person count exceeded limit
* Object left unattended
* Package detected
* Gate obstruction detected
* Animal detected
* Motion detected
* Camera offline

Events can trigger automation workflows.

---

# Edge Automation

Supported automated responses include:

* Open gate
* Close gate
* Open barrier
* Turn green light on
* Turn red light on
* Turn yellow light on
* Turn blue light on
* Activate buzzer
* Activate siren
* Trigger relay outputs
* Send notifications
* Record snapshots
* Start video recording
* Execute custom workflows

---

# Future AI Modules

VerenaVision is designed around a plugin architecture, allowing new AI modules to be added independently.

Planned modules include:

* Face Detection
* Face Recognition
* Person Tracking
* Vehicle Tracking
* Vehicle Classification
* License Plate Recognition
* Pedestrian Counting
* Crowd Density Analysis
* Parking Occupancy Detection
* Wrong-Way Detection
* Speed Estimation
* Traffic Flow Analysis
* Fire Detection
* Smoke Detection
* Helmet Detection
* Safety Vest Detection
* PPE Detection
* Accident Detection
* Fall Detection
* Animal Detection
* Abandoned Object Detection
* Missing Object Detection
* Weapon Detection (where legally permitted)
* Queue Analysis
* Retail Analytics
* Warehouse Analytics

---

# Long-Term Vision

VerenaVision is intended to evolve into a modular **AI Video Analytics & Edge Automation Platform**, where a single processing pipeline can simultaneously detect vehicles, people, license plates, and arbitrary objects while controlling physical infrastructure through ESP32 devices and other edge controllers.

Its architecture enables organizations to automate access control, improve safety, monitor operations, and build intelligent environments using existing camera infrastructure.
