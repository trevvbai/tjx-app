Product App
Description

POC web app designed to display products with their descriptions, prices, and currencies. Users have the ability to view products and dynamically change the currency. The frontend is built using Angular for a responsive and interactive user experience, while the backend is powered by .NET to handle business logic and data storage efficiently. LiteDB used as lightweight quick setup db.

Features

    Display product information including name, description, and price
    User can change the product's currency
    Responsive design for an optimal viewing experience on various devices

Getting Started
Prerequisites

    Node.js and npm (for Angular)
    .NET SDK (for backend services)

Setting Up the Development Environment
Backend Setup  
Start backend server: 
- navigate to launchSettings.json
- launch https profile

Frontend Setup

- Navigate to the frontend project directory.
- Install the Angular project dependencies:

    npm install

Serve the Angular application:
- from client/client directory

    ng serve

    Open your browser and navigate to http://localhost:4200 to view the application.

Usage

After setting up the project, you can view the list of products on the homepage. Use the currency selector to change the currency displayed for product prices.
