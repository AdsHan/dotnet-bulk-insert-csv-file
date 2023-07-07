using CsvHelper.Configuration.Attributes;

namespace BulkInsertCsv.API.Data.Entities;

public class OrganizationModel
{
    [Ignore]
    public int Id { get; set; }

    [Name("Organization Id")]
    public string OrganizationId { get; set; }

    [Name("Name")]
    public string Name { get; set; }

    [Name("Website")]
    public string Website { get; set; }

    [Name("Country")]
    public string Country { get; set; }

    [Name("Description")]
    public string Description { get; set; }

    [Name("Founded")]
    public string Founded { get; set; }

    [Name("Industry")]
    public string Industry { get; set; }

    [Name("Number of employees")]
    public int NumberOfEmployees { get; set; }
}
