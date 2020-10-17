# Table of Contents  
- [HOW TO SETUP DATABASE OF A NEW PROJECT USING CODEFIRST APPROACH ?](#SETUPDATABASE) 
- [HOW EF HANDLES MANY TO MANY RELATIONSHIP?](#RELATIONSHIP)
- [CODE FIRST USE KORE EXISTING DB IMPORT KORBO KIBABE ?](#EDB)
- [DETAILS ABOUT MIGRATION ](#DETAILS)
   

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


