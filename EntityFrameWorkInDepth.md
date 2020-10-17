# Table of Contents  
- [HOW TO SETUP DATABASE OF A NEW PROJECT USING CODEFIRST APPROACH ?](#SETUPDATABASE) 
- [HOW EF HANDLES MANY TO MANY RELATIONSHIP?](#RELATIONSHIP)
- [CODE FIRST USE KORE EXISTING DB IMPORT KORBO KIBABE ?](#EDB)
- [DETAILS ABOUT MIGRATION ](#DETAILS)
- [LINQ QUERY IN ACTION ](#LINQ)
- [LINQ QUERY EXAMPLES ](#EXAMPLES)


   

<a name="SETUPDATABASE"/>
   
# HOW TO SETUP DATABASE OF A NEW PROJECT USING CODEFIRST APPROACH
## 1. define domain models (of course their can be relations between models like one to many , many to many ...)
## 2.create db context class and define dbset inside Contextclass
## 3. setup connection string 
- if we use same name as db context then no need to specify any aditional configuration but we won't follow it 
rather we will define a connection string by orselves as we need more control 
for eg: if we declare in connectionstring name="Defaultconnection" then we need to add in Datacontext Class
Public MainContext():base("name=DefaultConnection")
initial catalogue hochhe database name
## 4.migration 


<a name="RELATIONSHIP"/>
   
# HOW EF HANDLES MANY TO MANY RELATIONSHIP?
- amara domain model ar modde many to manny relationship define kore dai . 
for eg : there are two classes Student and Course and both have many to many relationship 
in code we define many to many relationship in this way 
public class Student
{
 public List<Course>Courses{get ; set;} 	
} 
public class Course
{
 public List<Student>Students{get ; set;} 	
} 
   
- now when we define  many to many relationship in code
ef automatically generates an intermediate table to manage
many to many relationship and the automatically generated 
table name will be like CoursesStudents and the primary key
will be composite key from both table and there will be two foreign keys 
and cascadedelete will be set as true automatically to make sure that 
if any data from parent table is deleted then this data will also be deleted from 
this intermediate table too .


<a name="EDB"/>

# CODE FIRST USE KORE EXISTING DB IMPORT KORBO KIBABE
- right click on project->add new item ->ado.net entity data model ->Code First from database ->new connection -> give server name and select db name
-> select Tables except _MigrationHistory -> click finish 
reference : mosh hamedani course entity framework in depth 24 no lecture 
existed db ef code first diye import korle then add-migration whatever -Ignorechanges -Force


<a name="DETAILS"/>

# DETAILS ABOUT MIGRATION 
- Add migration command run korar por always migrationfile ta dekhba then update command run korba 
- Adding a class into the db also need migration . 
so its better to migrate after each changes lets say if you 
add new two classes in db then its better to migrate after adding a class
rathe than after adding too many classes 
- doro bule akta empty migration kore fella
mane dbset add koro nai tai empty migration 
akhn ai same name ai migration ta thik korte parba 
jodi _Force use koro . 
for eg :  add-migration migrationname -Force   

- table kisu demo data kibabe generate korbo ?
migration ar up method ar bitor sql statement diye
- amra jodi identity genrated id na chai tahole identitygeneratedoption.none dilei hobe 
- db model a jodi change kori tahole obossoi migration lagbe but view model a change korle migration lagbe na 
karon view model to temporary atato db te kono effect fele na ba data o store kore na 
- Migration also requires when modifying an existing class or renaming a field name 
- Datetime is bydefault required type so inorder to allow null value 
make it nullable like this public DateTime? StartDate {get ;set;} 
- akta field name rename kore migration korte gele khub e careful 
lets say age akta field chilo Title akhn rename kore Name field korsi
add-migration run korar por up method a dekhba je Name column add kortese ar 
Title column drop kortese so Title column a joto chilo sob amra haraya felbo
so ata avoid korar jonno amra Sql("Update tablename set Name =Title");
also downmethod a reverse ta likhbo  Sql("Update tablename set Title =Name");
- deleting column also requires migration but thats straight forward 
- bul kore migration korle oi migration ta delete na kore arekta notun migration korbo (also learn how to revert migration )
- Downgrafing a Database :  lets say I have eight migrations and I want to keep migration till sixth migrration 
so inorder to do that I have to run : update-database - TargetMigration:SixthMigrationName
- there are two types of migration code first and automatic migration we always 
disable or set false in automatic migration as this is risky in production db 


<a name="LINQ"/>

#  LINQ QUERY IN ACTION
## there are two ways to write linq query both returns the same result lets see 
- Way 1 :using Linq syntex 

var ctx = new MainDbContext();

var qry = from c in ctx.Courses 
	
   where c.Name.Contains("c#")
	
   orderby c.Name
	
   select c ;

now iterate through qry oobject 
foreach(var courses in qry)
{
console.WriteLine(courses.Name);
}

- Way 2 : using Extension Methods

var qry = ctx.Courses
       .where(c=>c.Name.Contains("c#"))
	.orderby c.Name;

Here returns all the objects which match the condition but we use singleordefault ot firstordefault in that case it will retun only one object 

now iterate through qry oobject 
foreach(var courses in qry)
{
console.WriteLine(courses.Name);
}


<a name="EXAMPLES"/>

# LINQ QUERY EXAMPLES

## 1. Restriction using Where
- var qry = from c in ctx.Courses 
	
	where c.Name.Contains("c#") && c.Author=="Mahmud"  
	
	select c
	
	
## 2.Ordering using orderby keyword

- var qry = from c in ctx.Courses 
	
	where c.Name.Contains("c#")
	
	orderby c.Name,c.Level
	
	select c ;
	
	
## 3.Projection which is a optimization 
- var qry = from c in ctx.Courses 
	
	select new {Name = c.Name}; ---> Instead of selecting all the features we are just selecting the required feature 


## 4. Groupby : there is adifferenc between sql group and linq group by
## in linq we dont need to use any aggregiate function but in sql we need 
- var qry = from c in ctx.Courses
	  group c by c.level
	  into g 
	  select g ; 

## 5. Joining 
 There are three types of joining in linq 
## i.Inner Join 

var qry = from c in ctx.customers
	  
	  join a in ctx.Authors
	  
	  on c.Id equals a.aId
	  
	  select new{Name = c.Name , AuthorName = a.Name};

## ii.group join

- gorup join does not have equla in sql.
We use group join in situation where left
join needed

var qry = from c in ctx.Authors
	  
	  join c in ctx.Customers
	  on a.aId equals c.AuthorId into g 
	  select new{ AuthorName = a.Name, Courses = g.Count()};
	  
	  
## iii. cross join return all possible combination
- same as sql . lets see an example :

var qry = from c in ctx.customers
	  
	  from a in ctx.Authors
	  select new{CustomerName = c.Name , AuthorName = a.Name};
	  
##  We dont need to join two tables to display the result in linq query 
we can easily display the result from two tables using navigation property 
lets see in action 
var qry = from c in ctx.Course
	  select new {CoursseName = c.Name , AuthorName =c.Author.Name }




Different LINQ Query In Action using Extension Methods:


1.Restriction 
var qry = ctx.Courses.where(c=>c.Level==1) ;

2.Ordering using orderby keyword

var qry = ctx.Courses.where(c=>c.Level==1).orderby(c=>c.Name).ThenBy(c=>c.level) ;

3.Projection which is a optimization 

var qry = ctx.Courses.
	where(c=>c.Level==1).
	orderby(c=>c.Name).
	ThenBy(c=>c.level).
	Select(c=> new {CourseName = c.Name ,AuthorName = c.Author.Name  } );

if you wanna flatened a list then use selectmany 

there are also groupby,join and other feature in extension method see on net for details 


LINQ Extension Methods Additional Methods

Partitioning : 

var courses =ctx.corses.Skip(10).Take(10);

Element opearators : 

FirstOrDefaults() , First() , LastorDefault() , Last(),single(), SingleOrDefault()  but 
remember in sql server there is no method to get last record so if you wanna get last record 
sort them in a descending order then take the first element 

we can just use them as it is or we can put condition also like 
var courses =ctx.corses.FirstOrDefaults(c=>c.Price>100)



Quantifying : 

All() , any ()

var courses =ctx.corses.All(c=>c.Price>100)


Aggregating :

Max ,Min . Average 

Deferred Execution :

Queries are not executed when we create them 
rather Query executed when 

1.Iterating over query variable 
2.calling ToList ,ToArray, TODictionary 
3.Calling First , laST, SingleOrDefault ,Count , MAx 

Ienumerrable : 
We can enumerate on these using a loop and can get each item 
 string (we can get each character of list), 
array(we can get each item of array) , 
list (we can get each item of list),
Dictionary(we can get each item of Dictionary)

