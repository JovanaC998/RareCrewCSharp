using Microsoft.AspNetCore.Mvc;
using RareCrewC_.Services;
using RareCrewC_.Models;
using System.Threading.Tasks;

public class EmployeeController : Controller
{
    private readonly ApiService _apiService;
    private readonly EmployeeService _employeeService;
    private readonly ChartGenerator _chartGenerator;

    public EmployeeController(ApiService apiService, EmployeeService employeeService, ChartGenerator chartGenerator)
    {
        _apiService = apiService;
        _employeeService = employeeService;
        _chartGenerator = chartGenerator;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _apiService.GetEmployeesAsync();
        var groupedData = _employeeService.GetGroupedEmployeeData(employees);

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/employee_chart.png");
        _chartGenerator.GeneratePieChart(filePath, groupedData);

        return View(groupedData);
    }
}