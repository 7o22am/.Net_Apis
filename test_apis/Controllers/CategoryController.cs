using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_apis.Data;
using Microsoft.EntityFrameworkCore;
using test_apis.Data.Model;
using Microsoft.AspNetCore.Authorization;
namespace test_apis.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
 
    public class CategoryController : ControllerBase
    {


        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var cats = await _db.Categories.ToListAsync();
            return Ok(cats);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCategories(int id )
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(c);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(string category)
        {
            Category c = new() { Name = category };
            await _db.Categories.AddAsync(c);
            _db.SaveChanges();
            return Ok(c);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);
            if (c == null)
            {
                return NotFound($"Category Id {category.Id} not exists ");
            }
            c.Name = category.Name;
            _db.SaveChanges();
            return Ok(c);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteCategories(int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            {
                return NotFound($"Category Id {id} not exists ");
            }
            
            _db.Categories.Remove(c);
            _db.SaveChanges();
            return Ok(c);
        }

    }
}
