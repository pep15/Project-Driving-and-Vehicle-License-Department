DVLD - Driving and Vehicle License Department System
📝 Project Overview

DVLD is a comprehensive desktop application designed to automate and manage the core operations of a Driving and Vehicle License Department. The system handles the complete lifecycle of driver management, from the initial application and testing process to the issuance, renewal, and management of driving licenses (Local and International).

This project was built to simulate a real-world enterprise environment, focusing on data integrity, complex business logic, and a user-friendly interface.
🏗️ Software Architecture

The system is engineered using a robust N-Tier Architecture, ensuring a clean separation of concerns, scalability, and maintainability:

    Presentation Layer (PL): Built with Windows Forms (WinForms), providing an intuitive and responsive User Interface.

    Business Logic Layer (BLL): Contains all the business rules, validations, and logical operations (e.g., license expiration checks, age validation, fees calculation).

    Data Access Layer (DAL): Manages all direct communications with the database using ADO.NET.

    Database: A relational database designed with Microsoft SQL Server.

💻 Technologies & Tools

    Language: C# (.NET Framework)

    Database: Microsoft SQL Server (T-SQL)

    UI Framework: Windows Forms

    IDE: Microsoft Visual Studio

🚀 Key Features

    People & Driver Management:

        Full CRUD operations for managing person details (National ID, Date of Birth, Address, etc.).

        Tracking driver history and linking drivers to multiple licenses.

    License Management:

        Local Licenses: Issuing new licenses, renewing expiring ones, and replacing lost or damaged licenses.

        International Licenses: Handling applications and issuance of international driving permits.

    Application & Test Process:

        Managing different application types (New Local License, Renew, Replacement, Release Detained).

        Scheduling and managing tests (Vision Test, Written Theory Test, Practical Street Test).

    Detain & Release Licenses:

        System for detaining licenses due to traffic violations or unpaid fees.

        Calculation of fine fees and releasing licenses upon payment.

    User Security:

        Role-based user management.

        Secure login and authentication system.

🗄️ Database Design

The project features a complex Relational Database Management System (RDBMS) design, utilizing:

    Primary & Foreign Keys to ensure referential integrity.

    Stored Procedures and parameterized queries for security and performance.

    Views for simplified data retrieval.

    Tables covering Users, People, Drivers, Licenses, Applications, Tests, and Detained Licenses.

Developed by Moath Aljmaan
