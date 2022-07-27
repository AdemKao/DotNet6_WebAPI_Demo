using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6_WebAPI_Demo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero{
                Id=1,
                Name="Spider Man",
                FirstName="Peter",
                LastName="Parker",
                Place="New York City"
            },
            new SuperHero{
                Id=2,
                Name="IronMan",
                FirstName="Tony",
                LastName="Stark",
                Place="Long Island"
            }
        };
    private readonly DataContext _context;

    public SuperHeroController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    //public async Task<IActionResult> Get()
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        //return Ok(heroes);
        return Ok(await _context.SuperHeroes.ToListAsync());

    }
    [HttpGet("{id}")]
    //public async Task<IActionResult> Get()
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
        //var hero = heroes.Find(hero => hero.Id == id);
        var hero = await _context.SuperHeroes.FindAsync(id);

        if (hero == null)
            return BadRequest("Hero not found.");
        return Ok(hero);
    }
    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> addHero([FromBody]SuperHero hero)
    {
        //heroes.Add(hero);
        //return Ok(heroes);
        try
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok(await _context.SuperHeroes.ToListAsync());
    }
    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> updateHero([FromBody] SuperHero heroRequest)
    {
        var hero = heroes.Find(hero => hero.Id == heroRequest.Id);
        if (hero == null)
            return BadRequest("Hero not found.");

        hero.Name = heroRequest.Name;
        hero.FirstName = heroRequest.FirstName;
        hero.LastName = heroRequest.LastName;
        hero.Place = heroRequest.Place;

        return Ok(heroes);
    }

    [HttpDelete("{id}")]
    //public async Task<IActionResult> Get()
    public async Task<ActionResult<List<SuperHero>>> Delete(int id)
    {
        var hero = heroes.Find(hero => hero.Id == id);
        if (hero == null)
            return BadRequest("Hero not found.Can't be deleted");
        heroes.Remove(hero);
        return Ok(heroes);
    }
}
