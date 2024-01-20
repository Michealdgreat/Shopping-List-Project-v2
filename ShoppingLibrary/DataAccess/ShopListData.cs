using ShoppingLibrary.ShoppingListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary.DataAccess;

public class ShopListData
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

    public Task AddNote(int listNumber, string addNote)
    {
        return _sql.SaveData<dynamic>("dbo.spShoppingData_AddNote", new { ListNumber = listNumber, AddNote = addNote }, "Default");
    }


}
