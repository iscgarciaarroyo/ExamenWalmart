using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi.Core.Repositories;
using WebApi.Core.Entities;
using System;

namespace WebApi.Repositories
{
    public class PlatilloRepository : IPlatilloRepository
    {
        private readonly string _connectionString;
        public PlatilloRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("dbConnectionSQL");
        }

        public async Task<IEnumerable<Platillo>> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT Id, Nombre, Ingredientes, Peso, Calorias, Precio, Tipo FROM Platillo";

            var Platillos = await connection.QueryAsync<Platillo>(sql);
            return Platillos;
        }

        public async Task<Platillo> GetById(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT Id, Nombre, Ingredientes, Peso, Calorias, Precio, Tipo FROM Platillo WHERE Id=@Id";

            var Platillos = await connection.QueryFirstOrDefaultAsync<Platillo>(sql, new { Id = id });
            return Platillos;
        }

        public async Task<int> Insert(Platillo Platillo)
        {
            using var connection = new SqlConnection(_connectionString);
            string id = Guid.NewGuid().ToString();

            var sql = @"INSERT INTO Platillo (Id, Nombre, Ingredientes, Peso, Calorias, Precio, Tipo) 
                            VALUES (@Id, @Nombre, @Ingredientes, @Peso, @Calorias, @Precio, @Tipo)";

            var affectedRows = await connection.ExecuteAsync(sql, new { id, Platillo.Nombre, Platillo.Ingredientes, Platillo.Peso, Platillo.Calorias, Platillo.Precio, Platillo.Tipo });//new{Id=Platillo.Id, Title=Platillo.Title...}
            return affectedRows;
        }

        public async Task<int> Update(Platillo Platillo)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = @"UPDATE Platillo SET Nombre=@Nombre, Ingredientes=@Ingredientes, Peso=@Peso, Calorias=@Calorias, Precio=@Precio, Tipo=@Tipo
                            WHERE Id=@Id";

            var affectedRows = await connection.ExecuteAsync(sql, Platillo);//new{Id=Platillo.Id, Title=Platillo.Title...}
            return affectedRows;
        }

        public async Task<int> Delete(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = @"DELETE FROM Platillo WHERE Id=@Id";

            var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
            return affectedRows;
        }
    }
}
