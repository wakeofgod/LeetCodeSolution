--175 ���������
select p.FirstName,p.LastName,ad.City,ad.State from Person p 
left join Address ad on p.PersonId=ad.PersonId
--176 �ڶ��ߵ�нˮ
SELECT MAX(Salary) as SecondHighestSalary   FROM Employee 
WHERE Salary NOT IN
(SELECT MAX(Salary) FROM Employee);
--177 ��д���ݿ⺯������ȡ��n�ߵ�нˮ
CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        /* Write your T-SQL query statement below. */
      SELECT MAX(Salary) FROM Employee E1
      WHERE @N - 1 =
      (SELECT COUNT(DISTINCT(E2.Salary)) FROM Employee E2
      WHERE E2.Salary > E1.Salary)
    );
END
--178 ��������
select t1.Score ,(select count(DISTINCT Score) from Scores t2 where t2.Score>t1.Score)+1 as Rank
from Scores  t1
order by t1.Score DESC
--180 �����������ε�����
select distinct l1. Num as ConsecutiveNums 
from Logs l1
left join Logs l2 on l1.id=l2.id-1
left join Logs l3 on l1.id=l3.id-2
where l1.Num=l2.Num and l1.Num=l3.Num
--181 �������������Ա��
select Name as Employee  from Employee e1
where e1.Salary > (select Salary from Employee e2 where e1.ManagerId =e2.Id)

--�������Ч�ʸ���
Select e1.Name as Employee from Employee e1 , Employee e2  where e1.ManagerId = e2.Id and e1.Salary > e2.Salary

--185 �����Ź�����ߵ�ǰ��λԱ��
--��ʱ1266 ms
Select d.Name as Department, e.Name as Employee, e.Salary 
from Department d, Employee e 
where e.DepartmentId = d.Id and (
    Select count(distinct Salary) From Employee where DepartmentId=d.Id and Salary > e.Salary
)<3
order by Department ,salary DESC
--��ʱ1485ms
SELECT D1.Name Department, E1.Name Employee,  E1.Salary
FROM Employee E1, Employee E2, Department D1
WHERE E1.DepartmentID = E2.DepartmentID
AND E2.Salary >= E1.Salary 
AND E1.DepartmentID = D1.ID      
GROUP BY E1.Name,D1.Name,E1.Salary
HAVING COUNT(DISTINCT E2.Salary) <= 3
ORDER BY D1.Name, E1.Salary DESC;
--182 �����ظ�������
select distinct Email from Person p1 
where (select count(*) from Person p2 where p1.Email=p2.Email ) >1
--�������Ч�ʵ�
select Email from Person
group by Email
having count(*)>1
--183�Ӳ������Ŀͻ�
select Name as Customers from Customers where id not in (select CustomerId from Orders)
--���ӻ�Ƚ���
select c.name Customers
from Customers c
left join Orders o on o.CustomerId = c.Id
where o.CustomerId is NULL
--184���Ҳ��Ź�����ߵ�Ա��
select d.Name as Department,  e.Name as Employee,e.Salary from Employee e,Department d
where e.DepartmentId=d.Id and e.Salary =(select max(Salary) from Employee  where DepartmentId=d.Id)

--196 ��дһ�� SQL ��ѯ����ɾ�� Person ���������ظ��ĵ������䣬�ظ���������ֻ���� Id ��С ���Ǹ���
DELETE p1  
FROM Person p1, Person p2  
WHERE p1.Email = p2.Email AND  
p1.Id > p2.Id
--�������Ч�ʸ�
DELETE FROM Person WHERE Id NOT IN
(SELECT Id FROM (SELECT MIN(Id) Id FROM Person GROUP BY Email) p)

--197�������¶�
select w1.Id from Weather w1,Weather w2
where datediff(day, w1.RecordDate,w2.RecordDate)=-1 and w1.Temperature>w2.Temperature

--595��Ĺ���
select name,population ,area from world where area>3000000 or population>25000000

select name,population ,area from world where area>3000000 
UNION
select name,population ,area from world where population>25000000

--596 ����5��ѧ���Ŀ�
select class from courses 
group by class
having count(distinct student)>=5

--601 �����ݵ�������
--sql����û�в�ѯ��������ģ���������ֻȡ�˵�һ��
select s1.id,s1.visit_date,s1.people from stadium s1
left join stadium s2 on datediff(DAY,s1.visit_date,s2.visit_date)=-1
left join stadium s3 on datediff(DAY,s2.visit_date,s3.visit_date)=-1
where s1.people>100 and s2.people>100 and s3.people>100

select distinct s1.*from stadium s1, stadium s2, stadium s3 
WHERE s1.people >= 100 and s2.people>= 100 and s3.people >= 100 
AND(    
(s1.id - s2.id = 1 and s2.id - s3.id =1) 
  or   (s2.id - s1.id = 1 and s1.id - s3.id =1) 
     or   (s3.id - s2.id = 1 and s2.id - s1.id = 1)
 ) 
 ORDER by s1.id;

 --626 ����λ ������id�Ӽ�һ��ע�����һλ�ǲ���������û�п��滻��
 select s.id,s.student from
(
select id-1 as id,student from seat where id%2=0
    union
select id+1 as id,student from seat where id%2=1 and id!=(select count(*) from seat)
    union
select id as id,student from seat where id%2=1 and id=(select count(*) from seat)    
)
as s
order by s.id
--�򵥵�д��
select 
(
case when id%2!=0 and id!=counts then id+1
     when id%2!=0 and id=counts then id
     else id-1 end
)as id,student
from seat,(select count(*) as counts from seat ) as seat_counts
order by id