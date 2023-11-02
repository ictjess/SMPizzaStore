Installation:
1. Create a database name PizzaDB in Azure cloud.
2. Execute requireed database scripts inside the resources\Database Scripts\PizzaDb in chronological order:
  2.1   01 - Tables
  2.2   02 - Views
  2.3   03 - Stored Procedures
3. Using your database credentials, change the connection string in the web.config file, ConnectionStrings section.
4. Run the application to check if it will now connect to the database in Azure Cloud that you've created.

Application Manual:
1. Home
  1.1 - This link goes back to the home page.
2. Manage Toppings
  2.1 Create New - Will redirect you to a page where you can create new records.
  2.2 List
     2.2.1 - This page shows the records already added in the database. For each record, it has a corresponding Edit, Details, and Delete links.
  2.3 Edit - Will redirect you to a page where you can edit existing records.
  2.4 Details - Will redirect you to a read only page where you can view the selected record. It has an Edit link below to redirect you to edit page.
  2.5 Delete - Will redirect you to a page where you can decide to delete selected record.
3. Manage Pizzas
  3.1 Create New - Will redirect you to a page where you can create new records.
  3.2 List
     3.2.1 - This page shows the records already added in the database. For each record, it has a corresponding Edit, Details, Delete, and Manage links.
  3.3 Edit - Will redirect you to a page where you can edit existing records.
  3.4 Details - Will redirect you to a read only page where you can view the selected record. It has an Edit link below to redirect you to edit page.
  3.5 Delete - Will redirect you to a page where you can decide to delete selected record.
  3.6 Manage - Will redirect you to a page where you can add a topping to selected pizza, or remove selected topping from selected pizza. 
