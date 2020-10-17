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

