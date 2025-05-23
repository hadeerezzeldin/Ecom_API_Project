# Ecomm_API_Project
API Platform for an Online Marketplace of Handmade Products

Overview
This platform enables artists and artisans to showcase and sell their handmade products such as candles, accessories, crafts, and personalized gifts. Sellers can list customizable products (e.g., products with personalized name prints), while customers can place custom orders, rate sellers, and communicate with them via a simple chat system.

The platform supports user registration and login with email confirmation, password recovery, and secure payment processing.

Key Features
User and seller registration with email verification.

Login using email and password.

Password recovery through email.

Product management (CRUD) by sellers.

Customizable orders (e.g., personalized prints or colors).

API endpoints to display products and interactive designs.

Payment processing through integrated payment gateways.

Data protection using JWT or OAuth authentication.


Requirements
.NET 6/7 (or compatible version)

SQL Server or any supported relational database

Email sending service (SMTP, SendGrid, etc.)

Payment gateway (e.g., Stripe, PayPal)


Project Structure

Authentication: Registration, login, email confirmation, password recovery

Users: Management of user and seller profiles

Products: Product management, image uploads, customization options

Categories: Categories management, customization options
Photos: Product management, image uploads, customization options
}شفثلخقه

API Endpoints

Function	Method	Route	Description
Register new user	POST	/api/auth/register	Create new account and confirm email
Login	POST	/api/auth/login	Receive JWT token for authentication
Confirm email	GET	/api/auth/confirm-email	Confirm email via link
Forgot password	POST	/api/auth/forgot-password	Send password reset link
Reset password	POST	/api/auth/reset-password	Update password
Add product	POST	/api/products	Add new product (seller only)
Update product	PUT	/api/products/{id}	Update product details
Delete product	DELETE	/api/products/{id}	Remove product
Get products	GET	/api/products	List all products
Add To Cart	POST	/api/cart	Add rating for seller or product
Get Cart	GET	/api/cart/{id}	Retrieve messages in a conversation
Delete Cart	POST	/api/cart/id Place new order and process payment

Running the Project Locally
Clone the repository:

bash
Copy
Edit
git clone 
cd handmade-ecommerce-api
Configure your .env or appsettings.json file with your database connection, email service, and payment gateway settings.

Run Entity Framework migrations to create the database schema:

bash
Copy
Edit
dotnet ef database update
Start the API server:

bash
Copy
Edit
dotnet run
Access the API at https://localhost:5001 (or your configured URL).

Technologies Used
ASP.NET Core Web API

Entity Framework Core (Code First approach)

JWT Authentication

Email services (SMTP)






