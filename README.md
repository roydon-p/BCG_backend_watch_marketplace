# Watch Catalogue E-Commerce API

This is a simplified e-commerce API with a single endpoint that performs a checkout action for a list of watches and returns the total cost.

## Table of Contents

- [Requirements](#requirements)
- [Approach](#apporach)
- [API Endpoint](#api-endpoint)
- [Request Format](#request-format)
- [Response Format](#response-format)
- [Setup and Run](#setup-and-run)
- [Testing](#testing)
- [Assumptions and Improvements](#assumptions)


## Requirements

- Build an API with a single endpoint for checkout action.
- The endpoint should take a list of watches as input and return the total cost.
- Watches can have individual prices and discounts.
- Discounts may apply if certain conditions are met based on individual watches.


## Approach
While approaching the problem, I followed these steps:
1.	Understanding Requirements: I carefully reviewed the provided guidelines to understand the requirements, the watch catalogue data, and the expected behavior of the API.
2.	Build Project Structure: I built the base structure of the project so as to define where Services, Controllers and Models would reside and mapped them to the Program.cs file.
3.	Designing Data Model: I designed the Watch model to represent each individual watch, including its properties such as WatchId, WatchName, UnitPrice, DiscountQuantity, and DiscountPrice.
4.	Implementing CheckoutService: I created a CheckoutService responsible for calculating the total price based on the provided watch IDs. I applied discounts as per the guidelines and handled different scenarios, such as multiple discounts and no discounts.
5.	Creating API Controller: I implemented a CheckoutController with a single endpoint to handle the checkout action. The controller interacts with the CheckoutService to calculate the total price.
6.	Swagger/OpenAPI: I used the default scaffold code for building API provided by .NET using Swagger. This removes the need to use services like Postman to test the API.
7.	Writing Tests: I wrote comprehensive NUnit tests to ensure the correctness of the CheckoutService and the CheckoutController. I covered various scenarios, including no discounts, single discounts, multiple discounts, and edge cases.
8.	Documentation: I created a detailed README to guide users on setting up and using the API.


## API Endpoint
POST: http://localhost:8080/checkout


## Request Format
### Headers
Accept: application/json

Content-Type: application/json

### Body: 
[
"001",
"002",
"001",
"004",
"003"
]


## Response Format

### Headers
Accept: application/json

### Body: 
{
"price": 360
}


## Setup and Run

1. Clone this repository.
2. Configure your development environment with the required language and framework (C#, .NET, NUnit, Moq, etc.).
3. Navigate to the project root directory.
4. Build and run the project. You can use the `dotnet build` and `dotnet run` commands.
5. Once the Swagger UI is started in the web browser, expand the `/checkout` endpoint and click on the `Try it out` button.
6. Input the required list in the body section and click on `Execute`.


## Testing

The project includes unit tests to ensure the correctness of the API.

To run the tests:

1. Open your terminal/command prompt.
2. Navigate to the project root directory.
3. Run the tests using the command: `dotnet test`


