using System.Data;
using Dapper;
using ProductService.Api.Models;

namespace ProductService.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _db;
    public ProductRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<int> CreateAsync(Product product)
    {
        var sql = @"INSERT INTO T_Product (Name, Price, Stock)
                        VALUES (@Name, @Price, @Stock);
                        SELECT CAST(SCOPE_IDENTITY() as int);";

        return await _db.ExecuteScalarAsync<int>(sql, product);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "DELETE FROM T_Product WHERE Id = @Id";
        var affected = await _db.ExecuteAsync(sql, new { Id = id });
        return affected > 0;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var sql = "SELECT * FROM T_Product";
        return await _db.QueryAsync<Product>(sql);
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM T_Product WHERE Id = @Id";
        return await _db.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
    }

    public async Task<bool> UpdateAsync(int id, Product product)
    {
        var sql = @"UPDATE T_Product
                        SET Name = @Name, Price = @Price, Stock = @Stock
                        WHERE Id = @Id";
        var affected = await _db.ExecuteAsync(sql, product);
        return affected > 0;
    }
}