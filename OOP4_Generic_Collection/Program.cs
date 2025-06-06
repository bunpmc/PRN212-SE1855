﻿/*
 * Su dung Generic List de quan ly nhan su
 * thuc hien day du cac tinh nang CRUD
 * C-CREATE
 * R-READ/RETRIEVE: search, find, sort,...
 * U-UPDATE
 * D-DELETE
 */

//Cau 1: Create

using OOP2;

List<Employee> employees = new List<Employee>();
FulltimeEmployee e1 = new FulltimeEmployee();
e1.Id = 1;
e1.Name = "B";
e1.IdCard = "123";
e1.Birthday = new DateTime(1999, 12, 12);
employees.Add(e1);

FulltimeEmployee e2 = new FulltimeEmployee();
e2.Id = 2;
e2.Name = "K";
e2.IdCard = "128";
e2.Birthday = new DateTime(1991, 12, 12);
employees.Add(e2);

FulltimeEmployee e3 = new FulltimeEmployee();
e3.Id = 3;
e3.Name = "A";
e3.IdCard = "121";
e3.Birthday = new DateTime(1979, 12, 12);
employees.Add(e3);

FulltimeEmployee e4 = new FulltimeEmployee();
e4.Id = 4;
e4.Name = "D";
e4.IdCard = "126";
e4.Birthday = new DateTime(1899, 12, 12);
employees.Add(e4);

PartimeEmployee e5 = new PartimeEmployee();
e5.Id = 5;
e5.Name = "DA";
e5.IdCard = "116";
e5.Birthday = new DateTime(2000, 12, 12);
e5.WorkingHour = 3;
employees.Add(e5);

//Cau 2: READ
employees.ForEach(e=>Console.WriteLine(e));

foreach  (var employee in employees)
{
    Console.WriteLine(employee);
}

//Cau 3: Loc ra nhan su chinh thuc va tinh tong chi phi, tong luong
List<FulltimeEmployee> fe_list = employees.OfType<FulltimeEmployee>().ToList();
Console.WriteLine("Nhan su chinh thuc/ Fulltime");
fe_list.ForEach(e=>Console.WriteLine(e));

//hoac

List<FulltimeEmployee> fe_list2 = new List<FulltimeEmployee>();

foreach (var emp in employees)
{
    if(emp is FulltimeEmployee)
    {
        fe_list2.Add(emp as FulltimeEmployee);
    }
}

//Tong luong
double sum_salary = 0;

foreach (var fe in fe_list2)
{
    sum_salary += fe.calSalary();
}
Console.WriteLine($"{sum_salary}");
//hoac

double sum_salary2 = fe_list2.Sum(e => e.calSalary());
Console.WriteLine($"{sum_salary2}");


//Cau 4: Sorting by Birthday

for (int i = 0; i < employees.Count; i++ )
{
    for (int j = i + 1; j < employees.Count; j++ )
    {
        Employee ei = employees[i];
        Employee ej = employees[j];
        if(ei.Birthday > ej.Birthday)
        {
            employees[i] = ej;
            employees[j] = ei;
        }
    }
}

employees.ForEach(e => Console.WriteLine(e));

//Cau 5: UPDATE NAME
Console.WriteLine("==========Update Name===========");
string name = "A";

foreach (var e in employees)
{
    if (e.Name.Equals(name))
    {
        Console.WriteLine($"Enter a new name for Employee \n {e.ToString()}: ");
        e.Name = Console.ReadLine();
        Console.WriteLine("Employee after rename: ");
        Console.WriteLine(e);
    }
}

//Cach 2
Console.WriteLine("===========Rename cach 2===========");
name = "B"; 
Employee employ = employees.Find(e => e.Name.ToLower().Equals(name.ToLower()));

Console.WriteLine("Before rename: ");
Console.WriteLine(employ.ToString());

if (employ != null)
    employ.Name = "C";

Console.WriteLine("After rename: ");
Console.WriteLine(employ.ToString());

//Cau 6: DELETE
Console.WriteLine("==========Delete===========");
Console.WriteLine("List before delete: ");
employees.ForEach(e => Console.WriteLine(e));

Employee em = employees.Find(e => e.Name.ToLower().Equals("DA".ToLower()));
employees.Remove(em);

Console.WriteLine("List after delete: ");
employees.ForEach(e => Console.WriteLine(e));
