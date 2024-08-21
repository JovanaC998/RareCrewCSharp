using Microsoft.AspNetCore.Mvc;
using RareCrewC_.Services;
using RareCrewC_.Models;
using System.Threading.Tasks;

public class EmployeeController : Controller
{
    private readonly ApiService _apiService;
    private readonly EmployeeService _employeeService;

    public EmployeeController(ApiService apiService, EmployeeService employeeService)
    {
        _apiService = apiService;
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Index()
    {
        var employees = await _apiService.GetEmployeesAsync();
        var groupedData = _employeeService.GetGroupedEmployeeData(employees);

       
        return View(groupedData);
    }
}
