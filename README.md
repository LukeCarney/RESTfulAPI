# RESTfulAPI with Entity Framework, .Net Web API, and Validation
-----------------------------------------------------------------
This project was created using visual studio and used .Net 6.0, entity framework core 7.0.9 and MSSQL.

USE:
1. Download the project
- I have set the database up on a local branch with the db :'(localdb)\\mssqllocaldb'

2. To setup the database
- Ensure the migrations folder is deleted.
- The command add-migration 'MIGRATION_NAME' will need to be performed in the package manager console.
- Then update-database in the package manager console.
- This should create a local instance of the database with seed data for the products table
- This can be viewed in Sql server object explorer or sql server management studio

3.Start up in visual studio. 
- The project has Swagger (this is shown on project start) installed for testing each CRUD component of the API. Alternativaly the project can be tested in the browser or using postman. testing url e.g. https://localhost:7295/Product?Contains=c&GreaterThan=5

Project features:
- API Endpoints(GET, POST, PUT,DELETE)
- Entity framework core to perform CRUD functionality on SQL database
- Validation for price and product
- DDD Service architecture
- API error handling
- API Get pagination and filtering
  - Filtering on get: Contains, GreaterThan, LessThan, EqualToo
  - Pagination on get: Limit, OffSet
