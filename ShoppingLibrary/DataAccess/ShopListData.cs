using Microsoft.AspNetCore.Http;
using ShoppingLibrary.ShoppingListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary.DataAccess;

public class ShopListData : IShopListData
{
    private readonly ISqlDataAccess _sql;

    public ShopListData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    //dynamic is used to pass anonymous object

    public Task<List<ListModel>> GetAllList(int listNumber)
    {
        return _sql.LoadData<ListModel, dynamic>("dbo.spShopppingListData_GetAllList", new { ListNumber = listNumber }, "Default");
    }


    public async Task<ListModel?> GetOneList(int listNumber, int listId)
    {
        var results = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_GetOnetList", new { ListNumber = listNumber, ListId = listId }, "Default");

        return results.FirstOrDefault();
    }


    public async Task<ListModel?> AddNote(int listNumber, string addNote)
    {
        var results = await _sql.LoadData<ListModel, dynamic>("dbo.spShoppingData_AddNote", new { ListNumber = listNumber, AddNote = addNote }, "Default");

        return results.FirstOrDefault();
    }

    public async Task<ListModel?> Budget(int listNumber, double budget)
    {
        var result = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_Budget", new { ListNumber = listNumber, Budget = budget }, "Default");

        return result.FirstOrDefault();
    }

    public async Task<ListModel?> CategoryName(int listNumber, string categoryName)
    {
        var result = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_CategoryName", new { ListNumber = listNumber, CategoryName = categoryName }, "Default");

        return result.FirstOrDefault();
    }


    public async Task<ListModel?> Date(int listNumber, string date)
    {
        var results = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_Date", new { ListNumber = listNumber, Date = date }, "Default");

        return results.FirstOrDefault();
    }

    public Task DeleteList(int listNumber, int listId)
    {
        return _sql.SaveData<dynamic>("dbo.spShopppingData_DeleteList", new { ListNumber = listNumber, ListId = listId }, "Default");
    }

    public async Task<ListModel?> ExcessMoney(int listNumber, double excessMoney)
    {
        var result = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_ExcessMoney", new { ListNumber = listNumber, ExcessMoney = excessMoney }, "Default");

        return result.FirstOrDefault();
    }

    public async Task<ListModel?> Price(int listNumber, double price)
    {
        var result = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_Price", new { ListNumber = listNumber, Price = price }, "Default");

        return result.FirstOrDefault();
    }

    public async Task<ListModel?> ProductName(int listNumber, string productName)
    {
        var results = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_ProductName", new { ListNumber = listNumber, ProductName = productName }, "Default");

        return results.FirstOrDefault();
    }

    public async Task<ListModel?> SavedMoney(int listNumber, double savedMoney)
    {
        var results = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_SavedMoney", new { ListNumber = listNumber, SavedMoney = savedMoney }, "Default");

        return results.FirstOrDefault();
    }

    public Task SaveList(int listNumber, int listId)
    {
        return _sql.SaveData<dynamic>("dbo.spShopppingData_SaveList", new { ListNumber = listNumber, ListId = listId }, "Default");
    }

    public async Task<ListModel?> StoreName(int listNumber, string storeName)
    {
        var results = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_StoreName", new { ListNumber = listNumber, StoreName = storeName }, "Default");

        return results.FirstOrDefault();
    }

    public async Task<ListModel?> TotalSpent(int listNumber, double totalSpent)
    {
        var results = await _sql.LoadData<ListModel, dynamic>("dbo.spShopppingData_TotalSpent", new { ListNumber = listNumber, TotalSpent = totalSpent }, "Default");

        return results.FirstOrDefault();
    }

    public Task UpdateList(int listNumber, string addNote, double savedMoney, double excessMoney, double totalSpent, double price, string storeName, double budget, int listId, string categoryName, string date)
    {
        return _sql.SaveData<dynamic>("dbo.spShopppingData_UpdateList", new { ListNumber = listNumber, AddNote = addNote, SavedMoney = savedMoney, ExcessMoney = excessMoney, TotalSpent = totalSpent, Price = price, StoreName = storeName, Budget = budget, ListId = listId, CategoryName = categoryName, Date = date }, "Default");
    }
}