# Task  
- Task asynchronously kaj kore .

## Why we need Tasks? 
- It can be used whenever you want to execute something in parallel. Asynchronous implementation is easy in a task, using’ async’ and ‘await’ keywords.

## Differences Between Task And Thread

- The task can return a result. There is no direct mechanism to return the result from a thread.
Task supports cancellation through the use of cancellation tokens. But Thread doesn't.
A task can have multiple processes happening at the same time. Threads can only have one task running at a time.
We can easily implement Asynchronous using ’async’ and ‘await’ keywords.
A new Thread()is not dealing with Thread pool thread, whereas Task does use thread pool thread.
A Task is a higher level concept than Thread.


## Partial classes:
- Partial classes span multiple files.With normal C# classes, you cannot declare a class in two separate files in the same project. But with the partial modifier, you can.
for example :ABC project a ABCDBContext same name a 2 ta partial class ase 

## Virtual Keyword : 
- In c#, the virtual keyword is useful to override base class members such as properties, methods, etc. in the derived class to modify it based on our requirements.
In c#, by default all the methods are non-virtual and we cannot override non-virtual methods. In case, if you want to override a method, then you need to define it with the virtual keyword.

 
## AutoMapper:
- sohoj basai automapper diye ak type ar object ke arek type ar object a convert kori 
How do I use AutoMapper?

- First, you need both a source and destination type to work with.
    
      var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>());

- secondly To perform a mapping, call one of the Map overloads:
      
      var mapper = config.CreateMapper();
// or

      var mapper = new Mapper(config);
      OrderDto dto = mapper.Map<OrderDto>(order);

# T:
## What does <T> denote in C# ?

- A generic type parameter allows you to specify an arbitrary type T to a method at compile-time, without specifying a concrete type in the method or class declaration.
      
      public T[] Reverse<T>(T[] array)
       {
           var result = new T[array.Length];
           int j=0;
           for(int i=array.Length - 1; i>= 0; i--)
           {
               result[j] = array[i];
               j++;
           }
           return result;
       }
The key point here is that the array elements can be of any type, and the function will still work. You specify the type in the method call; type safety is still guaranteed.


# Enum : 
- An enumeration type (or enum type) is a value type defined by a set of named constants of the underlying integral numeric type. 
To define an enumeration type, use the enum keyword and specify the names of enum members:
By default, the associated constant values of enum members are of type int; they start with zero and increase by one following the definition text order. 
You can explicitly specify any other integral numeric type as an underlying type of an enumeration type.
You can also explicitly specify the associated constant values, as the following example shows

# Using :
- The using statement is used to work with an object in C# that implements the IDisposable interface.

- The IDisposable interface has one public method called Dispose that is used to dispose of the object. When we use the using statement,
we don't need to explicitly dispose of the object in the code, the using statement takes care of it.

     using (SqlConnection conn = new SqlConnection())
     {

     }

     When we use the above block, internally the code is generated like this:
     SqlConnection conn = new SqlConnection() 
     try
     {

     }
     finally
     {
         // calls the dispose method of the conn object
     }


# Linq: 

- Obtaining a Data Source:

In a LINQ query, the from clause comes first in order to introduce the data source (customers) and the range variable (cust).
     
     var queryAllCustomers = from cust in customers
                            select cust;
     
     
- Filtering:

where is used to filter 

    var queryLondonCustomers = from cust in customers
                                where cust.City == "London"
                                select cust;
                           
    var qry = from cc in ctx.Categories
              join cd in ctx.CategoryDetails on cc.Id equals cd.CategoryId

- Ordering:

The orderby clause will cause the elements in the returned sequence to be sorted according to the default comparer for the type being sorted. 
For example, the following query can be extended to sort the results based on the Name property. 
Because Name is a string, the default comparer performs an alphabetical sort from A to Z.

     var queryLondonCustomers3 =
         from cust in customers
         where cust.City == "London"
         orderby cust.Name ascending
         select cust;
    
    
 - Grouping:
 
        var queryCustomersByCity =
             from cust in customers
             group cust by cust.City;
      
      
 - Selecting (Projections):
The select clause produces the results of the query and specifies the "shape" or type of each returned element. 
For example, you can specify whether your results will consist of complete Customer objects, just one member, a subset of members,
or some completely different result type based on a computation or new object creation.
When the select clause produces something other than a copy of the source element, the operation is called a projection. 
The use of projections to transform data is a powerful capability of LINQ query expressions. 
For more information, see Data Transformations with LINQ (C#) and select clause.
 
 
# Routing :

     routes.MapRoute(
                   name: "O2Rush",  <-- Url Name
                   url: "o2rush",  <-- Url Pattern
                   defaults: new { controller = "Page", action = "Index", id = "O₂Rush_Performance_Air_Filter" } <-- default route 
               );
            
  how to do custome routing :
  ans : khube  simple amader ichha onujae url name, pattern default set korbo then logic implement korbo controller ar actionresult ar modde 
  eg : Page controller ar Index actionaresult ar moddei amra logic implement korbo o2rus url ar jonno . 
   remember always put custom routing before default route 

     routes.MapRoute(
                     name: "Default",    <-- Url Name
                     url: "{controller}/{action}/{id}",  <-- Url Pattern
                     defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }  <-- default route 
                 );
 
 
 
# Api  :
- Read on rest api https://www.syncfusion.com/blogs/post/how-to-build-crud-rest-apis-with-asp-net-core-3-1-and-entity-framework-core-create-jwt-tokens-and-secure-apis.aspx
- dont forget to add [HttpGet] , [HttpPost] ... this http verb attribute before apis  
           
           api call korar genereal conventaion : /api/controller 

- example : 

       public class ValuesController : ApiController
       {
       public IEnumerable<string> Values()
       {
                   return new string[] { "value1", "value2" };   //atar jonno api call ta hobe https://localhost:portnumber/api/values
       }

       public string Get(int id)
       {
                   return "value";  /atar jonno api call ta hobe https://localhost:portnumber/api/values?id=1
       }

reference :https://www.tutorialsteacher.com/webapi/web-api-controller

}

- There are two types of routing in web api : https://www.tutorialsteacher.com/webapi/web-api-routing


# Identity authentication :
- In this scenario, Web API controllers act as resource servers. An authentication filter validates access tokens, 
and the [Authorize] attribute is used to protect a resource. When a controller or action has the [Authorize] attribute, 
all requests to that controller or action must be authenticated. Otherwise, authorization is denied, and Web API returns a 401 (Unauthorized) error.


- eg : Ryco te Identity authentication use kora hoyeche 
eg : ABC te jwt authentication use kora hoyeche 
reference : https://www.tutorialsteacher.com/webapi/web-api-controller

# difference between identity server and JWT(jason web token) authentication :
------------
JWTs
-----------
Not stored on the server
Great for SSO
Can't be revoked prematurely


Identity Bearer Tokens
--------------
Stored on the server
Can be revoked at any time
Requires a central authority or shared database to share the token across servers


# Generics: 
- Generics introduced in C# 2.0. It allows you to define a class with placeholders for the type of its fields,
methods, parameters, etc. Generics replace these placeholders with some specific type at compile time.

- Advantages of Generics
Increases the reusability of the code.
Generic are type safe. You get compile time errors if you try to use a different type of data than the one specified in the definition.
Generic has a performance advantage because it removes the possibilities of boxing and unboxing.

- reference : https://www.tutorialsteacher.com/csharp/csharp-generics

# Access Modifier :

- public:	     The code is accessible for all classes
private:	    The code is only accessible within the same class
protected:	  The code is accessible within the same class, or in a class that is inherited from that class. You will learn more about inheritance in a later chapter
internal:	   The code is only accessible within its own assembly, but not from another assembly. You will learn more about this in a later chapter

# Typescript:

- Typescript is the superset of javascript . 
Javascript does not have object oriented features so typescript came 
to solve the problem .
If we write typescript code then we dont need 
to write javascript as typescript automatically converted into javascript . 

Fatures  of Typescript : 

# 1 Strong-typed variables : In Typescript, we can define a variable’s type with the strong-typing feature like
 we define a variable in Java or C++.
let name: string;       // for strings
let age: number;        // for any kind of numbers
let isChecked: boolean; // true or false
let data: any;          // can be changed later to any type
let array: number[];    // array of numbers

# 2 Object-oriented programming :Another important feature of TS is that we can write object-oriented code.
 For example, we can define classes and interfaces:

     Class & Interface : 

     class Student {
       firstName: String;
       lastName: String;
       studentId: number;
     getGrades() {
           // some code
       }
     }

- We have created a Student class and later we can create instances with the new keyword:
let student = new Student();     // an instance of Student class
After assigning the Student( ) object, we don’t need to declare its type again.
 It will be done automatically by Typescript.

- Constructors: 
In Object-Oriented Programming, we have an important method called constructor( ).
Every class has actually a default constructor method, and it is called when we create an instance of that class:


    class Student {
      firstName: String;
      lastName: String;
    constructor(firstName?: string, lastName?: string) {
        this.firstName = firstName;
        this.lastName = lastName;
      }
    getGrades() {      
        // some code
      }
    }

Access Modifiers:

    class Student {
      private firstName: String;
      private lastName: String;
    constructor(firstName?: string, lastName?: string) {
        this.firstName = firstName;
        this.lastName = lastName;
      }
    getGrades() {      
        // some code
      }
    }

- Reference : https://codeburst.io/understanding-typescript-basics-e003dbad2191

# Callback Function :

- A "callback" is a term that refers to a coding design pattern.
In this design pattern executable code is passed as an argument to other code and it is expected to call back at some time. 

- Delegate is a famous way to implement Callback in C#.  But, 
it can also be implemented by Interface. 
I will explain Callback by Delegate and Interface one by one. 

# Inheritance vs Composition :

#Inheritance creates tightly coupled relation which causes cahnges in one class may effect many classes 
eg : public class Order : Product {
}

#Composition creates loosly coupled relation 

eg : 
    
    public class SbOrderController : Controller
    {

        private IStockBoardOrderService SbOrderService { get; set; } // composition we reuse the code of IStockBoardOrderService
        // without repeating the code 

        public SbOrderController(IStockBoardOrderService SbOrderService)
        {
            this.SbOrderService = SbOrderService;
        }
   }


- I have to design class in such a way so that the implementation, details should be hidden .In order to achieve these I use private access modifiers .
- constructors are not inherited they need to explicitely defined in derived  class . Base class constructors are always execute first 
- Upcasting : conversion from derived class to a base class sohoj basai child class theke parent class a convert korake eg : Shape shape = circle 
- Downcasting : conversion from base class to derived class sohoj basai parent class theke child class a convert korake eg : Circle circle = (Circle) shape
- Boxing : value type ke reference type a convert korake. eg:  object ob = 1 
- UnBoxing : reference type ke value type a convert korake. eg:  int i = (int) object 




- IEnumerable - contains only GetEnumerator method to get Enumerator and allows looping
IEnumerable has one method GetEnumerator() which allows one to read through the values in a collection but not write to it.
Most of the complexity of using the enumerator is taken care of for us by the for each statement in C#.
IEnumerable has one property: Current, which returns the current element.

- ICollection contains additional methods: Add, Remove, Contains, Count, CopyTo
ICollection is inherited from IEnumerable

- Q: Why should we use ICollection and not IEnumerable or List<T> on many-many/one-many relationships?

      public  class PatientVisit
      {
      public virtual ICollection<PatientDocument> PatientDocuments { get; set; }
      }
      ICollection<T> is used because the IEnumerable<T> interface provides no way of adding items,
      removing items, or otherwise modifying the collection.

- Q: How to navigate from one table to another table EF 
You need to add a Navigation Property to Customer.

    public class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

- Q : When To Use IEnumerable, ICollection, IList And List?
https://www.claudiobernasconi.ch/2013/07/22/when-to-use-ienumerable-icollection-ilist-and-list/

Deserialization :  convert string -> object
eg:  ob = JsonConvert.DeserializeObject<Result>(result);

- Serialization : inverse of deserialization 
 to convert an object into that string
 
- Structure of a session
The session can be stored on the server, or on the client. 
If it's on the client, it will be stored by the browser, most likely in cookies and if it is stored on the server, 
the session ids are created and managed by the server.


- When to use properties instead of functions?
I tend to use properties if the following are true:
The property will return a single, logic value
Little or no logic is involved (typically just return a value, or do a small check/return value)

- I tend to use functions if the following are true:
There is going to be significant work involved in returning the value - ie: it'll get fetched from a DB, or something that may take "time"
There is quite a bit of logic involved, either in getting or setting the value



*****************************************PDCLTelemedicine.App******************************************************
- PDCLTelemedicine.App a MVVM structural design pattern follow kora hoise 
- When Should You Use MVVM ?
- Use this pattern when you need to transform models into another representation for a view. 
For example, you can use a view model to transform a Date into a date-formatted String, 
a Decimal into a currency-formatted String, or many other useful transformations.
To knowmore details about MVVM : https://www.raywenderlich.com/34-design-patterns-by-tutorials-mvvm


- PDCLTelemedicine.App a
MVVM design pattern follow kora hoise 
syncfusion ui component use kora hoise 
Prism use korsi 
Prism is a framework for building loosely coupled, maintainable, and testable XAML applications in WPF,
Windows 10 UWP, and Xamarin Forms. 
Separate releases are available for each platform and those will be developed on independent timelines.
https://prismlibrary.com/docs/
Prism's core functionality is a shared code base





