# RCBridgeProject

## 🚀 Overview

RCBridgeProject is a C# application that connects an RC transmitter to a virtual flight control pipeline. It reads live input from a USB-connected transmitter (such as a TX16S), converts it into standard RC channel values (1000–2000), and prepares the data for integration with flight controller firmware such as INAV or Betaflight.

This project explores the bridge between simulation and real-world flight control systems, enabling testing and experimentation without requiring full onboard sensor hardware.

---

## 🧠 How It Works

```
RC Transmitter (TX16S)
        ↓
USB HID (Windows Joystick)
        ↓
C# Application (DirectInput)
        ↓
RC Channel Mapping (1000–2000)
        ↓
(Future) SBUS / Serial Output
        ↓
Flight Controller (INAV / Betaflight)
```

---

## 🔧 Technologies Used

* **C# (.NET 8)**
* **SharpDX.DirectInput** (HID / joystick input)
* Console-based application architecture
* Real-time input polling and processing

---

## 🎯 Current Features

* Detects joystick and gamepad devices
* Reads live transmitter input via USB
* Displays raw axis values
* Converts input into standard RC channel values:

  * 1000 → minimum
  * 1500 → center
  * 2000 → maximum
* Menu-driven interface for testing and debugging

---

## 📂 Project Structure

```
RCBridgeProject/
│
├── Program.cs                 # Entry point
├── Menu/
│   └── MenuManager.cs         # Console UI and navigation
├── Input/
│   └── JoystickService.cs     # Device detection and input handling
├── BusinessClasses/
│   └── RcMapper.cs            # Axis → RC channel conversion logic
├── stylecop.json              # Code style configuration
└── RCBridgeProject.csproj
```

---

## 🕹️ Example Output

```
=== RC VALUES ===

Roll: 1502
Pitch: 1490
Throttle: 1020
Yaw: 1510
```

---

## 💡 Design Goals

* Separate input handling from transformation logic
* Keep code modular and extensible
* Mirror real RC signal behavior
* Provide a foundation for hardware integration

---

## 🚧 Planned Features

* SBUS protocol encoder (16-channel packed output)
* Serial COM port output for flight controllers
* Integration with INAV / Betaflight
* Configurable channel mapping (axis selection)
* Deadband and calibration system
* Profile-based transmitter configurations

---

## 🧪 Use Cases

* Testing RC behavior without physical aircraft
* Bridging simulation (e.g., RealFlight) to flight controller logic
* Experimenting with control algorithms
* Learning embedded / RC signal pipelines

---

## ⚠️ Limitations

* No sensor simulation (gyro, accelerometer) yet
* No direct flight controller communication (SBUS pending)
* Axis mapping may vary depending on transmitter configuration

---

## 🔍 Future Direction

The long-term goal of this project is to act as a **software bridge between simulation environments and real flight controller firmware**, enabling:

* Hardware-in-the-loop (HITL) style testing
* Rapid prototyping of control systems
* Simulation-driven tuning of RC behavior

---

## 👤 Author

**Chris Mathis**
MathisSystems.com

---

## 📌 Notes

This project is intended as a learning and experimentation platform combining software engineering with RC and embedded systems concepts.

---

## ⭐ Why This Project Matters

Most beginner projects focus on basic applications. This project instead explores:

* Real-time input systems
* Hardware abstraction
* Signal transformation pipelines
* Embedded system concepts in a desktop environment

It demonstrates the ability to design systems that interact with real-world hardware and protocols.

---
