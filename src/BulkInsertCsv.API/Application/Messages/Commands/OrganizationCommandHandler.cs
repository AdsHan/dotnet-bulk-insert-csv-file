using BulkInsertCsv.API.Common;
using BulkInsertCsv.API.Data;
using BulkInsertCsv.API.Data.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using System.Globalization;

namespace BulkInsertCsv.API.Application.Messages.Commands;

public class OrganizationCommandHandler : CommandHandler,
    IRequestHandler<CreateOrganizationCommand, BaseResult>,
    IRequestHandler<ImportOrganizationCommand, BaseResult>
{
    private readonly OrganizationDbContext _dbContext;

    public OrganizationCommandHandler(OrganizationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BaseResult> Handle(CreateOrganizationCommand command, CancellationToken cancellationToken)
    {
        var organization = new OrganizationModel
        {
            OrganizationId = command.OrganizationId,
            Name = command.Name,
            Website = command.Website,
            Country = command.Country,
            Description = command.Description,
            Founded = command.Founded,
            Industry = command.Industry,
            NumberOfEmployees = command.NumberOfEmployees,
        };

        _dbContext.Add(organization);

        await _dbContext.SaveChangesAsync();

        BaseResult.Response = organization.Id;

        return BaseResult;
    }

    public async Task<BaseResult> Handle(ImportOrganizationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            using var streamReader = new StreamReader(command.File.OpenReadStream());

            using var csvReader = new CsvReader(streamReader, configuration);

            var records = csvReader.GetRecords<OrganizationModel>();

            //using var transaction = _dbContext.Database.BeginTransaction();

            _dbContext.Set<OrganizationModel>().AddRange(records);
            _dbContext.SaveChanges();

            //transaction.Commit();

            BaseResult.Response = records.Count();
        }
        catch (Exception ex)
        {
            AddError($"Erro ao importar o CSV: {ex.Message}");
        }

        return BaseResult;
    }
}
