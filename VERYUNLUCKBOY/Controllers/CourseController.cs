using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace VERYUNLUCKBOY.Controllers
{
    /// <summary>
    /// Get list of courses
    /// </summary>
    [ApiController]
    public class CoursesController : ControllerBase
    {
        /// <summary>
        /// get list of courses
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet, Route("courses")]
        public string GetCourses()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string jsonPath = config["PathFile"];
            if (System.IO.File.Exists(jsonPath))
            {
                string content = System.IO.File.ReadAllText(jsonPath);
                return content;
            }
            else
            {
                throw new Exception("aaaaaa");
            }
        }

        /// <summary>
        /// Get list of courses by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet, Route("courses/{name}")]
        public string GetCoursesByName(string name)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string jsonPath = config["PathFile"];
            if (System.IO.File.Exists(jsonPath))
            {
                string content = System.IO.File.ReadAllText(jsonPath);

                var courses = JsonConvert.DeserializeObject < List < Course>>(content);
                var result = courses.Where(p => p.Name.Contains(name));

                string jsonResult = JsonConvert.SerializeObject(result);

                return jsonResult;
            }
            else
            {
                throw new Exception("Скидыщ");
            }
        }
    }
}

