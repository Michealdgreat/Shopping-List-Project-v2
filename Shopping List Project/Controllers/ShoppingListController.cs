using Microsoft.AspNetCore.Mvc;
using ShoppingLibrary.DataAccess;
using ShoppingLibrary.ShoppingListModel;
using System.IdentityModel.Claims;

namespace Shopping_List_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingListController : ControllerBase
{
    private readonly IShopListData _data;
    private readonly int ListNumber;

    public ShoppingListController(IShopListData data)
    {
        _data = data;

    }

    private int getListNumber()
    {
        var UserIdText = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(UserIdText);

    }


    // GET: api/<ShoppingListController>
    [HttpGet("GetAllList")]
    public async Task<ActionResult<IEnumerable<ListModel>>> Get() //with ActionResult or IActionResult we can return multiple status code depending on what happen in this method
    {
       // var ListNumber = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; //Sub is the NameIdentifier in claims
        var output =  await _data.GetAllList(getListNumber());

        return Ok(output);
    }

    // GET api/GetOneList
    [HttpGet("GetOneList")]
    public async Task<ActionResult<ListModel>> GetOneList(int listId)
    {
        // var ListNumber = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var output = await _data.GetOneList(getListNumber(), listId);

        return Ok(output);

    }

    // POST api/CategoryName
    [HttpPost ("CategoryName")]
    public async Task<ActionResult<ListModel>> CategoryName([FromBody] string categoryName)
    {
       // var ListNumber = User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier)?.Value;

        var output = await _data.CategoryName(getListNumber(), categoryName);

        return Ok(output);
    }

    // POST api/Date
    [HttpPost ("Date")]
    public ActionResult<ListModel> Date([FromBody] string date)
    {
        throw new NotImplementedException();
    }

    // POST api/Budget
    [HttpPost ("Budget")]
    public ActionResult<ListModel> Budget([FromBody] double budget)
    {
        throw new NotImplementedException();

    }

    // POST api/StoreName
    [HttpPost("StoreName")]
    public ActionResult<ListModel> StroreName([FromBody] string storeName)
    {
        throw new NotImplementedException();

    }

    // POST api/ProductName
    [HttpPost ("ProductName")]
    public ActionResult<ListModel> ProductName([FromBody] string productName)
    {
        throw new NotImplementedException();

    }

    // POST api/Price
    [HttpPost ("Price")]
    public ActionResult<ListModel> Price([FromBody] double price)
    {
        throw new NotImplementedException();

    }

    // POST api/TotalSpent
    [HttpPost ("TotalSpent")]
    public ActionResult<ListModel> TotalSpent([FromBody] double totalSpent)
    {
        throw new NotImplementedException();

    }

    // POST api/ExcessMoney
    [HttpPost ("ExcessMoney")]
    public ActionResult<ListModel> ExcessMoney([FromBody] double excessMoney)
    {
        throw new NotImplementedException();

    }

    // POST api/SavedMoney
    [HttpPost("SavedMoney")]
    public ActionResult<ListModel> SavedMoney([FromBody] double savedMoney)
    {
        throw new NotImplementedException();

    }

    // POST api/AddNote
    [HttpPost ("AddNote")]
    public ActionResult<ListModel> AddNote([FromBody] string addNote)
    {
        throw new NotImplementedException();

    }

    // PUT api/SaveList
    [HttpPut("SaveList")]
    public IActionResult SaveList(int listNumber, [FromBody] int listId)
    {
        throw new NotImplementedException();

    }

    // GET api/GetAllList
    //[HttpGet("GetAllList")]
    //public void GetAllList(int listNumber)
    //{
    //    throw new NotImplementedException();

    //}


    // PUT api/<ShoppingListController>/5
    [HttpPut("{id}")]
    public IActionResult UpdateList(int id, [FromBody] string value)
    {
        throw new NotImplementedException();
    }

    // DELETE api/<ShoppingListController>/5
    [HttpDelete("{id}")]
    public IActionResult DeleteList(int listNumber, int listId)
    {
        throw new NotImplementedException();
    }
}