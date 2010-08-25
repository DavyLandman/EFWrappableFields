Entity Framework Wrappable Fields 
================

Entity Framework has some limitations in what can be queried and what types can be mapped.

I created this extension to allow any property to be wrapped by a property not defined in the edmx mapping.

There are several usages for this extension, you could us this to add enums to your entities or to protect the relations using types with less actions or properties available.

For more details of this extension see: 

  - [Landman Code: Adding support for enum properties on your entities in Entity Framework](http://landman-code.blogspot.com/2010/08/adding-support-for-enum-properties-on.html)
  - [Landman Code: Protection your EntityCollections from outside abuse by wrapping them as IEnumerable](http://landman-code.blogspot.com/2010/08/protection-your-entitycollections-from.html)

Usage
----------
To use the Wrappable Fields extension, add a reference to the assembly, and in the place were you would normally start with filtering your EntitySet/ObjectQuery/IQueryable you have to wrap that collection with a  `WrappedFieldsObjectQuery` object.

So what used to be:

    var context = new EFTestDatabaseEntities();
    var orders = from o in context.Orders
       where o.Status == OrderState.Shipped
       select o;

Now has to become:

    var context = new EFTestDatabaseEntities();
    var orders = from o in new WrappedFieldsObjectQuery<Order>(context.Orders)
       where o.Status == OrderState.Shipped
       select o;

While this looks like a big impact, you should really model your application such that you aren't writing these queries everywhere.

In order for this to work the library tries to find if there is a Property with a `Db` prefix for the property used and replaces it. So the `DbStatus` is in the entity model but hidden, and the `Status` field is the public visible property.

Developing
------------
If you want to fork this project and add some feature, use the `EF1Test/TestDatabase.sql` script to generate and fill the database and correct the connection string if needed.

