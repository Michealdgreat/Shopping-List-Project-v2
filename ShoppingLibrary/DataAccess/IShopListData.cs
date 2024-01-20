using ShoppingLibrary.ShoppingListModel;

namespace ShoppingLibrary.DataAccess
{
    public interface IShopListData
    {
        Task<ListModel?> AddNote(int listNumber, string addNote);
        Task<ListModel?> Budget(int listNumber, double budget);
        Task<ListModel?> categoryName(int listNumber, string categoryName);
        Task<ListModel?> Date(int listNumber, string date);
        Task DeleteList(int listNumber, int listId);
        Task<ListModel?> ExcessMoney(int listNumber, double excessMoney);
        Task<List<ListModel>> GetAllList(int listNumber);
        Task<ListModel?> GetOneList(int listNumber, int listId);
        Task<ListModel?> Price(int listNumber, double price);
        Task<ListModel?> ProductName(int listNumber, string productName);
        Task<ListModel?> SavedMoney(int listNumber, double savedMoney);
        Task SaveList(int listNumber, int listId);
        Task<ListModel?> StoreName(int listNumber, string storeName);
        Task<ListModel?> TotalSpent(int listNumber, double totalSpent);
        Task UpdateList(int listNumber, string addNote, double savedMoney, double excessMoney, double totalSpent, double price, string storeName, double budget, int listId, string categoryName, string date);
    }
}