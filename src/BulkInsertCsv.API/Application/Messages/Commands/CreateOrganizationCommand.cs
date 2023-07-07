using BulkInsertCsv.API.Common;

namespace BulkInsertCsv.API.Application.Messages.Commands;

public class CreateOrganizationCommand : Command
{
    public string OrganizationId { get; set; }
    public string Name { get; set; }
    public string Website { get; set; }
    public string Country { get; set; }
    public string Description { get; set; }
    public string Founded { get; set; }
    public string Industry { get; set; }
    public int NumberOfEmployees { get; set; }
}
