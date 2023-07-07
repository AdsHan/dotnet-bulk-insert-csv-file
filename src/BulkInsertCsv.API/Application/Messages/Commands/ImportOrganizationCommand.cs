using BulkInsertCsv.API.Common;

namespace BulkInsertCsv.API.Application.Messages.Commands;

public class ImportOrganizationCommand : Command
{
    public ImportOrganizationCommand(IFormFile file)
    {
        File = file;
    }

    public IFormFile File { get; set; }
}
