Entity Framework Wrappable Fields 
================

Entity Framework has some limitations in what can be queried and what types can be mapped.

I created this extension to allow any property to be wrapped by a property not defined in the edmx mapping.

There are several usages for this extension, you could us this to add enums to your entities or to protect the relations using types with less actions or properties available.

For more details of this extension see: 

  - [Landman Code: Adding support for enum properties on your entities in Entity Framework](http://landman-code.blogspot.com/2010/08/adding-support-for-enum-properties-on.html)
  - [Landman Code: Protection your EntityCollections from outside abuse by wrapping them as IEnumerable](http://landman-code.blogspot.com/2010/08/protection-your-entitycollections-from.html)
