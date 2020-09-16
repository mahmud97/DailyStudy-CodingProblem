# Table of Contents  
- [Join of Linq query  ](#Linq) 
- [Join Example](#Join) 
- [Cross Join](#Cross) 
- [Ways to replace NULL in sql server ](#Null) 
- [Union and UnionAll](#Union) 
- [difference between union and join](#diff) 
- [Store Procedure   ](#Sp) 
- [Stored Procedure with parameters](#SpwithPm) 
- [Advantage of Store Procedure](#advasp) 
- [Grouping](#grp)








<a name="Linq"/>
 
 # Linq query Join Example 

        public PropertyListsVM GetResidentialPropertyList(int ? page)
        {

            var ob = new PropertyListsVM();
            ob.PropertyLists = new List<PropertyLists>();

            var res = from ap in context.ArProperty
                      join aid in context.ArImageDetails on ap.ListingId equals aid.ListingId
                      join al in context.ArListing on ap.ListingId equals al.ListingId
                      join afs in context.ArForSale on ap.ListingId equals afs.ListingId
                      join c in context.Clients on al.ListingId equals c.ClientId
                      join afr in context.ArForRent on al.ListingId equals afr.ListingId
                      where al.ListingType == 1 &&
                      (!string.IsNullOrEmpty(aid.FileName)) &&
                      (afs.Price != null) &&
                      (ap.LandSizeSqm != null && ap.Bedroom != null && ap.Bathroom != null && ap.Carport != null)
                      orderby ap.ListingId, afs.PriceRangeFrom,afs.Price
                      select new PropertyLists
                      {
                          ListingId = ap.ListingId,
                          Bedroom = ap.Bedroom,
                          Bathroom = ap.Bathroom,
                          Carport = ap.Carport,
                          ImageUrl = aid.FileName,
                          PropertyAddress = al.PropertyAddress,
                          StreetName = al.StreetName,
                          UnderOffer = al.Body,
                          PriceFrom = Decimal.Truncate((afs.PriceRangeFrom).HasValue ? (afs.PriceRangeFrom).Value : 0),
                          Price = Decimal.Truncate((afs.Price).HasValue ? (afs.Price).Value : 0),
                          AgentName = c.ClientName,
                          AgentAddress = c.Address,
                          AgentPhone = c.Phone,
                          AgentEmail = c.Email,
                          Authority = afs.Authority,
                          LandSize = Decimal.Truncate((ap.LandSizeSqm).HasValue ? (ap.LandSizeSqm).Value : 0),
                          SecurityBond = afr.SecurityBond,
                          Condition = afr.Conditions,
                          CoolingType = ap.CoolingType,
                      };
            ViewBag.cnt = res.Count();
            ob.PropertyLists = res.ToList();
            var pager = new Pager(ob.PropertyLists.Count(), page);
            var model = new PropertyListsVM
            {
                PropertyLists = ob.PropertyLists.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager

            };

            return model;

        }
      
   <a name="Join"/>
   
   # Join Example
   select s.id , s.namee , t.name , t.coursename
   from student s join teacher t 
   on s.id==t.id
   where t.coursename="algorithm"
   
   <a name="Cross"/>
   
   # A cross join can not have on clause 
   select s.id , s.namee , t.name , t.coursename
   from student s cross join teacher t
   
   ## a cross join return the cartesian product : no of rows first table * no of rows second table 
   - so if first and second table have 3 rows then the result will be 3*3 = 9 rows of cross join 
   - if its a self join lets say table a have five rows then if we self cross join table a it will return 5*5 = 25 
   
   <a name="Null">
 
   # ways to replace NULL in sql server 
   - using ISNULL function we can replace null eg : select ISNULL(NULL, 'No values')
   - now how to use it in query ??
   ans :  select s.id , s.namee , ISNULL(t.name, 'No values') , t.coursename
   from student s cross join teacher t
   
   <a name="Union">
    
   # Union and Union All 
   - Union opearation korar jonno 2 ta table ar data type , column name , column name order sob identical hote hobe 
   - UnionAll : unionall korle 2 ta table ar data marge korbe even if the two table have same values 
   Union : union korle 2 ta table ar data marge korbe but not repeat the same value like unionall
   
   <a name="diff">
   
   # difference between union and join 
   - Join operation combines columns from two or more tables 
   - Union opearatioin combines rows from two or more tables  
   
   <a name="Sp">
   
   # Stored Procedure 
   - If we have a situation where we have to use the same query again and again then we can simply save the query as stored procedure and call it by name 
   eg: 
      -  Create PPROCEDURE spGetEmployee
      -  AS
      -  BEGIN
      -       select Name , Gender from tblEmployee
      -  END
        
   - Now if we want to execute store procedure then simply just call it by name in SQL Server
        spGetEmployee
        
   <a name="SpwithPm">     
        
   # Stored Procedure with parameters 
    eg: 
        Create PPROCEDURE spGetEmployeeByGenderAndDepartment
        @Gender nvarchar(20)
        @DepartmentId int
        AS
        BEGIN
        select Name , Gender , DepartmentId from tblEmployee where Gender = @Gender and DepartmentId= @DepartmendId
        END
    
  - Now if we want to execute store procedure then simply just call it by name with parameter in SQL Server
        spGetEmployeeByGenderAndDepartment 'Male' , 1 
   
  <a name="advasp"> 
   
  # Advantage of Store Procedure 
 - Code reusability 
 - Better Maintanability  
   
   
        
        
   
   # Indexes 
   - We use indexes to find data quickly 
   - Create Index indexname on tablename (columnname asc) . we can also create index by right click and select new indexes on indexes folder 
   - To know details : https://csharp-video-tutorials.blogspot.com/2012/09/clustered-and-non-clustered-indexes.html
   
   # Clustered Index 
   - A clustered index determines the physical order of data in a table. For this reason, a table can have only one clustered index. 
   - Inspite, of inserting the rows in a random order, when we execute the select query we can see that all the rows in the table are 
    arranged in an ascending order based on the Id column. This is because a clustered index determines the physical order of data in a table, 
    and we have got a clustered index on the Id column.
    
   # Non Clustered Index
   - A nonclustered index is analogous to an index in a textbook. The data is stored in one place, the index in another place. 
   - Since, the nonclustered index is stored separately from the actual data, a table can have more than one non clustered index
   
   
   # Difference between Clustered and NonClustered Index:
   - Only one clustered index per table, where as you can have more than one non clustered index
   - Clustered index is faster than a non clustered index, because, the non-clustered index has to refer back to the table, if the selected column is not present in the index.
   - Clustered index determines the storage order of rows in the table, and hence doesn't require additional disk space, but where as a Non Clustered index is stored seperately   from the table, additional storage space is required.
   
   # Unique index
   - Unique index is used to enforce uniqueness of key values in the index
   - So, the UNIQUE index is used to enforce the uniqueness of values and primary key constraint.

# advantages and disadvantages of indexes
- Indexes can also help queries, that ask for sorted results. 

# Diadvantages of Indexes:
Additional Disk Space: Clustered Index does not, require any additional storage. Every Non-Clustered index requires additional space as it is stored separately from the table.The amount of space required will depend on the size of the table, and the number and types of columns used in the index.
   
   
   # Normalization 
   - Database normalization is the process of organizing data to minimize data redundancy (data duplication), which in turn ensures data consistency.
   https://csharp-video-tutorials.blogspot.com/2012/09/database-normalization-part-52.html
   
   
- Q : how to normalize ?   Ans : We separate columns from the table which contains redundant data  and create another table with the separated columns
- Database normalization is a step by step process. There are 6 normal forms, First Normal form (1NF) thru Sixth Normal Form (6NF). Most databases are in third normal form (3NF). There are certain rules, that each normal form should follow.


# Query Optimization 
- there is no hard and first rule of query optimization
- How can I write optimized query ? As much as I know about writing optimized query
- indexing (clustered , non clustered)
- Query designing (avoiding asterisk * selecting only the required columns instead of all , avoiding to join different data types as type conversion takes time, etc)
- Execution plan (This can be achieved using  SQL server tools  


# Query Filter
-  using where clause we filter data in query
- You can use the familiar C# logical AND and OR operators to apply as many filter expressions as necessary in the where clause. For example, to return only customers from "London" AND whose name is "Devon" you would write the following code:

eg: 
   where cust.City == "London" && cust.Name == "Devon"

<a name="grp"/>
   
   # Grouping 
   The group clause enables you to group your results based on a key that you specify. 
   For example you could specify that the results should be grouped by the City so that all customers from London or Paris are in individual groups. 
   In this case, cust.City is the key.
   
   When you end a query with a group clause, your results take the form of a list of lists. 
   Each element in the list is an object that has a Key member and a list of elements that are grouped under that key.
