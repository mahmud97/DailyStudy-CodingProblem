# Table of Contents  
- [HOW TO SETUP DATABASE OF A NEW PROJECT USING CODEFIRST APPROACH ?](#SETUPDATABASE) 


<a name="SETUPDATABASE"/>
   
# 
1. define domain models (of course their can be relations between models like one to many , many to many ...)
2.create db context class and define dbset inside Contextclass
3. setup connection string 
(
if we use same name as db context then no need to specify any aditional configuration but we won't follow it 
rather we will define a connection string by orselves as we need more control 
for eg: if we declare in connectionstring name="Defaultconnection" then we need to add in Datacontext Class
Public MainContext():base("name=DefaultConnection")

)
initial catalogue hochhe database name
4.migration 
