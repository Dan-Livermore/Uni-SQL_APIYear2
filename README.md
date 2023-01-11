# COMP2001

## Information Management & Retrieval Coursework

  

### Overview

- Developed the Trail Serivce micro-serivce for a wellbeing app.

- Created an API connecting that connects to a database, that I developed for the previous coursework.

- The API can perform the CRUD functions that it recieves from the stored procedures in the database.
- The database stores data for the trails and the user's who have created them, as shown below in the following Diagram.
- ![Entity Relationship Diagram](img.jpg "Entity Relationship Diagram")
### Functions

- Connects to the improved SQL server database under the schema CW2.
- Uses GET requests to read the data from the database.
- Accesses the stored procedures to insert, update and delete data from the database using POST commands.

### How To Use
There are 4 actions that can be performed using this API. Read, insert, update and delete.
1. Simply select the action of your choice.
2. Press 'Try it out'.
3. If needed, enter parameters.
4. Press Execute
5. The data should output and a message will appear indicating if the request was successful.
  

###### Made in ASP.NET with C# using a Microsoft SQL Server Database with Microsoft Azure Data Studio. 