using Microsoft.AspNetCore.Mvc;
using lab4PL.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace lab4PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : Controller
    {
        List<PetModel> data = new List<PetModel>();
        private void AddData()
        {
            data.Add(new PetModel { name = "Petya", namePerson = "Ivan", species = "cat", age = 8 });
            data.Add(new PetModel { name = "Petya2", namePerson = "Ivan2", species = "cat", age = 8 });
            data.Add(new PetModel { name = "Petya3", namePerson = "Ivan3", species = "cat", age = 8 });
            data.Add(new PetModel { name = "Petya4", namePerson = "Ivan4", species = "cat", age = 8 });
            data.Add(new PetModel { name = "Petya5", namePerson = "Ivan5", species = "cat", age = 8 });
        }
        
        [HttpGet("GetCat")]
        public IActionResult GetCat()
        {
            AddData();
            if (data.Count != 0)
            {
                return Ok();
            }
            return ValidationProblem();
        }

        [HttpGet("GetCatContant")]
        public IResult GetCatContant(string name)
        {
            AddData();
            foreach (var pet in data)
            {
                if (pet.name == name)
                {
                    return Results.Content(pet.name + " " + pet.namePerson + " " + pet.species + " " + pet.age);
                }
            }
            return Results.Content("EROR");
        }

        [HttpGet("GetCatJson")]
        public IResult GetCatJson(string name)
        {
            AddData();
            foreach (var pet in data)
            {
                if (pet.name == name)
                {
                    return Results.Json(new {name = pet.name, namePerson = pet.namePerson, species = pet.species, age = pet.age });
                }
            }
            return Results.Content("EROR");
        }

        [HttpGet("GetCatPNG")]
        public async Task<IResult> GetCatPNG(string name)
        {
            AddData();
            if ("Petya" == name)
            {
                string path = "img/1.jpg";

                byte[] fileContent;
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    fileContent = new byte[stream.Length];
                    await stream.ReadAsync(fileContent, 0, (int)stream.Length);
                }

                string contentType = "image/jpeg";       // установка MIME-типа
                string downloadName = "winter_forest.jpg";  // установка загружаемого имени
                return Results.File(fileContent, contentType, downloadName);
            }
            string path1 = "img/2.jpg";

            byte[] fileContent1;
            using (var stream = new FileStream(path1, FileMode.Open))
            {
                fileContent1 = new byte[stream.Length];
                await stream.ReadAsync(fileContent1, 0, (int)stream.Length);
            }

            string contentType1 = "image/jpeg";       // установка MIME-типа
            string downloadName1 = "winter_forest.jpg";  // установка загружаемого имени
            return Results.File(fileContent1, contentType1, downloadName1);
        }


    }



}
