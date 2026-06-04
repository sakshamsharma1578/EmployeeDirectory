# Employee Directory Management System

## Overview

Employee Directory Management System is a full-stack web application developed using ASP.NET Core MVC and SQL Server. The application provides a centralized platform for managing employee records, including personal information, department details, contact information, skills, and employment status.

The project was developed during an internship to demonstrate the implementation of a layered architecture, database integration, CRUD operations, and modern frontend design principles.

---

## Features

* Employee record management
* Create, Read, Update, and Delete (CRUD) operations
* Employee search and filtering
* Department and status categorization
* SQL Server database integration
* Responsive user interface
* Smooth animations using GSAP
* Enhanced scrolling experience using Locomotive Scroll
* Form validation and data integrity checks

---

## Technology Stack

### Backend

* ASP.NET Core MVC
* C#
* ADO.NET
* SQL Server

### Frontend

* HTML5
* CSS3
* Tailwind CSS
* JavaScript
* GSAP (GreenSock Animation Platform)
* Locomotive Scroll

### Architecture

* MVC Architecture
* Multi-Layer Architecture

  * VO (Value Objects)
  * BM (Business Model)
  * DL (Data Layer)
  * UIW.VM (View Models)

---

## Project Structure

Employee Directory follows a layered architecture to ensure maintainability and separation of concerns.

User Interface (UI)
↓
Controller
↓
Business Model (BM)
↓
Data Layer (DL)
↓
SQL Server Database

The response follows the reverse path back to the user interface.

---

## Core Functionalities

### Employee Management

* Add new employees
* Update employee information
* Delete employee records
* View employee details

### Data Filtering

* Search employees by information
* Filter by department
* Filter by employment status

### User Experience

* Animated content transitions
* Interactive employee cards
* Responsive layout
* Modern dark-themed interface

---

## Database

The application uses SQL Server for persistent storage.

Key employee information includes:

* Full Name
* Phone Number
* Email Address
* Gender
* Date of Birth
* Address
* Department
* Employment Status
* Skills
* Marital Status

---

## Learning Outcomes

Through this project, the following concepts were implemented and explored:

* ASP.NET Core MVC development
* Multi-layer software architecture
* Database connectivity using ADO.NET
* SQL query execution and data management
* ViewModel and Value Object design patterns
* Frontend animation integration
* User interface design and responsiveness

---

## Future Enhancements

Potential improvements include:

* Authentication and role-based access control
* Employee profile image uploads
* Dashboard analytics
* REST API integration
* Export to PDF/Excel
* Advanced search capabilities

---

## Author

Developed as part of an internship project focused on ASP.NET Core MVC application development, database integration, and modern web interface design.
