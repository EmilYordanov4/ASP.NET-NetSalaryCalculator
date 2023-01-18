# ASP.Net-NetSalaryCalculator

**Net Salary Calculator**
<br />

The application is web based and I have used MVC for it.

To start it, the only thing needed is to change the DefaultConnection string, which you can find:
appsettings.json (for the application).
testsettings.json (for the application tests).

I have used Microsoft SQL for the database, MyTested.AspNetCore.MVC.Universe by Ivaylo Kenov for unit testing.

The database consists of:
Users
Salaries
AnnualBases

Users and Salaries are connected to each other with One-To-One Relationship.

The following data is being seeded at the first start of the application:
- Administration account
- Yearly basis - 3 examples

The unit tests are mainly focused on the contorller and the basic logic.

Added registration, so each user can save and reuse its information.

Added Admin role with the following credentials:
admin@dcs.bg
admin12

The application has the following pages and functionalities, below I will share the main part of it:
1. Home page for non-registered user.
2. Home page for registered user.
3. Register page.
4. Login page.
5. Annual Bases page (accessible only for already registered user), there you can find the parameters for all the added annual bases.
- In the Annual Bases page, the administrator can also edit and delete already added annual bases or add a new one. 
6. Year page (accessible only for already registered user), there you can select the year for which you want to calculate your net salary.
7. Calculator page (accessible only for already registered user) there you can find the following:
- The parameters for the selected year.
- The lastly used gross salary for the calculator, as well as the results of that calculation.
- When the user sets a new gross salary, using the year's parameters it automatically calculates the new net salary, as well as the taxes and overwrites the results from the previous one.
8. Manage Account page, where you change your e-mail and password.
9. Logout page/button.
