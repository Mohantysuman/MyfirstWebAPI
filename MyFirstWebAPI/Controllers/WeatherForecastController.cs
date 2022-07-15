using Intuit.Ipp.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        static List<Employee> employeeList = new();
        #region 28[HttpPost]
        public ActionResult WriteFromBody([FromBody] Employee employee)
        {
            Employee.Add(new Employee { Id = employee.Id, Name = employee.Name, Address = employee.Address, age = employee.age });
            return Ok("Employee");
        }

        [HttpPost]
        public ActionResult ReadFromQuery([FromQuery] Employee employee)
        {
            return Ok($"My name is:{employee.Name} and address is:{employee.Address}");
        }

        [HttpGet]
        public ActionResult ReadFromHeader([FromHeader] string name, [FromHeader] string address)
        {
            return Ok($"My name is:{name} and address is:{address}");
        }

        [HttpGet("{title}/{name}/{address}")]
        public ActionResult ReadFromRoute(string title, string name, [FromQuery] string address)
        {
            return Ok($"My Title is: {title} and My name is: {name} and address is: {address}");
        }
        [HttpPost]
        public ActionResult WriteFromQuery(int marks)
        {
            return Ok("New Employee Added!");
        }
        #endregion
        //MODEL BINDING USING STRING AND QUERY
        #region 27
        [HttpGet]
        public ActionResult GetFromUri([System.Web.Http.FromUri] string name, [System.Web.Http.FromUri] string address)
        {
            Employee employee = new Employee();
            employee.Name = name;
            employee.Address = address;


            var serializedOutput = JsonConvert.SerializeObject(employee);
            return Ok(serializedOutput);
        }

        //----*FROM BODY***-----//

        [HttpGet]

        public ActionResult GetFromBody([System.Web.Http.FromBody] Employee employee)
        {
            return Ok($"Employee Name is: {employee.Name} and employee address is: {employee.Address}");
        }

        [HttpPost]
        public ActionResult AddEmployee(int age)
        {
            return Ok("New Employee Added!");
        }

        //---DELETE FROM URI--//

        [HttpDelete("{id}")]
        public ActionResult RemoveEmployeeFromUri(int Id)
        {
            var editEmployee = employeeList.Where(obj => obj.Id == Id).FirstOrDefault();
            if (editEmployee != null)
            {
                employeeList.Remove(editEmployee);

                return Ok($"EmpId: {Id} removed from employee list.");
            }
            else
            {
                return Ok($"EmpId: {Id} not found");
            }

        }

        //-----**FROM BODY*---//

        [HttpDelete]
        public ActionResult GetItFromBody([System.Web.Http.FromBody] Employee employee)
        {
            return Ok($"Employee Id is: {employee.Id}");
        }

        //----PUT FROM URI---//

        [HttpPut]
        public ActionResult UpdateAEmployeeFromUri(int Id, string Name, string Address)
        {
            var editEmployee = employeeList.Where(obj => obj.Id == Id).FirstOrDefault();
            if (editEmployee != null)
            {
                editEmployee.Name = Name;

                editEmployee.Address = Address;

                return Ok($"EmpId: {Id} details updated.");
            }
            else
            {
                return Ok($"EmpId: {Id} not found");

            }
        }

        //-----**FROM BODY**----//
        [HttpPut]

        public ActionResult GetItByFromBody([System.Web.Http.FromBody] Employee employee)
        {
            return Ok($"Employee Id is: {employee.Id} and Employee Name is:{employee.Name} and Employee Address is:{employee.Address}");
        }
        #endregion
        #region 26
        [HttpPost]
        public ActionResult AddAEmployee(int EmpId, string EmployeeName, string EmployeeAddres)
        {
            employeeList.Add(new Employee { Id = EmpId, Name = EmployeeName, Address = EmployeeAddres });
            int i = employeeList.Count();
            return Ok("New Employeed Added!!");
        }


        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            employeeList = new List<Employee>();
            employeeList.Add(new Employee { Id = 100, Name = "Akash", Address = "Lko" });
            return Ok(employeeList);
        }
        [HttpPut]
        public ActionResult UpdateAEmployeeDetails(int Id, string Name, string Address)
        {
            var editEmployee = employeeList.Where(obj => obj.Id == Id).FirstOrDefault();
            if (editEmployee != null)
            {
                editEmployee.Name = Name;

                editEmployee.Address = Address;

                return Ok($"EmpId: {Id} details updated.");
            }
            else
            {
                return Ok($"EmpId: {Id} not found");

            }
        }
        [HttpDelete]
        public ActionResult RemoveEmployee(int Id)
        {
            var editEmployee = employeeList.Where(obj => obj.Id == Id).FirstOrDefault();
            if (editEmployee != null)
            {
                employeeList.Remove(editEmployee);

                return Ok($"EmpId: {Id} removed from employee list.");
            }
            else
            {
                return Ok($"EmpId: {Id} not found");
            }

        }
        #endregion
    }
}
