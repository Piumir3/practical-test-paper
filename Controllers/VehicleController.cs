using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNefc.Models;
using System.Collections.Generic;

namespace WebApplicationNefc.Controllers
{
    public class VehicleController : Controller
    {
        private readonly DBContext DbContext;

        public VehicleController(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicles = await DbContext.Vehicles.Include(v => v.Colors).OrderBy(v => v.ModelName).ToListAsync();
            return View(vehicles);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddVehicle addVehicleRequest)
        {
            // Check if a vehicle with the same registration number already exists
            if (DbContext.Vehicles.Any(v => v.RegNo == addVehicleRequest.RegNo))
            {
                ModelState.AddModelError("RegNo", "A vehicle with the same registration number already exists.");
            }

            // Check if ModelName is empty
            if (string.IsNullOrWhiteSpace(addVehicleRequest.ModelName))
            {
                ModelState.AddModelError("ModelName", "Model name is required.");
            }

            // Check if NumberOfSeats is greater than or equal to 1000
            if (addVehicleRequest.NumberOfSeats >= 1000)
            {
                ModelState.AddModelError("NumberOfSeats", "Number of seats should be less than 1000.");
            }

            if (ModelState.IsValid)
            {
                var vehicle = new Vehicle()
                {
                    RegNo = addVehicleRequest.RegNo,
                    ModelName = addVehicleRequest.ModelName,
                    NumSeats = addVehicleRequest.NumberOfSeats,
                };

                // Split the comma-separated colors into a list
                List<string> colorsList = addVehicleRequest.Colors.Split(',').ToList();

                // Save the list of colors to the vehicle
                if (colorsList.Count > 0)
                {
                    vehicle.Colors = new List<Color>();
                    foreach (var colorName in colorsList)
                    {
                        vehicle.Colors.Add(new Color
                        {
                            ColorName = colorName
                        });
                    }
                }

                DbContext.Vehicles.Add(vehicle);
                DbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            // If there are any errors in ModelState, return the view with error messages
            return View(addVehicleRequest);
        }
    }
}
