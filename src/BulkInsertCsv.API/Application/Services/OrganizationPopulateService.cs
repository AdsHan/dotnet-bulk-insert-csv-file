using BulkInsertCsv.API.Data;
using BulkInsertCsv.API.Data.Entities;

namespace BulkInsertCsv.API.Application.Services;

public class OrganizationPopulateService
{

    private readonly OrganizationDbContext _dbContext;

    public OrganizationPopulateService(OrganizationDbContext context)
    {
        _dbContext = context;
    }

    public async Task Initialize()
    {
        if (_dbContext.Database.EnsureCreated())
        {
            var random = new Random();

            for (int i = 1; i < 10; i++)
            {
                _dbContext.Organizations.Add(new OrganizationModel()
                {
                    OrganizationId = new Guid().ToString(),
                    Name = $"Name- {i}",
                    Website = $"www.{i}.com.br",
                    Country = "Brasil",
                    Description = $"Description - {i}",
                    Founded = random.Next(1950, 2000).ToString(),
                    Industry = "Rentail",
                    NumberOfEmployees = random.Next(1, 100),
                });
            }
            _dbContext.SaveChanges();
        };
    }
}