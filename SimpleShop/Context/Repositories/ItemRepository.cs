using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using SimpleShop.Context.Models;
using SimpleShop.Interfaces;

namespace SimpleShop.Context.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly IDbConnection _db;

    public ItemRepository()
    {
        _db = new SqliteConnection("Data Source=DatabaseShop.db");
        _db.Open();
    }

    public async Task Add(List<Item> items)
    {
        string sql =
            "INSERT INTO Items (Name,Price,Brand,CreateAt,UpdateAt,ClientId) VALUES (@Name,@Price,@Brand,@CreateAt,@UpdateAt,@ClientId)";
        foreach (var item in items)
        {
            await _db.ExecuteAsync(sql, item);
        }
        _db.Close();
    }

    public async Task Remove(Guid id)
    {
        string sql =
            "DELETE FROM Items WHERE ItemId = @id";
        await _db.ExecuteAsync(sql, new { id });
        _db.Close();
    }

    public async Task<IEnumerable<Item>> GetByClientDni(string dni)
    {
        string sql =
            "SELECT i.ItemId,i.Name,i.Price,i.Brand,i.UpdateAt FROM Items i inner join Clients c ON i.ClientId = c.ClientId WHERE c.Dni = @dni";
        var result = await _db.QueryAsync<Item>(sql,new{dni});
        _db.Close();
        return result;
    }

    public async Task<Item> Update(Item item)
    {
        string sqlUpdate =
            "UPDATE Items SET Name = @Name, Price = @Price, Brand = @Brand, UpdateAt = @UpdateAt WHERE ItemId = @ItemId";
        await _db.ExecuteAsync(sqlUpdate, item);
        
        string sqlSelect =
            "SELECT Name,Price,Brand,UpdateAt FROM Items WHERE ItemId = @ItemId";
        var result = await _db.QueryFirstAsync<Item>(sqlSelect,item);
        _db.Close();
        return result;
    }
}