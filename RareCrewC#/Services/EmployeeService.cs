using RareCrewC_.Models;
using System.Collections.Generic;
using System.Linq;

public class EmployeeService
{
    public IEnumerable<GroupedEmployeeData> GetGroupedEmployeeData(IEnumerable<Employee> employees)
    {
        var groupedData = employees
            .GroupBy(e => string.IsNullOrEmpty(e.EmployeeName) ? "No name" : e.EmployeeName)
            .Select(g => new GroupedEmployeeData
            {
                EmployeeName = g.Key,
                TotalHoursWorked = Math.Ceiling(
                    g.Sum(e => Math.Max(0, (e.EndTimeUtc - e.StarTimeUtc).TotalHours))
                )
            })
            .OrderByDescending(data => data.TotalHoursWorked) 
            .ToList();

        var totalHours = groupedData.Sum(data => data.TotalHoursWorked);

        foreach (var data in groupedData)
        {
            data.Percentage = totalHours > 0 ? (data.TotalHoursWorked / totalHours) * 100 : 0;
        }

        return groupedData;
    }
}
