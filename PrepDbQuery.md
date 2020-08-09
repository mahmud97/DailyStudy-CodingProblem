# Question 1: SQL Query to find second highest salary of Employee
- Ans : selecet max(salary) from employee where salary < selecet max(salary) from employee

# Question 2: SQL Query to find Max Salary from each department
- Ans : select max(salary) from Employee group by dept_id

- These questions become more interesting if Interviewer will ask you to print department name instead of department id, in that case, you need to join Employee table with Department using foreign key DeptID, make sure you do LEFT or RIGHT OUTER JOIN to include departments without any employee as well.  Here is the query

    - Ans : select d.DeptName ,e.salary 
      from Department d join Employee e
      on d.deptid = e.deptid




