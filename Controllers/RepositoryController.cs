using Microsoft.AspNetCore.Mvc;
using XanutHeraxosneri.Data;
using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly Iapranq Rep;
        public RepositoryController(Iapranq a)
        {
            Rep = a;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Apranq>>> GetAllProduct()
            {
                try
                {
                    return Ok(await Rep.GetAllApranq());
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "The error is not from the database"
                        );
                }
            }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Apranq>> GetProduct(int id)
        {
            try {
                return Ok(await Rep.SearchAprancId(id));
                }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "The error is not from the database"
                    );
            }
        }

        [HttpPost]
        public async Task<ActionResult<Apranq>> CreateProduct(Apranq z)
        {
            try
            {
                if (z == null)
                {
                    return BadRequest();
                }

                var x = await Rep.AddApranq(z);

                return CreatedAtAction(nameof(GetProduct), new { id = x.Id }, x);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error not createt product");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Deleteproduct(int id)
        {
            try
            {
               if(id<=0)
                    return BadRequest();
               

           var s = await Rep.SearchAprancId(id);
                
                if(s==null)
                    return NotFound();
                

              if (s.Available >0)
                {
                    ModelState.AddModelError("Avalible", "Available in stock");
                    return BadRequest(ModelState);
                }
                
                    await Rep.DeleteApranc(id);
                    return Ok($"product id={id} is database delete");
                
            }
            catch(Exception)
            {
              return  StatusCode(StatusCodes.Status500InternalServerError,
                    "The error is not from the database");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Updateproduct(int id,Apranq z)
        {
            try
            {
                if (id <= 0 || z == null || z.Id!=id)
                    return BadRequest();


                var s = await Rep.SearchAprancId(id);

                if (s == null)
                    return NotFound();

                var result = await Rep.updateApranq(z);
                return Ok($" product id={id}updating");
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error dont can update"
                    );
            }
        
        }



        [HttpGet("{search}")]
 public async Task< ActionResult<IEnumerable<Apranq>>> Search(string? categoryname,string? modelName)
         {
            try
            {
            var results= await Rep.search(categoryname, modelName);
                
                return  Ok(results);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error don't can Search");
            }
         }

    }
}
