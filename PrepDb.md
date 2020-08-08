
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
        
   # Join Example
   select s.id , s.namee , t.name , t.coursename
   from student s join teacher t 
   on s.id==t.id
   where t.coursename="algorithm"
   
   # A cross join can not have on clause 
   select s.id , s.namee , t.name , t.coursename
   from student s cross join teacher t
   
   ## a cross join return the cartesian product : no of rows first table * no of rows second table 
   - so if first and second table have 3 rows then the result will be 3*3 = 9 rows of cross join 
   - if its a self join lets say table a have five rows then if we self cross join table a it will return 5*5 = 25 
   
   # ways to replace NULL in sql server 
   - using ISNULL function we can replace null eg : select ISNULL(NULL, 'No values')
   - now how to use it in query ??
   ans :  select s.id , s.namee , ISNULL(t.name, 'No values') , t.coursename
   from student s cross join teacher t
   
   # Union and Union All 
   - Union opearation korar jonno 2 ta table ar data type , column name , column name order sob identical hote hobe 
   - UnionAll : unionall korle 2 ta table ar data marge korbe even if the two table have same values 
   Union : union korle 2 ta table ar data marge korbe but not repeat the same value like unionall
   
   # difference between union and join 
   - Join operation combines columns from two or more tables 
   - Union opearatioin combines rows from two or more tables  
   
   # Stored Procedure 
   - If we have a situation where we have to use the same query again and again then we can simply save the query as stored procedure and call it by name 
   eg: 
        Create PPROCEDURE spGetEmployee
        AS
        BEGIN
             select Name , Gender from tblEmployee
        END
        
   - Now if we want to execute store procedure then simply just call it by name in SQL Server
        spGetEmployee
        
    
        
   
        
        
   
   
   
   
   
   
