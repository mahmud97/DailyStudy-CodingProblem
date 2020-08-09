#  SQL Query to find second highest salary of Employee
- Ans : selecet max(salary) from employee where salary < selecet max(salary) from employee

#  SQL Query to find Max Salary from each department
- Ans : select max(salary) from Employee group by dept_id

- These questions become more interesting if Interviewer will ask you to print department name instead of department id, in that case, you need to join Employee table with Department using foreign key DeptID, make sure you do LEFT or RIGHT OUTER JOIN to include departments without any employee as well.  Here is the query

    - Ans : select d.DeptName ,e.salary 
      from Department d join Employee e
      on d.deptid = e.deptid
      
 # : Write an SQL Query find number of employees according to gender  whose DOB is between 01/01/1960 to 31/12/1975.

- Ans : Select count(empid) from Employee
where dob between 01/01/1960 and 31/12/1975
group by gender

# Write an SQL Query to find name of employee whose name Start with ‘M’
- Ans : select Empname from Employee where Empname Like 'M%' 

# Write SQL Query to find duplicate values in a table?
- And : select name , email from Employeee where email in ( select email from Employee group by email having count(email)>1)

# There is a table which contains two column Student and Marks, you need to find all the students, whose marks are greater than average marks i.e. list of above average students.

- SELECT student, marks from table where marks > SELECT AVG(marks) from table)

# How do you find all employees which are also manager? You have given a standard employee table with an additional column mgr_id, which contains employee id of the manager.
- select e.empname from Employee e join Employee m on e.empid==m.mngrid 


