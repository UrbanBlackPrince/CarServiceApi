using CarServiceWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarServiceWebApp.Controllers
{
    public class CarServiceController : Controller
    {
        #region Private Fields and Constructors

        Uri baseAdress = new Uri("https://localhost:7077/api");
        private readonly HttpClient _client;

        public CarServiceController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
        }

        #endregion Private Fields and Constructors

        #region Public Action Results

        [HttpGet]
        public IActionResult GetAllCars()
        {
            List<CarViewModel> cars = new List<CarViewModel>();
            HttpResponseMessage responce = _client.GetAsync(_client.BaseAddress + "/car/GetCars").Result;

            if (responce.IsSuccessStatusCode)
            {
                string data = responce.Content.ReadAsStringAsync().Result;
                cars = JsonConvert.DeserializeObject<List<CarViewModel>>(data);
            }

            return View("/Views/Home/AllCars.cshtml", cars);
        }


        [HttpGet]
        public IActionResult AddCar()
        {
            CarViewModel carViewModel = new CarViewModel();

            return View("/Views/Home/_AddCarPartial.cshtml", carViewModel);
        }


        [HttpPost]
        public IActionResult AddCar(CarViewModel viewModel)
        {
            string data = JsonConvert.SerializeObject(viewModel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage responce = _client.PostAsync(_client.BaseAddress + "/car/AddCar", content).Result;

            if (responce.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Car Added!";

                return RedirectToAction("GetAllCars");
            }

            return View();
        }


        [HttpGet]
        public IActionResult EditCar(Guid id)
        {
            CarViewModel carViewModel = new CarViewModel();

            HttpResponseMessage responce = _client.GetAsync(_client.BaseAddress + "/car/GetCar/" + id).Result;

            if (responce.IsSuccessStatusCode)
            {
                string data = responce.Content.ReadAsStringAsync().Result;
                carViewModel = JsonConvert.DeserializeObject<CarViewModel>(data);
            }

            return View("Views/Home/_EditCarPartial.cshtml", carViewModel);
        }


        [HttpPost]
        public IActionResult EditCar(CarViewModel carViewModel)
        {
            string data = JsonConvert.SerializeObject(carViewModel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            Guid id = carViewModel.Id;
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/car/UpdateCar/" + id, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Car Updated!";

                return RedirectToAction("GetAllCars");
            }

            return View();
        }


        [HttpGet]
        public IActionResult DeleteCar(Guid id)
        {
            CarViewModel carViewModel = new CarViewModel();
            HttpResponseMessage responce = _client.GetAsync(_client.BaseAddress + "/car/GetCar/" + id).Result;

            if (responce.IsSuccessStatusCode)
            {
                string data = responce.Content.ReadAsStringAsync().Result;
                carViewModel = JsonConvert.DeserializeObject<CarViewModel>(data);

            }

            return View("/Views/Home/_DeleteCarPartial.cshtml", carViewModel);
        }


        [HttpPost]
        public IActionResult DeleteCarConfirmed(Guid id)
        {
            HttpResponseMessage responce = _client.DeleteAsync(_client.BaseAddress + "/car/DeleteCar/" + id).Result;

            if(responce.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllCars");
            }

            return View();
        }

        #endregion Public Action Results
    }
}
