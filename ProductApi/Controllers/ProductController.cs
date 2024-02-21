using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private static readonly List<string> Customers = new List<string>
        {
            "Customer1", "Customer2", "Customer3" // Örnek veri
        };

        // Tüm müşterileri getir
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetCustomers()
        {
            return Ok(Customers);
        }

        // ID ile müşteri getir
        [HttpGet("{id}")]
        public ActionResult<string> GetCustomerById(int id)
        {
            if (id < 0 || id >= Customers.Count)
            {
                return NotFound("Müşteri bulunamadı.");
            }

            return Ok(Customers[id]);
        }

        // Yeni müşteri ekle
        [HttpPost]
        public ActionResult PostCustomer(string name)
        {
            Customers.Add(name);
            // Gerçek bir senaryoda, müşteri veritabanına eklenecek
            return CreatedAtAction(nameof(GetCustomerById), new { id = Customers.Count - 1 }, name);
        }
    }
}
