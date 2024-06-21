using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using SimpleShop.Context.Models;
using SimpleShop.Interfaces;

namespace SimpleShop.Context.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IDbConnection _db;

    public ClientRepository()
    {
        _db = new SqliteConnection("Data Source=DatabaseShop.db");
        _db.Open();
    }

    public async Task Add(Client client)
    {
        string sql =
            "INSERT INTO Clients (ClientId,Dni,FirstName,LastName,Age) VALUES(@ClientId,@Dni,@FirstName,@LastName,@Age)";
        await _db.QueryAsync(sql, client);
        _db.Close();
    }

    public async Task<Client> Find(Guid id)
    {
        string sql =
            "SELECT * FROM Clients WHERE ClientId = @id";
        var result = await _db.QueryFirstAsync<Client>(sql, new { id });
        return result;
    }

    public async Task<Client> Update(Client client)
    {
        string sqlUpdate =
            "UPDATE Clients SET FirstName = @FirstName, LastName = @LastName, Age = @Age WHERE Dni = @Dni";

        string sqlSelect =
            "SELECT * FROM Clients WHERE Dni = @Dni";
        await _db.ExecuteAsync(sqlUpdate, client);
        var result = await _db.QueryFirstAsync<Client>(sqlSelect, new { client.Dni });
        _db.Close();
        return result;
    }

    public async Task Remove(string dni)
    {
        string sql =
            "DELETE FROM Clients WHERE Dni = @dni";
        await _db.QueryAsync(sql, new { dni });
        _db.Close();
    }

    public async Task<string> GetIdByDni(string dni)
    {
        string sql =
            $"SELECT ClientId FROM Clients WHERE Dni = @dni";
        var result = await _db.QueryFirstAsync<string>(sql, new { dni });
        _db.Close();
        return result;
    }

    public async Task<Client> GetByDni(string dni)
    {
        string sql =
            $"SELECT * FROM Clients WHERE Dni = @dni";
        var result = await _db.QueryFirstAsync<Client>(sql, new { dni });
        _db.Close();
        return result;
    }


    public async Task<bool> AnyByDni(string dni)
    {
        string sql =
            "SELECT CASE WHEN EXISTS(SELECT Dni FROM Clients WHERE Dni=@dni) THEN TRUE ELSE FALSE END as existence";

        bool result = await _db.QueryFirstAsync<bool>(sql, new { dni });
        _db.Close();
        return result;
    }

    public async Task<bool> AnyById(Guid id)
    {
        string sql =
            "SELECT CASE WHEN EXISTS(SELECT ClientId FROM Clients WHERE ClientId=@id) THEN TRUE ELSE FALSE END as existence";

        bool result = await _db.QueryFirstAsync<bool>(sql, new { id });
        _db.Close();
        return result;
    }
}