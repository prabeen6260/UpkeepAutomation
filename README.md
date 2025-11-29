# TruSwap Automated Quality Assurance Suite

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Selenium](https://img.shields.io/badge/-selenium-%2343B02A?style=for-the-badge&logo=selenium&logoColor=white)
![NUnit](https://img.shields.io/badge/NUnit-26C045?style=for-the-badge&logo=nunit&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

## Project Overview

This repository contains a robust **Test Automation Framework** designed to validate the functionality, stability, and data integrity of the **TruSwap/Upkeep** full-stack application. 

Built using **C#** and **Selenium WebDriver**, this framework adopts the **Page Object Model (POM)** design pattern to ensure code maintainability and scalability. It goes beyond simple UI interactions by implementing **White-box testing** methodologies, connecting directly to the application's **MySQL database** to verify that frontend actions result in accurate backend data persistence.

## Key Features

* **Page Object Model (POM):** UI logic is strictly separated from test assertions, making the suite modular and easy to maintain.
* **OAuth2 / Auth0 Synchronization:** Implements advanced `WebDriverWait` strategies to handle asynchronous external redirects and authentication callbacks, resolving flakiness associated with third-party login providers.
* **Database Validation (White-box):** Includes a `DatabaseHelper` utility that executes SQL queries to verify user creation and data integrity directly against the MySQL backend.
* **Secure Configuration:** Utilizes `Microsoft.Extensions.Configuration` to manage test data and secrets via `appsettings.json`, ensuring sensitive credentials are never hardcoded (Git-ignored).
* **Cross-Browser Ready:** configured for Google Chrome but structured to easily support Firefox or Edge.

## Tech Stack

* **Language:** C# (.NET 10.0)
* **Framework:** NUnit
* **Web Driver:** Selenium WebDriver (ChromeDriver)
* **Database:** MySql.Data


##Project Structure

```text
TruSwap.Automation.Tests/
├── Pages/                  # Page Object Classes (UI Logic)
│   └── LoginPage.cs        # Maps Auth0 and TruSwap UI elements
├── Tests/                  # NUnit Test Classes (Assertions)
│   └── LoginTests.cs       # Validates Authentication & Redirection
├── Utilities/              # Helper Classes
│   ├── BaseTest.cs         # Setup/Teardown & Driver Lifecycle
│   └── DatabaseHelper.cs   # SQL Connection & Query Logic
├── appsettings.json        # Test Configuration (Ignored by Git)
└── TruSwap.Automation.Tests.csproj