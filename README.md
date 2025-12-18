# DVLD - Driving and Vehicle License Department System

###  Overview
DVLD is a comprehensive enterprise desktop application tailored for automating the management of driving licenses, tests, and vehicle registrations. It simulates a government-grade system handling complex workflows from applicant registration to license issuance (Local & International).

This project demonstrates a full software development lifecycle (SDLC) implementation, featuring a robust N-Tier Architecture, secure data handling, and a modern DevOps pipeline.

###  Architecture
The system follows a strict N-Tier Architecture to ensure separation of concerns:
* **Presentation Layer (PL):** Windows Forms (WinForms) for UI/UX.
* **Business Logic Layer (BLL):** C# Class Library handling rules (e.g., Age validation, License validity calculations, Save() logic routing).
* **Data Access Layer (DAL):** ADO.NET abstraction layer for communicating with SQL Server via Stored Procedures.
* **Database:** Microsoft SQL Server.

### 🔄 DevOps & CI/CD Pipeline (New)
To modernize the build process, I moved away from traditional VM-based builds.
* **Containerized Build Environment:** utilized Docker to run a Windows container (using dockur/windows).
* **CI/CD:** Configured GitHub Actions with a Self-Hosted Runner inside the Docker container.
* **Benefit:** This setup isolates the build environment, ensures dependency consistency, and drastically reduces infrastructure overhead compared to full VMs.

### 💻 Tech Stack
* **Language:** C# (.NET Framework)
* **Data:** MS SQL Server (T-SQL, Stored Procedures)
* **ORM/Access:** ADO.NET
* **DevOps:** Docker, GitHub Actions, Self-Hosted Runners

###  Key Features
* **Core Management:** Full CRUD for People, Drivers, and Users using a centralized logic pattern.
* **License Lifecycle:**
    * Issuance (First time, Renew, Replacement).
    * International License conversion.
    * Detain & Release licenses (Logic handles fines and restrictions).
* **Testing Center:** Management of Vision, Theory, and Practical tests with appointment scheduling constraints.
* **Security:** Role-based access control and hashed credentials.

### 🗄️ Database Strategy
The database is normalized to ensure integrity, heavily utilizing:
* **Stored Procedures:** To encapsulate queries and prevent SQL Injection.
* **Views:** For efficient data presentation in DGV (DataGrid Views).
* **Relationships:** Complex One-to-One and One-to-Many relationships linking Drivers, Licenses, and Applications.
