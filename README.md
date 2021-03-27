# felfel-warehouse

This is an ASP.NET MVC project for a simple implementation of the Felfel warehouse.

There are 3 main entities:

- Products;
- Batches;
- Movements.

=== Product ===
This entity represents the different products you can save in the system (cola, pasta, meat...).

=== Batches ===
A batch is a bunch of the same product. All products that belong to the same batch have the same expiration date.

=== Movements ===
A movement is an operation made on a specific batch. It has an amount (positive if products were added, negative if removed)
a timestamp and a short description (reason).

Permitted actions on entities:
For all three entities, the basic CRUD actions are allowed.

For batches, there are 3 additional actions:
- History;
- Status;
- Stock.

The "history" endpoint permit retrieving the history of a given batch. Input: Batch Id; Output: Batch Object, Product Object, Array of Movements.

The "Status" endpoint permit retrieving an overview of the freshness of food in the warehouse (3 states: fresh, expiring today, expired).
Input: (nothing); Output: an object with 3 keys (EXPIRED, EXPIRING_TODAY, FRESH) and, as values, an array of all the batches with the relative status.

The "Stock" endpoint permit retrieving the current inventory per product; for each batch individually or for the whole warehouse, broken down by batches.
Input: an URL parameter "byBatch" (true or false), for choosing the functionality; Output: a simple object with the product name as keys and quantity as values,
or an object with N keys (where N is the number of products available in the batches) and an array of batches objects as values.

=== Technical Improvement ===
At the moment, it is not implemented the authorization and the authentication parts. An OAuth2 authentication with clientId and clientSecret should be added
for permitting the use of all REST endpoints by registered clients.
Another improvement could be the standardization of the error messages when the actions fail.

=== Next steps / ideas ===
The next step could be to implement the orders entity. An order is a purchase of different batches made towards a supplier. Adding an order will be possible to store several
batches at the same time and save more information (supplier, prices, documents...) in the database.