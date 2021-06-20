using System;
using System.Collections.Generic;
using WorkerContracts.Entities.Enums;


class Worker
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }
    public WorkerLevel Level { get; set; }
    public Departament Departament { get; set; }
    public List<HourContract> Contracts { get; private set; } = new List<HourContract>();

    public Worker()
    {

    }


    public Worker(string name, double baseSalary, WorkerLevel level, Departament departament)
    {
        Name = name;
        BaseSalary = baseSalary;
        Level = level;
        Departament = departament;
    }

    public void addContracts(HourContract contract)
    {
        Contracts.Add(contract);

    }
    public void removeContracts(HourContract contract)
    {
        Contracts.Remove(contract);
    }

    public double income(int month, int year)
    {
        double sum = BaseSalary;

        foreach(HourContract contract in Contracts)
        {
            if(contract.Date.Year == year && contract.Date.Month == month)
            {
                sum += contract.totalValue();
            }
        }

        return sum;

    }

}
